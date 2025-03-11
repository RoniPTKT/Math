using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VelocityGraph : MonoBehaviour
{
    public int steps;
    public float start;
    [Range(0,5)] public float velocity;
    public float time;
    private Vector2 pos;
    private List<Vector2> positions;
    float s;
    public bool particles = true;
    public GameObject fx;

    

    public void Start()
    {
       
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        for (int i = 0; i < steps; i++)
        {
            float t_delta = time / steps;
            float t = t_delta * i;
            s = velocity * t;
            Vector2 pos = (new Vector2(t, s + start));
            positions.Add(pos);
            Gizmos.DrawSphere (pos, 1f);
        }
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector2.zero, new Vector2(time, 0));
        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector2.zero, new Vector2(0, s));
        if(particles)
        {
            foreach (Vector2 fxPos in positions)
            {
               // GameObject particle = Instantiate(fx, transform);
                //particle.transform.position = fxPos;
            }
            particles = false;
        }
    }
}



    
  