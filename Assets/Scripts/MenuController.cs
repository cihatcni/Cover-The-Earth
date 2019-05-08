using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text scoreText;

    void Start() {
        int score = PlayerPrefs.GetInt("score");
        scoreText.text = "High Score : " + score;
    }

    public void startGame() {
        SceneManager.LoadScene("level0");
    }

    public void exitGame() {
        Application.Quit();
    }

    public void startTutorial() {
        SceneManager.LoadScene("tutorial");
    }

}
