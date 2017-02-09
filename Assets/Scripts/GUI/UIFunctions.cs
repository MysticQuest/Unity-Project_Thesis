using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIFunctions : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("scene1");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
