using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class TextInteractions : MonoBehaviour {

    public Text text1;
    public float fadeTime;
    public bool displayInfo;
    public GameObject DialogBox;
    private float startTime;
    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 5.0f;

    // Use this for initialization
    void Start () {
        DialogBox = GameObject.Find("DialogFrame");
        DialogBox.SetActive(false);
        startTime = Time.time;
        text1 = GameObject.Find("text1").GetComponent<Text>();
        text1.color = Color.clear;
    }

    IEnumerator Pause ()
    {
        yield return new WaitForSecondsRealtime(2);
        text1.color = Color.Lerp(text1.color, Color.clear, fadeTime * Time.deltaTime);
        DialogBox.SetActive(false);
        displayInfo = false;
    }

    void Update () {
    }

    void OnTriggerStay2D(Collider2D interCollider)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DialogBox.SetActive(true);
            displayInfo = true;
        }
        FadeText();
    }

    void FadeText()
    {
        if (displayInfo == true)
        {
            text1.color = Color.Lerp(text1.color, Color.white, fadeTime * Time.deltaTime /5f);
            StartCoroutine(Pause());
        }
    }
}
