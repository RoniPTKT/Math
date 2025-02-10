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
    [SerializeField] float height;
    Vector3 heightVector;
    Vector3 visionLeft;
    Vector3 visionRight;
    Vector3 look_n;
    Vector3 lookDistance;

    private Vector3 distanceToTarget;
    Color triggerColor;

    Vector3 lookVector;
    Vector3 targetVector;


    private void OnDrawGizmos()
    {
        Handles.color = Color.blue;
        Handles.DrawLine(transform.position, lookTarget.transform.position);
        Handles.color = triggerColor;

        //Draw lines from the center to the left and right vision ranges, for top and bottom layers
        Handles.DrawLine(transform.position, visionLeft);
        Handles.DrawLine(transform.position, visionRight);
        Handles.DrawLine(visionLeft, visionLeft + heightVector);
        Handles.DrawLine(visionRight, visionRight + heightVector);

        //Draw line between top and bottom layer in the center
        Handles.DrawLine(transform.position, transform.position + heightVector);

        //Draw line from bottom to top layer at the vision range points
        Handles.DrawLine(transform.position + heightVector, visionLeft + heightVector);
        Handles.DrawLine(transform.position +  heightVector, visionRight + heightVector);

        //Draw an arc from the look target to the vision ranges on both layers
        Handles.DrawWireArc(transform.position, Vector3.up, lookVector, fov/2, radius);
        Handles.DrawWireArc(transform.position, Vector3.up, lookVector, -(fov/2), radius);
        Handles.DrawWireArc(transform.position +  heightVector, Vector3.up, lookVector, fov / 2, radius);
        Handles.DrawWireArc(transform.position + heightVector, Vector3.up, lookVector, -(fov / 2), radius);

    }

    void Update()
    {
        lookDistance = transform.position - lookTarget.transform.position;
        look_n = lookDistance.normalized;
        radius = lookDistance.magnitude;
        lookVector = lookTarget.transform.position - transform.position;

        //Find the left and right points for the vision range and adjust that vector to follow the object
        visionLeft = lookVector;     
        visionLeft = Quaternion.Euler(0, -(fov / 2), 0) * visionLeft;
        visionLeft += transform.position;
        visionRight = lookVector;
        visionRight = Quaternion.Euler(0, fov / 2, 0) * visionRight;
        visionRight += transform.position;

        heightVector = new Vector3(0, height, 0);

        targetVector = target.transform.position - transform.position;

        if (IsTargetInRange() && IsTargetInView())
        {
            triggerColor = Color.red;
        }
        else
        {
            triggerColor = Color.green;
        }
    }

    bool IsTargetInRange()
    {
        bool isInRange = false;
        //Calculate the distance between the trigger and target
        distanceToTarget = target.transform.position - transform.position;
        if (distanceToTarget.magnitude < radius)        //Check if the target is inside the trigger radius
        {
            isInRange = true;
        }
        else
        {
            isInRange = false;
        }
        return isInRange;
    }

    bool IsTargetInView()
    {
        bool isInView = false;        
        if (Vector3.Angle(targetVector, lookVector) < fov/2)    //Compare vector to target to look vector. If the angle is smaller than half of the fov, it's inside.
        {
            if (target.transform.position.y > transform.position.y && target.transform.position.y < transform.position.y + height)      //Check if target is inside the height specified in the inspector
            {
                isInView = true;
            }
        }
        else
        {
            isInView = false;
        }
        return isInView;
    }
}
