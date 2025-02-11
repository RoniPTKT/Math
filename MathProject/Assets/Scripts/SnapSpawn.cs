using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SnapSpawn : MonoBehaviour
{

    [SerializeField] GameObject objectToSpawn;
    GameObject spawnPreview;
    RaycastHit hit;
    Vector3 dir = new Vector3(0, -100, 100);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDrawGizmos()
    {
        
        Handles.DrawLine(transform.position, hit.point);
    }

    // Update is called once per frame
    void Update()
    {
        bool validPos = Physics.Raycast(transform.position, dir, out hit);
        if (validPos)
        {
            if (spawnPreview == null)
            {
                spawnPreview = Instantiate(objectToSpawn, hit.point, Quaternion.identity);
            }

            spawnPreview.transform.up = hit.normal;
            //Quaternion newRot = new Quaternion(spawnPreview.transform.rotation.x, transform.rotation.y, spawnPreview.transform.rotation.z, 1);
            Quaternion newRot = new Quaternion(spawnPreview.transform.rotation.x, transform.rotation.y, spawnPreview.transform.rotation.z, 1);
            spawnPreview.transform.SetPositionAndRotation(hit.point, newRot);

            Debug.Log(hit.normal);
        }
    }
}
