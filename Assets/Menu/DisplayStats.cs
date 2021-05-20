using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
    public Text lastScore;
    public Text highestScore;

    private void OnEnable()
    {
        if(PlayerPrefs.HasKey("lastScore"))
        {
            lastScore.text = "Last Score : " + PlayerPrefs.GetInt("lastScore");
        }
        else
        {
            lastScore.text = "Last Score : 0";
        }

        if (PlayerPrefs.HasKey("highestScore"))
        {
            highestScore.text = "Highest Score : " + PlayerPrefs.GetInt("highestScore");
        }
        else
        {
            highestScore.text = "Highest Score : 0";
        }
    }
}
