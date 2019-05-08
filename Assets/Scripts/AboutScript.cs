using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AboutScript : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public Text text3;
    float time = 0;

    void Update()
    {
        time += Time.deltaTime;
        if(time>0.8) {
            time = 0;
            string tmp = text3.text;
            text3.text = text2.text;
            text2.text = text1.text;
            text1.text = tmp;
        }
    }

    public void backMenu() {
        SceneManager.LoadScene(0);
    }
}
