using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundObject : MonoBehaviour
{
    public Transform target;
    public Camera mainCamera;
    public float distance;
    public float heightDifference;
    public float radius;
    public float rotationSpeed;
	Vector3 newPosition;

    // Use this for initialization
    void Start()
    {
		newPosition = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
		SimpleMoveAroundTarget();
        PointCameraAtTarget();
    }

    void PointCameraAtTarget()
    {
        this.mainCamera.transform.LookAt(target);
    }

    // Move Camera's postion in a circular path around the target along the X Z plane of the target.  Future versions maybe circle around the object at a variable distance, spherically around the tartget, or cylindrically around the target.
    void SimpleMoveAroundTarget()
    {
		newPosition.Set(
            target.position.x + radius * Mathf.Cos(Time.realtimeSinceStartup * this.rotationSpeed),
            target.position.y + heightDifference,
            target.position.z + radius * Mathf.Sin(Time.realtimeSinceStartup * this.rotationSpeed)
		);
		this.mainCamera.transform.position = newPosition;
    }
}
