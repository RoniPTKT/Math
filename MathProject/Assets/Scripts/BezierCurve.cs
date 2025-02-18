using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{

    public GameObject pointA;
    public GameObject pointB;
    public GameObject pointC;
    public GameObject pointD;

    [Range(0, 1)] public float t;

    public bool drawInterpolation = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnDrawGizmos()
    {
        //Get position of the curve handles
        Vector3 posA = pointA.transform.position;
        Vector3 posB = pointB.transform.position;
        Vector3 posC = pointC.transform.position;
        Vector3 posD = pointD.transform.position;

        //Draw lines between handles
        Handles.DrawLine(posA, posB);
        Handles.DrawLine(posB, posC);
        Handles.DrawLine(posC, posD);

        //Interpolate between handles
        Vector3 posX = (1 - t) * posA + t * posB;
        Vector3 posY = (1 - t) * posB + t * posC;
        Vector3 posZ = (1 - t) * posC + t * posD;

        //Draw the interpolated positions
        if (drawInterpolation)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawSphere(posX, 0.05f);
            Gizmos.DrawSphere(posY, 0.05f);
            Gizmos.DrawSphere(posZ, 0.05f);
            Handles.DrawLine(posX, posY);
            Handles.DrawLine(posY, posZ);
        }

        //Second interpolation
        Vector3 posR = (1 - t) * posX + t * posY;
        Vector3 posS = (1 - t) * posY + t * posZ;

        if (drawInterpolation)
        {
            //Draw second interpolated positions
            Gizmos.DrawSphere(posR, 0.05f);
            Gizmos.DrawSphere(posS, 0.05f);
            Handles.DrawLine(posR, posS);
        }

        //Final interpolated position
        Vector3 posO = (1 - t) * posR + t * posS;

        //Draw final position
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(posO, 0.1f);

        Handles.DrawBezier(posA, posD, posB, posC, Color.white, null, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
