using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int score;
    public Text ScoreText;
    public Text GameOverText;
    bool isGameOver = false;
    float timer = 0;

    void Start()
    {
        
    }

    void Update() {

        timer += Time.deltaTime;

        if (isGameOver && timer > 3)
            SceneManager.LoadScene(0);
  
    }

    public void addScore(int score) {
        this.score += score;
        ScoreText.text = "Score : " + this.score;
    }

    public void GameOver() {
        timer = 0;
        isGameOver = true;
        this.gameObject.GetComponent<RandomObjectManager>().enabled = false;
        destroyObjects("HealthBall");
        destroyObjects("RocketTag");
        destroyObjects("NuclearTag");
        GameOverText.enabled = true;
        if (score > PlayerPrefs.GetInt("Score"))
            PlayerPrefs.SetInt("score", score);
    }

    private void destroyObjects(string tag) {
        GameObject[] items = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject item in items) {
            Destroy(item); 
        }
    }



}
