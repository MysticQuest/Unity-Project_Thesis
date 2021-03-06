﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{

    public Light lighting;
    public Color blue;
    public Color red;
    public Color yellow;
    public float timer;
    public int x;
    public int day;

    // Use this for initialization
    void Start()
    {
        lighting = GetComponent<Light>();
        lighting.intensity = 0;
        blue = Color.blue;
        red = Color.red;
        yellow = Color.yellow;
        day = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer < 35f) x = 1;
        if (timer > 35f) x = 2;
        if (timer > 70f) x = 3;
        if (timer > 105f) x = 4;
        if (timer > 140f) x = 5;
        if (timer > 180f) x = 6;
        if (timer > 215f) x = 7;
        if (day > 2 && timer > 105f) x = 8;

        switch (x)
        {
            case 1:
                lighting.color = yellow;
                lighting.intensity += 0.015f * Time.deltaTime;
                break;
            case 2:
                //
                break;
            case 3:
                lighting.intensity -= 0.015f * Time.deltaTime;
                break;
            case 4:
                lighting.color = blue;
                lighting.intensity += 0.02f * Time.deltaTime;
                break;
            case 5:
                //
                break;
            case 6:
                lighting.intensity -= 0.02f * Time.deltaTime;
                break;
            case 7:
                timer = 0;
                day += 1;
                Debug.Log("Day - " + day);
                break;
            case 8:
                lighting.color = red;
                if (lighting.intensity < 0.85f)
                {
                    lighting.intensity += 0.03f * Time.deltaTime;
                }
                break;
        }
    }
}
