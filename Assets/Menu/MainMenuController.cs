using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject helpPanel; 
    public void loadGameScene()
    {
        SceneManager.LoadScene("PlayGame", LoadSceneMode.Single);
    }

    public void Start()
    {
        helpPanel.SetActive(false);
    }

    public void closeHelpPanel()
    {
        helpPanel.SetActive(false);
    }

    public void openHelpPanel()
    {
        helpPanel.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if(Input.GetKey("escape"))
        {
            quitGame();
        }
    }
}
 