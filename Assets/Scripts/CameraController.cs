using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    bool drag = false;
    public float rotSpeed = 20f;
    
	private const float zoomSpeed = 350f;
	private const int minDistanceToEarth = 20;
	private const int maxDistanceToEarth = 120;

    void Start()
    {
        
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
			
        }
		
		float scrollAxis = Input.GetAxis("Mouse ScrollWheel");
		if(scrollAxis != 0f) {
			Vector3 direction = (-transform.position*scrollAxis).normalized;
			Vector3 newPosition = transform.position + direction * zoomSpeed * Time.deltaTime;
			float distanceToEarth = newPosition.magnitude;
			Debug.Log(""+distanceToEarth);
			if(distanceToEarth < maxDistanceToEarth && distanceToEarth > minDistanceToEarth)
				transform.position = newPosition;
		}

    }
}
