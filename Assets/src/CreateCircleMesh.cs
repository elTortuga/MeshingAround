using UnityEngine;
using System.Collections;

public class CreateCircleMesh : MonoBehaviour
{
    private float radius = 10f;
    private float theta;
    public int resolution;  // or accuracy // for example 2 or below resolution contains only zero verticies for a shape to be made from, resolution of three creates a triangle, resolution of 20 starts to look like a circle
    public int numberOfVerticies;
    public MeshFilter meshFilter;

    // Use this for initialization
    void Start()
    {
        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;
        this.theta = 2f * Mathf.PI / (this.resolution);
        this.numberOfVerticies = this.resolution + 1;

        //Vertices
        Vector3[] verticies = new Vector3[this.numberOfVerticies];

        verticies[0] = new Vector3(0, 0, 0);
        for (int i = 1; i < this.numberOfVerticies; i++)
        {
            verticies[i] = new Vector3(radius * Mathf.Cos(i * theta), radius * Mathf.Sin(i * theta), 0);
        }

        //Triangels
        int[] tri = new int[this.resolution * 3];

        for (int i = 0, index = 0; i < this.resolution - 1; i++)
        {
            index = i * 3;
            tri[index] = 0;
            tri[index + 1] = i + 2;
            tri[index + 2] = i + 1;
        }

        tri[resolution * 3 - 3] = 0;
        tri[resolution * 3 - 2] = 1;
        tri[resolution * 3 - 1] = this.resolution;

        //Normals (only if you want to display objects in the game)
        Vector3[] normals = new Vector3[this.resolution + 1];

        for (int i = 0; i < this.resolution + 1; i++)
        {
            normals[i] = -Vector3.forward;
        }

        //UVs (How textures are displayed).
        Vector2[] uv = new Vector2[this.resolution + 1];

        uv[0] = new Vector2(0, 0);

        for (int i = 1; i < this.resolution + 1; i++)
        {
            uv[i] = new Vector2(1, 1);
        }

        //Assign Arrays
        mesh.vertices = verticies;
        mesh.triangles = tri;
        mesh.normals = normals;
        mesh.uv = uv;
    }
}
