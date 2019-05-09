using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaCubeScript : MonoBehaviour
{
    GameController controller;

    private void Start() {
        controller = GameObject.Find("GameManager").GetComponent<GameController>();
    }

    private void OnCollisionEnter(Collision collision) {
        controller.GameOver();
        Destroy(collision.gameObject);
    }

}
