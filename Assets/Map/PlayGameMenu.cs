using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameMenu : MonoBehaviour
{
    public void quitToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        PlayerPrefs.SetInt("lastScore", PlayerPrefs.GetInt("score"));
        if (PlayerPrefs.HasKey("highestScore"))
        {
            if (PlayerPrefs.GetInt("highestScore") < PlayerPrefs.GetInt("score"))
            {
                PlayerPrefs.SetInt("highestScore", PlayerPrefs.GetInt("score"));
            }
        }
        else
        {
            PlayerPrefs.SetInt("highestScore", PlayerPrefs.GetInt("score"));
        }
    }

}
