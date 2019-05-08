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

    private const float zoomSpeed = 350f;
	private const int minDistanceToEarth = 20;
	private const int maxDistanceToEarth = 120;

    void Start()
    {
        newPosition = transform.position;
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
        if (scrollAxis != 0f) { 
            Debug.Log(scrollAxis);
            zoomSpeed2 =  1.2f * (1 + Mathf.Abs(scrollAxis));
            Vector3 direction = (-transform.position*scrollAxis).normalized * zoomSpeed2;
			Vector3 tempPosition = transform.position + direction * zoomSpeed * Time.deltaTime;
			float distanceToEarth = tempPosition.magnitude;
			if(distanceToEarth < maxDistanceToEarth && distanceToEarth > minDistanceToEarth)
				newPosition = tempPosition;
		}

        if(transform.position != newPosition) {
            Vector3 direction = (newPosition - transform.position).normalized * zoomSpeed2;
            transform.position += direction;
            if (Vector3.Distance(transform.position, newPosition) < 1f)
                transform.position = newPosition;
        }
        

    }
}
