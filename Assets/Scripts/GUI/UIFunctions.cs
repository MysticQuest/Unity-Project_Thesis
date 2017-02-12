using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIFunctions : MonoBehaviour
{
    public GameObject black;
    public Image image;

    void Start()
    {
        black = GameObject.Find("Black");
        image = black.GetComponent<Image>();

        image.canvasRenderer.SetAlpha(255f);
        image.CrossFadeAlpha(1f, 1, false);
    }

    void Update()
    {

    }


    public void StartGame()
    {
        image.CrossFadeAlpha(255f, 1f, false);
        Invoke("Load", 1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Load()
    {
        SceneManager.LoadScene("scene1");
    }
}

