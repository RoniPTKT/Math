using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BasicDrawing : MonoBehaviour
{
    [SerializeField]
    public float axis_length = 3.0f;

    public GameObject VectorTo;

    public GameObject RectPos;
    [Range(0.1f, 20f)]
    public float RectWidth = 5.0f;
    [Range(0.1f, 10f)]
    public float RectHeight = 3.0f;


    public void DrawVectorAt(Vector3 pos, Vector3 vec, Color c, float thickness = 1.0f)
    {
        Handles.color = c;
        Handles.DrawLine(pos, pos + vec, thickness);

        Handles.ConeHandleCap(0, pos + vec - 0.2f * vec.normalized, Quaternion.LookRotation(vec), 0.286f, EventType.Repaint);

    }

    private void DrawAxesAt(Vector3 location, float axis_magnitude, float thickness = 1.0f)
    {
        DrawVectorAt(location, new Vector3(axis_magnitude, 0, 0), Color.red, thickness);
        DrawVectorAt(location, new Vector3(0, axis_magnitude, 0), Color.green, thickness);
    }

    private void DrawXYRectAt(Vector3 pos, float width, float height, Color c, float thickness = 2.0f)
    {
        Handles.color = c;
        Vector3 bot_left = pos;
        Vector3 bot_right = pos + new Vector3(width, 0, 0);
        Vector3 top_left = pos + new Vector3(0, height, 0);
        Vector3 top_right = pos + new Vector3(width, height, 0);

        Handles.DrawLine(bot_left, bot_right, thickness);
        Handles.DrawLine(bot_left, top_left, thickness);
        Handles.DrawLine(bot_right, top_right, thickness);
        Handles.DrawLine(top_left, top_right, thickness);
    }


    private void OnDrawGizmos()
    {
        // DRAW X-AXIS (red)
        //Gizmos.color = Color.red;
        // draws a line "from" -- "to" (x,y,z)
        //Gizmos.DrawLine(Vector3.zero,
        //                new Vector3(axis_length,0,0));
        //DrawVectorAt(Vector3.zero, new Vector3(axis_length, 0, 0), Color.red, 2.0f);


        // DRAW Y-AXIS (green)
        //Gizmos.color = Color.green;
        // draws a line "from" -- "to" (x,y,z)
        //Gizmos.DrawLine(Vector3.zero,
        //                new Vector3(0, axis_length, 0));
        //DrawVectorAt(Vector3.zero, new Vector3(0, axis_length, 0), Color.green, 2.0f);

        // AXES
        DrawAxesAt(Vector3.zero, axis_length, 3.0f);



        // Unit circle
        Handles.color = Color.white;
        Handles.DrawWireDisc(Vector3.zero, Vector3.back, 1.0f);

        // Given vector (from Origin ---> VectorTo)
        //Gizmos.color = Color.black;
        //Gizmos.DrawLine(Vector3.zero,
        //                VectorTo.transform.position);
        DrawVectorAt(Vector3.zero, VectorTo.transform.position, Color.black, 4.0f);
        DrawAxesAt(VectorTo.transform.position, 1.0f, 2.0f);


        // Rectangle???
        DrawXYRectAt(RectPos.transform.position, RectWidth, RectHeight, Color.black, 3.0f);
        DrawAxesAt(RectPos.transform.position, 1.0f, 2.0f);

        //        Handles.DrawSolidRectangleWithOutline(new Rect(RectPos.transform.position.x,
        //                                                       RectPos.transform.position.y,
        //                                                       RectWidth, RectHeight), 
        //                                                       Color.magenta, Color.black);
        // Draw line from RectPos to "RectPos + width"
        // Draw line from RectPos to "RectPos + height"

        // Draw line from "RectPos + width" to "RectPos + width&height"
        // Draw line from "RectPos + height" to "RectPos + width&height"

    }

}