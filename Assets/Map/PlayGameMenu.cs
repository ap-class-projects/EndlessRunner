using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameMenu : MonoBehaviour
{
    public void quitToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

}
