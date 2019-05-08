using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    bool drag = false;
    public float rotSpeed = 20f;
    Vector3 newPosition;
    public float time = 0;
    public float timeRange;
    private float zoomSpeed2 = 1f;

	private const int minDistanceToEarth = 18;
	private const int maxDistanceToEarth = 125;
	
	private float newDistance;
	

    void Start()
    {
		newDistance = transform.position.magnitude;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(1)) {
            drag = true;
        }

        if (Input.GetMouseButtonUp(1))
            drag = false;

        if (drag) {
            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

            transform.RotateAround(Vector3.zero, Vector3.up, -rotX);
            transform.RotateAround(Vector3.zero, Vector3.right, rotY);

            transform.LookAt(Vector3.zero);
			newPosition = transform.position;
        }
		
		float scrollAxis = Input.GetAxis("Mouse ScrollWheel");
        if (scrollAxis != 0f) { 
			Debug.Log(scrollAxis);
			float sign = -Mathf.Sign(scrollAxis);
			newDistance += sign*(sign+scrollAxis)*(sign+scrollAxis)*11;
			newDistance = Mathf.Clamp(newDistance, minDistanceToEarth, maxDistanceToEarth);
		}    
		
		float currentDistance = transform.position.magnitude;
		currentDistance = currentDistance+(newDistance-currentDistance)/5;
		transform.position = currentDistance*transform.position.normalized;   
    }
}
