using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaCubeScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        Debug.Log("OYUN BİTTİ!!!");
        Destroy(collision.gameObject);
    }

}
