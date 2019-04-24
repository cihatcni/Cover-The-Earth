using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthScript : MonoBehaviour {

    public GameObject soilCube;
    public GameObject kernelCube;
    public int yaricap;


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

    }

    void Update() {
        
    }
}
