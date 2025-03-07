using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMesh : MonoBehaviour
{
    Vector3[] vertices = new Vector3[4];
    int[] triangles = new int[6];
    Vector2[] uvs = new Vector2[4];

    // Update is called once per frame
    void Update()
    {


        
    }

    private void Start()
    {

        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(1, 0, 0);
        vertices[2] = new Vector3(0, 1, 0);
        vertices[3] = new Vector3(1, 1, 0);

        uvs[0] = new Vector2(0, 0);
        uvs[1] = new Vector2(1, 0);
        uvs[2] = new Vector2(0, 1);
        uvs[3] = new Vector2(1, 1);

        triangles[0] = 0;
        triangles[1] = 3;
        triangles[2] = 1;

        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        Mesh mesh = new Mesh();

        GetComponent<MeshFilter>().sharedMesh = mesh;
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

    }
}
