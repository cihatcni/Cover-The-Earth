using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    bool drag = false;
    public float rotSpeed = 20f;

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

    }
}
