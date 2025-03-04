using System.Collections.Generic;
using UnityEngine;

public class ProceduralDiscMesh : MonoBehaviour
{

    [Range(3, 100)] public int segments = 6;
    [Range(1f, 10f)] public float radius = 2f;

    public void OnDrawGizmos()
    {
        float delta_angle = 360.0f / segments;
        float angle = 0.0f;

        for (int i = 0; i < segments; i++)
        {
            float x = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
            float y = radius * Mathf.Sin(angle * Mathf.Deg2Rad);
            x += transform.position.x;
            y += transform.position.z;

            Gizmos.color = Color.white;
            Gizmos.DrawSphere(new Vector3(x, 0, y), 0.05f);

            angle += delta_angle;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mesh mesh = GenerateDiscMesh();
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
    }


    private Mesh GenerateDiscMesh()
    {
        List<Vector3> vertices = new();
        List<Vector2> uvs = new();

        vertices.Add(Vector3.zero);
        uvs.Add(new Vector2( 0.5f, 0.5f));

        float delta_angle = 360.0f / segments;
        float angle = 0f;
        for (int i = 0; i < segments; i++)
        {
            float x = Mathf.Cos(angle * Mathf.Deg2Rad);
            float y = Mathf.Sin(angle * Mathf.Deg2Rad);
            //x += transform.position.x;
            //y += transform.position.y;

            Vector3 vertex = new Vector3(radius * x, 0, radius * y);
            vertices.Add(vertex);
            uvs.Add(new Vector2((x / 2f) + 0.5f, (y / 2f) + 0.5f));

            angle += delta_angle;
        }

        List<int> triangles = new List<int>();
        for (int i = 0; i < segments - 1; i++)
        {
            triangles.Add(0);
            triangles.Add(i + 2);
            triangles.Add(i + 1);

        }
        triangles.Add(0);
        triangles.Add(1);
        triangles.Add(segments);

        Mesh mesh = new Mesh();
        mesh.SetVertices(vertices);
        mesh.SetTriangles(triangles, 0);
        mesh.RecalculateNormals();
        mesh.SetUVs(0, uvs);
        return mesh;
    }

    private Mesh GenerateMesh()
    {
        Vector3[] vertices = new Vector3[4];
        // INDEX                  X  Y  Z
        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(1, 0, 0);
        vertices[2] = new Vector3(0, 0, 1);
        vertices[3] = new Vector3(1, 0, 1);

        int[] triangles = new int[2 * 3];
        //first tri
        triangles[0] = 0;
        triangles[1] = 3;
        triangles[2] = 1;
        //second tri
        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        Mesh mesh = new Mesh();
        mesh.vertices = vertices; //set vertices

        mesh.triangles = triangles; //set triangles

        //compute normals for our new mesh
        mesh.RecalculateNormals();

        //finds meshfilter for the object
        gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;

        return mesh;
    }
}
