using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    RaycastHit hit;
    RaycastHit newHit;
    Vector3 normal;
    Vector3 reflection;
    Vector3 newRayVector;

    // Start is called before the first frame update
    void Start()
    { 
        
    }

    private void OnDrawGizmos()
    {
        Handles.DrawLine(transform.position, hit.point);
        Handles.DrawLine(hit.point, newHit.point);
    }

    // Update is called once per frame
    void Update()
    {
        
        Physics.Raycast(transform.position, transform.forward, out hit);
        normal = hit.normal;
        Vector3 ray = hit.point - transform.position;
        //reflection = transform.forward - 2*Vector3.Dot(transform.forward, hit.normal)*hit.normal;
        newRayVector = Vector3.Reflect(ray, normal);
        Physics.Raycast(hit.point, newRayVector, out newHit);
        
             
    }
}
