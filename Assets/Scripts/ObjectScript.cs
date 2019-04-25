using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour  {

    float timer;

    void Start()
    {
        
        int distance = GameObject.Find("GameManager").GetComponent<RandomObjectManager>().distance;
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        float speed;
        if (tag == "NuclearTag") 
            speed = 10;   
        else 
            speed = 20 + Random.value * 20;     

        rigidbody.velocity = new Vector3(-speed * transform.position.x / distance, -speed * transform.position.y / distance, -speed * transform.position.z / distance);
        transform.up = rigidbody.velocity;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer>0.01) {
            transform.Rotate(new Vector3(0, 10, 0));
            timer = 0;
        }

    }
}
