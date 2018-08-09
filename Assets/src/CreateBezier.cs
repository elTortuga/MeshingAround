using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBezier : MonoBehaviour
{

    public Vector3[] controlPoints;
    public int accuracy;
    private Vector3[] bezierPoints;

    // Use this for initialization
    void Start()
    {

    }


	private Vector3[] CreateBezierVectors(Vector3[][] setsOfVectors){



		return new Vector3[0];
	}

	// Create a set of vectors with each index representing a step in an interpolated 
    private Vector3[] CreateVectorsFromTwoSetsOfVectors(Vector3[] a, Vector3[] b)
    {
		Vector3[] localVectors = new Vector3[this.accuracy];
		for (int t = 0; t < this.accuracy; t++)
		{
			localVectors[t] = LerpVectorsAtT(a[t], b[t], t+1);
		}
		return localVectors;
    }

    private Vector3[] CreateVectorsFromControlPoints(Vector3 a, Vector3 b)
    {
		int numberOfSteps = accuracy;
		Vector3[] localVectors = new Vector3[this.accuracy]; 
		for (int t = 0; t < this.accuracy; t++)
		{
			localVectors[t] = LerpVectorsAtT(a, b, this.accuracy/(t+1));
		}
		return localVectors;
    }

    //Interpolate two vectors 
    private Vector3 LerpVectorsAtT(Vector3 a, Vector3 b, int t)
    {
        return new Vector3
        (
            Mathf.Lerp(a.x, b.x, t),
            Mathf.Lerp(a.y, b.y, t),
            Mathf.Lerp(a.z, b.z, t)
        );
    }



}
