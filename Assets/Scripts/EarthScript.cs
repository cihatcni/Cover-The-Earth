using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthScript : MonoBehaviour {

    public GameObject soilCube;
    public GameObject seaCube;
    public GameObject kernelCube;
    public GameObject star;
    public int yaricap;
    public float rotSpeed = 20;
    bool drag = false;
    public int starCount = 5000;
	
	public int greenCounter = 0;
	public bool isGreen = false;
	public Dictionary<Vector3, bool> isGreenDict = new Dictionary<Vector3, bool>();

    void Start() {
        //Dünyanın oluşturulması
        Debug.Log("Başlatıldı.");
        int x, y, z;
        for (x = -yaricap; x <= yaricap; x++)
            for (y = -yaricap; y <= yaricap; y++)
                for (z = -yaricap; z <= yaricap; z++) {
                    float dist = Mathf.Sqrt(x * x + y * y + z * z);
                    if (dist < yaricap && yaricap - dist <= 1) {
						Vector3 pos = new Vector3(x,y,z);
						bool closestGreen = isClosestCubeGreen(pos);
						isGreen = closestGreen ? (Random.value<0.70f) : (Random.value<0.05f);
						if(closestGreen)
							greenCounter++;
						if(greenCounter == 6) {
							greenCounter = 0;
							isGreen = false;
						}
						
						isGreenDict.Add(pos, isGreen);
                        GameObject tmp = Instantiate(isGreen ? soilCube : seaCube, new Vector3(x, y, z), new Quaternion(0, 0, 0, 0));
                        tmp.transform.SetParent(gameObject.transform);
                    }
                    else if (yaricap - dist > 1 && yaricap - dist <= 2) {
                        GameObject tmp = Instantiate(kernelCube, new Vector3(x, y, z), new Quaternion(0, 0, 0, 0));
                        tmp.transform.SetParent(gameObject.transform);
                    }
                }

        GameObject stars = GameObject.Find("Stars");
        int i, j;
        for (i=0; i<starCount; i++) {
            Vector3 aci = new Vector3(Random.value-0.5f, Random.value-0.5f, Random.value-0.5f);
            aci *= Random.Range(80, 200) / aci.magnitude;
            GameObject tmp = Instantiate(star, aci, new Quaternion(0, 0, 0, 0));
            tmp.transform.SetParent(stars.transform);
        }

    }
	
	public bool isClosestCubeGreen(Vector3 pos) {
		bool temp = false;
		int cogunluk = 0;
		foreach(KeyValuePair<Vector3, bool> entry in isGreenDict) {
			float dist = Vector3.Distance(entry.Key, pos);
			if(dist < 1.45f) {
				if(entry.Value)
					cogunluk++;
				else
					cogunluk--;
			}
		}
		return cogunluk >= 0;
	}

    void Update() {

        if(Input.GetMouseButtonDown(0)) {
            drag = true;
        }

        if (Input.GetMouseButtonUp(0))
            drag = false;

        if(drag) {
            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
			
            transform.RotateAround(Vector3.zero, Camera.main.transform.up, -rotX);
            transform.RotateAround(Vector3.zero, Camera.main.transform.right, rotY);
				
			
        }
	}

}
