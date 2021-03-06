﻿using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class TextInteractions4 : MonoBehaviour
{

    public Text text4;
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

        DialogBox = GameObject.Find("DialogFrame4");
        DialogBox.SetActive(false);
        startTime = Time.time;
        text4 = GameObject.Find("text4").GetComponent<Text>();
        text4.color = Color.clear;
    }

    IEnumerator Pause()
    {
        yield return new WaitForSecondsRealtime(2);
        text4.color = Color.Lerp(text4.color, Color.clear, fadeTime * Time.deltaTime);
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
            if (items.gotmanual == false)
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
            text4.color = Color.Lerp(text4.color, Color.white, fadeTime * Time.deltaTime / 5f);
            StartCoroutine(Pause());
        }
    }
}
