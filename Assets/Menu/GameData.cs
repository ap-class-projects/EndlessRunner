using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    public static GameData singleton;
    int score = 0;
    public Text scoreText = null;

    private void Awake()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("GameData");
        if(gameObjects.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        singleton = this;

        PlayerPrefs.SetInt("score", 0);
    }

    public void updateScore(int score)
    {
        this.score += score;
        PlayerPrefs.SetInt("score", this.score);
        if(scoreText != null)
        {
            scoreText.text = $"Score : {this.score}";
        }

    }
}
