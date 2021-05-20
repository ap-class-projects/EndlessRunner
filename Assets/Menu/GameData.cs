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
    }

    public void updateScore(int score)
    {
        this.score += score;
        if(scoreText != null)
        {
            scoreText.text = "Score : " + this.score;
        }
    }
}
