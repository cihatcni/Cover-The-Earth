using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {

    public Material shieldMat;
    public Material soilMat;
    Renderer rend;
    BoxCollider collider;
    GameController controller;

    void Start() {
        rend = GetComponent<Renderer>();
        collider = GetComponent<BoxCollider>();
        controller = GameObject.Find("GameManager").GetComponent<GameController>();
    }

    private void OnCollisionEnter(Collision collision) {
        
        if(this.tag == "SoilTag") {
            if(collision.gameObject.tag == "HealthBall") {
                this.tag = "Shield";
                rend.material = shieldMat;
                controller.addScore(5);                
            }
            else if(collision.gameObject.tag == "RocketTag") {
                this.tag = "DamagedCube";
                collider.isTrigger = true;
                rend.enabled = false;
            }
            else if(collision.gameObject.tag == "NuclearTag") {
                controller.GameOver();
            }
            this.gameObject.GetComponentInParent<AudioSource>().clip = collision.gameObject.GetComponent<AudioSource>().clip;
            this.gameObject.GetComponentInParent<AudioSource>().Play();
            Destroy(collision.gameObject);
        }
        else if(this.tag == "Shield") {
            if (collision.gameObject.tag == "HealthBall") {
                controller.addScore(23);
            }
            else if (collision.gameObject.tag == "RocketTag") {
                controller.addScore(7);         
            }
            else if (collision.gameObject.tag == "NuclearTag") {
                this.tag = "SoilTag";
                rend.material = soilMat;
            }
            this.gameObject.GetComponentInParent<AudioSource>().clip = collision.gameObject.GetComponent<AudioSource>().clip;
            this.gameObject.GetComponentInParent<AudioSource>().Play();
            Destroy(collision.gameObject);
        }
        else if (this.tag == "DamagedCube") {
            if (collision.gameObject.tag == "HealthBall") {
                this.tag = "SoilTag";
                rend.material = soilMat;
                collider.isTrigger = false;
                rend.enabled = true;
                this.gameObject.GetComponentInParent<AudioSource>().clip = collision.gameObject.GetComponent<AudioSource>().clip;
                this.gameObject.GetComponentInParent<AudioSource>().Play();
                Destroy(collision.gameObject);
            }
        }

    }

    private void OnTriggerEnter(Collider other) {
        if (this.tag == "DamagedCube") {
            if (other.gameObject.tag == "HealthBall") {
                this.tag = "SoilTag";
                rend.material = soilMat;
                collider.isTrigger = false;
                rend.enabled = true;
                this.gameObject.GetComponentInParent<AudioSource>().clip = other.gameObject.GetComponent<AudioSource>().clip;
                this.gameObject.GetComponentInParent<AudioSource>().Play();
                Destroy(other.gameObject);
            }
        }


    }




}
