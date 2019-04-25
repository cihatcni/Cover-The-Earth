using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectManager : MonoBehaviour
{

    public GameObject healthBall;
    public GameObject rocket;
    public GameObject nuclearBomb;
    public GameObject earth;

    public int distance = 230;
    public float randomRangeHealth = 0.04f;
    public float randomRangeRocket = 0.05f;
    public float randomRangeNuclear = 0.01f;

    void Start() {

 
    }

    void Update() {

        if (Random.value < randomRangeHealth)
            createObject(healthBall);

        if (Random.value < randomRangeNuclear)
            createObject(nuclearBomb);

        if (Random.value < randomRangeRocket)
            createObject(rocket);


    }

    void createObject(GameObject obj) {

        float x = -5 + Random.value * 10;
        float y = -5 + Random.value * 10;
        float z = -5 + Random.value * 10;
        float dist = x * x + y * y + z * z;
        float carp = distance / dist;
        
        x *= carp;
        y *= carp;
        z *= carp;
        GameObject gameObject = Instantiate(obj, new Vector3(x, y, z), Quaternion.identity);
    }

}
