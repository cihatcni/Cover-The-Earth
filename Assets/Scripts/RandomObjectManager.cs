using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectManager : MonoBehaviour
{

    public GameObject healthBall;
    public GameObject rocket;
    public GameObject nuclearBomb;

    public int distance = 230;
    public float randomRangeHealth;
    public float randomRangeRocket;
    public float randomRangeNuclear;
    int lastScore;
    GameController gc;

    void Start() {
        gc = GameObject.Find("GameManager").GetComponent<GameController>();
        lastScore = 0;
    }


    void Update() {

        int score = gc.getScore();
        if((score-lastScore) > 100) {
            lastScore = score;
            randomRangeHealth += 0.001f;
            randomRangeNuclear += 0.0005f;
            randomRangeRocket += 0.001f;
        }

        if (Random.value < randomRangeHealth)
            createObject(healthBall);

        if (Random.value < randomRangeNuclear && score > 100)
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
