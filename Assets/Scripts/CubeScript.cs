using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {

    public Material shieldMat;
    public Material soilMat;
    Renderer rend;
    BoxCollider collider;

    void Start() {
        rend = GetComponent<Renderer>();
        collider = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision) {
        
        if(this.tag == "SoilTag") {
            if(collision.gameObject.tag == "HealthBall") {
                this.tag = "Shield";
                rend.material = shieldMat;
            }
            else if(collision.gameObject.tag == "RocketTag") {
                this.tag = "DamagedCube";
                collider.isTrigger = true;
                rend.enabled = false;
            }
            else if(collision.gameObject.tag == "NuclearTag") {
                //Oyunu bitir.
                Debug.Log("Nuclear Çarptı.");
            }
            Destroy(collision.gameObject);
        }
        else if(this.tag == "Shield") {
            if (collision.gameObject.tag == "HealthBall") {
                //Puan ekle.

            }
            else if (collision.gameObject.tag == "RocketTag") {
                //Hasar almaz. Puan ekle.
            }
            else if (collision.gameObject.tag == "NuclearTag") {
                this.tag = "SoilTag";
                rend.material = soilMat;
            }
            Destroy(collision.gameObject);
        }
        else if (this.tag == "DamagedCube") {
            if (collision.gameObject.tag == "HealthBall") {
                this.tag = "SoilTag";
                rend.material = soilMat;
                collider.isTrigger = false;
                rend.enabled = true;
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "RocketTag") {
                //Arkadaki lavaCube'a geçeçek. İşlem yapma.

            }
            else if (collision.gameObject.tag == "NuclearTag") {
                //Arkadaki lavaCube'a geçeçek. İşlem yapma.
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
                Destroy(other.gameObject);
            }
            else if (other.gameObject.tag == "RocketTag") {
                //Arkadaki lavaCube'a geçeçek. İşlem yapma.

            }
            else if (other.gameObject.tag == "NuclearTag") {
                //Arkadaki lavaCube'a geçeçek. İşlem yapma.
            }
        }


    }



}
