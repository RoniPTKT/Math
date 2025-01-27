using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Draw : MonoBehaviour
{

    [SerializeField] private float circleRadius;
    [SerializeField] private Vector3 targetVector;
    [SerializeField] private float rectangleX;
    [SerializeField] private float rectangleY;

    private void OnDrawGizmos()
    {
        DrawCircle(targetVector, circleRadius);
        DrawRectangle(targetVector, rectangleX, rectangleY);
        DrawAxis(transform.position);
        DrawVectorLine(transform.position, targetVector);
    }

    public void DrawCircle(Vector3 pos, float radius)
    {
        Handles.color = Color.cyan;
        Handles.Disc(Quaternion.identity, pos, Vector3.forward, circleRadius, false, 1);
    }

    public void DrawRectangle(Vector3 pos, float width, float height)
    {
        Handles.color = Color.white;

        Vector3 bot_left = pos;
        Vector3 top_left = new Vector3(pos.x, pos.y + height, pos.z);
        Vector3 bot_right = new Vector3(pos.x + width, pos.y, pos.z);
        Vector3 top_right = new Vector3(pos.x + width, pos.y + height, pos.z);

        Handles.DrawLine(bot_left, bot_right);
        Handles.DrawLine(bot_left, top_left);
        Handles.DrawLine(top_left, top_right);
        Handles.DrawLine(bot_right, top_right);
    }

    public void DrawAxis(Vector3 pos)
    {
        Handles.color = Color.red;
        Handles.DrawLine(transform.position, new Vector3(1, 0, 0));
        Handles.color = Color.green;
        Handles.DrawLine(transform.position, new Vector3(0, 1, 0));
        Handles.color = Color.blue;
        Handles.DrawLine(transform.position, new Vector3(0, 0, 1));
    }

    public void DrawVectorLine(Vector3 origin, Vector3 target)
    {
        Handles.color = Color.yellow;
        Handles.DrawLine(origin, target);
    }
}

