using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barrel : MonoBehaviour
{
    public GameObject mainText;
    public Text text;

    public GameObject player;
    public ItemEffects items;

    // Use this for initialization
    void Start()
    {
        mainText = GameObject.FindWithTag("text");
        text = mainText.GetComponent<Text>();

        player = GameObject.FindWithTag("Player");
        items = player.GetComponent<ItemEffects>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player && items.gotgloves == false)
        {
            text.text = "It's way too heavy to move...";
        }
    }
}
