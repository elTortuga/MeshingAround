using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBezier : MonoBehaviour
{
    public Vector3[] controlPoints;
    public int accuracy;

    private Vector3[] bezierPoints;

    public Vector3[] CreateBezierCurve(Vector3[] controlPoints)
    {
        Vector3[][] setOfVectorSets = new Vector3[controlPoints.Length - 1][];
        for (int i = 0; i < controlPoints.Length - 1; i++)
        {
            setOfVectorSets[i] = CreateVectorsFromControlPoints(controlPoints[i], controlPoints[i + 1]);
        }
        return CreateBezierVectors(setOfVectorSets);
    }
    
    public Vector3[] CreateBezierCurve()
    {
        Vector3[][] setOfVectorSets = new Vector3[this.controlPoints.Length - 1][];
        for (int i = 0; i < this.controlPoints.Length - 1; i++)
        {
            setOfVectorSets[i] = CreateVectorsFromControlPoints(this.controlPoints[i], this.controlPoints[i + 1]);
        }
        return CreateBezierVectors(setOfVectorSets);
    }

    private Vector3[] CreateBezierVectors(Vector3[][] outerSetOfVectorSets)
    {
        if (outerSetOfVectorSets.Length == 2)
        {
            return CreateVectorsFromTwoSetsOfVectors(outerSetOfVectorSets[0], outerSetOfVectorSets[1]);
        }

        Vector3[][] innerSetOfVectorSets = new Vector3[outerSetOfVectorSets.Length - 1][];

        for (int i = 0; i < outerSetOfVectorSets.Length - 1; i++)
        {
            innerSetOfVectorSets[i] = CreateVectorsFromTwoSetsOfVectors(outerSetOfVectorSets[i], outerSetOfVectorSets[i + 1]);
        }

        return CreateBezierVectors(innerSetOfVectorSets);
    }

    // Create a set of vectors with each index representing a step in a collection interpolated values.
    private Vector3[] CreateVectorsFromTwoSetsOfVectors(Vector3[] a, Vector3[] b)
    {
        Vector3[] localVectors = new Vector3[this.accuracy];
        float t;
        for (int i = 0; i < this.accuracy; i++)
        {
            t = (i + 1f) / this.accuracy;
            localVectors[i] = LerpVectorsAtT(a[i], b[i], t);
        }
        return localVectors;
    }

    private Vector3[] CreateVectorsFromControlPoints(Vector3 a, Vector3 b)
    {
        Vector3[] localVectors = new Vector3[this.accuracy];
        float t;
        for (int i = 0; i < this.accuracy; i++)
        {
            t = (i + 1f) / this.accuracy;
            localVectors[i] = LerpVectorsAtT(a, b, t);
        }
        return localVectors;
    }

    //Interpolate two vectors 
    private Vector3 LerpVectorsAtT(Vector3 a, Vector3 b, float t)
    {
        return new Vector3
        (
            Mathf.Lerp(a.x, b.x, t),
            Mathf.Lerp(a.y, b.y, t),
            Mathf.Lerp(a.z, b.z, t)
        );
    }

    private void DrawDebugLineForVectors(Vector3[] vectors)
    {
        for (int i = 0; i < vectors.Length - 1; i++)
        {
            Debug.DrawLine(vectors[i], vectors[i + 1], Color.red, 100000, true);
        }
    }

    public Vector3[] GetBezierPoints() {
        return this.bezierPoints;
    }

    public void SetAccuracy(int accuracy){
        this.accuracy = accuracy;
    }
}