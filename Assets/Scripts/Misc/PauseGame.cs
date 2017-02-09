using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public bool paused;

    public GameObject escapeMenu;

	// Use this for initialization
	void Start ()
    {
        escapeMenu = GameObject.Find("EscapeMenu");
        escapeMenu.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        { 
            Pause();
            paused = true;
            escapeMenu.SetActive(true);
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused != false)
        {
            Resume();
            paused = false;
            escapeMenu.SetActive(false);
            Cursor.visible = false;
        }

    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
    public void ResumeButton()
    {
        Resume();
        paused = false;
        escapeMenu.SetActive(false);
        Cursor.visible = false;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void QuitToMain()
    {
        paused = false;
        escapeMenu.SetActive(false);
        Resume();
        SceneManager.LoadScene("menu");
    }
}
