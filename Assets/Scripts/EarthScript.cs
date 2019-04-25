using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthScript : MonoBehaviour {

    public GameObject soilCube;
    public GameObject kernelCube;
    public GameObject star;
    public int yaricap;
    public float rotSpeed = 20;
    bool drag = false;
    public int starCount = 5000;


    void Start() {
        //Dünyanın oluşturulması
        Debug.Log("Başlatıldı.");
        int x, y, z;
        for (x = -yaricap; x <= yaricap; x++)
            for (y = -yaricap; y <= yaricap; y++)
                for (z = -yaricap; z <= yaricap; z++) {
                    float dist = Mathf.Sqrt(x * x + y * y + z * z);
                    if (dist < yaricap && yaricap - dist <= 1) {
                        GameObject tmp = Instantiate(soilCube, new Vector3(x, y, z), new Quaternion(0, 0, 0, 0));
                        tmp.transform.SetParent(gameObject.transform);
                    }
                    else if (yaricap - dist > 1 && yaricap - dist <= 2) {
                        GameObject tmp = Instantiate(kernelCube, new Vector3(x, y, z), new Quaternion(0, 0, 0, 0));
                        tmp.transform.SetParent(gameObject.transform);
                    }
                }

        int i, j;
        for (i=0; i<starCount; i++) {
            Vector3 aci = new Vector3(Random.value-0.5f, Random.value-0.5f, Random.value-0.5f);
            aci *= Random.Range(80, 200) / aci.magnitude;
            GameObject tmp = Instantiate(star, aci, new Quaternion(0, 0, 0, 0));
        }

    }

    void Update() {

        if (Input.GetKey(KeyCode.A)) {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.up, 4);
        }
        if (Input.GetKey(KeyCode.D)) {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.down, 4);
        }
        if (Input.GetKey(KeyCode.W)) {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.right, 4);
        }
        if (Input.GetKey(KeyCode.S)) {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.left, 4);
        }

        if(Input.GetMouseButtonDown(0)) {
            drag = true;
        }

        if (Input.GetMouseButtonUp(0))
            drag = false;

        if(drag) {
            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

            transform.RotateAround(Vector3.zero, Vector3.up, -rotX);
            transform.RotateAround(Vector3.zero, Vector3.right, rotY);        
        }


    }

}
