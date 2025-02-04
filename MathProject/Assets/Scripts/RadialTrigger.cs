using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RadialTrigger : MonoBehaviour
{

    [SerializeField] float radius;
    [SerializeField] GameObject target;
    public bool isInRange;
    private Vector3 distanceToTarget;
    Color radiusColor;

    void OnDrawGizmos()
    {
        DrawRadius(transform.position, radius);
        DrawVectors();
    }

    public void DrawRadius(Vector3 pos, float radius)
    {
        Handles.color = radiusColor;
        Handles.Disc(Quaternion.identity, pos, Vector3.forward, radius, false, 1);
    }

    public void DrawVectors()
    {
        Handles.color = Color.red;
        Handles.DrawLine(Vector3.zero, target.transform.position);
        Handles.DrawLine(Vector3.zero, transform.position);
        Handles.DrawLine(transform.position, target.transform.position);

    }


    void Update()
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
