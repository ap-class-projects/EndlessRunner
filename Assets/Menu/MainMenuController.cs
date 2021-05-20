using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    GameObject[] panels;
    GameObject[] mainMenuButtons;

    public void loadGameScene()
    {
        AstroController.isDead = false;
        SceneManager.LoadScene("PlayGame", LoadSceneMode.Single);
    }

    public void Start()
    {
        panels = GameObject.FindGameObjectsWithTag("subPanel");
        mainMenuButtons = GameObject.FindGameObjectsWithTag("mmButton");

        foreach(GameObject p in panels)
        {
            p.SetActive(false);
        }

    }

    public void closePanel(Button button)
    {
        button.gameObject.transform.parent.gameObject.SetActive(false);
        foreach (GameObject b in mainMenuButtons)
        {
            b.SetActive(true);
        }
    }

    public void openPanel(Button button)
    {
        button.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        foreach (GameObject b in mainMenuButtons)
        {
            if(b != button.gameObject)
            {
                b.SetActive(false);
            }
        }
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
 