using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    static bool gameDataExists = false;
    public static GameData singleton;
    int score = 0;
    public Text scoreText = null;

    private void Awake()
    {
        if(!gameDataExists)
        {
            DontDestroyOnLoad(this.gameObject);
            gameDataExists = true;
        }
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
