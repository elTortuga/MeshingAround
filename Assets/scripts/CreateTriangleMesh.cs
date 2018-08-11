using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTriangleMesh : MonoBehaviour {
	
	public float width = 50f;
	public float height = 50f;
	public MeshFilter meshFilter ;
	
	// Use this for initialization
	void Start () {
		Mesh mesh = new Mesh ();
		meshFilter.mesh = mesh;
		
		//Vertices
		Vector3[] verticies = new Vector3[3]
		{
			new Vector3(0,0,0), new Vector3(width, 0, 0), new Vector3(0, height, 0)
		};
		
		//Triangels
		int[] tri = new int[3];
		
		tri [0] = 0;
		tri [1] = 2;
		tri [2] = 1;

		//Normals (only if you want to display objects in the game)
		Vector3[] normals = new Vector3[3];
		
		normals [0] = -Vector3.forward;
		normals [1] = -Vector3.forward;
		normals [2] = -Vector3.forward;
		
		//UVs (How textures are displayed).
		Vector2[] uv = new Vector2[3];
		
		uv [0] = new Vector2 (0, 0);
		uv [1] = new Vector2 (1, 0);
		uv [2] = new Vector2 (0, 1);
		
		//Assign Arrays
		mesh.vertices = verticies;
		mesh.triangles = tri;
		mesh.normals = normals;
		mesh.uv = uv;
	}
}
