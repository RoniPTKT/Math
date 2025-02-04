using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class ConeTrigger : MonoBehaviour
{

    [SerializeField] float radius;
    [SerializeField] GameObject target;
    [SerializeField] GameObject lookTarget;
    [SerializeField] float fov;
    Vector3 visionLeft;
    Vector3 visionRight;
    Vector3 look_n;
    Vector3 lookDistance;
    public bool isInRange;
    private Vector3 distanceToTarget;
    Color radiusColor;


    private void OnDrawGizmos()
    {
        Handles.color = Color.blue;
        Handles.DrawLine(transform.position, lookTarget.transform.position);
        Handles.color = Color.red;
        Handles.DrawLine(transform.position, visionLeft);
        Handles.DrawLine(transform.position, visionRight);
        Handles.Disc(Quaternion.identity, transform.position, Vector3.forward, radius, false, 1);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lookDistance = transform.position - lookTarget.transform.position;
        look_n = lookDistance.normalized;
        radius = lookDistance.magnitude;

        visionLeft = lookTarget.transform.position;
        visionLeft = Quaternion.Euler(0, 0, fov/2) * visionLeft;

        visionRight = lookTarget.transform.position;
        visionRight = Quaternion.Euler(0, 0, -fov / 2) * visionRight;

    }

    void CalculateRange()
    {
        //Calculate the distance between the trigger and target
        distanceToTarget = target.transform.position - transform.position;
        if (distanceToTarget.magnitude < radius)        //Check if the target is inside the trigger radius
        {
            if (!isInRange)
            {
                radiusColor = Color.red;
                isInRange = true;
            }
        }
        else
        {
            if (isInRange)
            {
                radiusColor = Color.green;
                isInRange = false;
            }
        }
        Vector3 n = distanceToTarget.normalized;
    }
}
