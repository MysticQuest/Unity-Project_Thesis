using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class TextInteractions3 : MonoBehaviour
{

    public Text text3;
    public float fadeTime;
    public bool displayInfo;
    public GameObject DialogBox;
    private float startTime;
    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 5.0f;

    public ItemEffects items;

    //public GameObject sign;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        items = player.GetComponent<ItemEffects>();

        DialogBox = GameObject.Find("DialogFrame3");
        DialogBox.SetActive(false);
        startTime = Time.time;
        text3 = GameObject.Find("text3").GetComponent<Text>();
        text3.color = Color.clear;
    }

    IEnumerator Pause()
    {
        yield return new WaitForSecondsRealtime(2);
        text3.color = Color.Lerp(text3.color, Color.clear, fadeTime * Time.deltaTime);
        DialogBox.SetActive(false);
        displayInfo = false;
    }

    void Update()
    {
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            if (items.gotgloves == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    DialogBox.SetActive(true);
                    displayInfo = true;
                }
            }
        }
        FadeText();
    }

    void FadeText()
    {
        if (displayInfo == true)
        {
            text3.color = Color.Lerp(text3.color, Color.white, fadeTime * Time.deltaTime / 5f);
            StartCoroutine(Pause());
        }
    }
}
