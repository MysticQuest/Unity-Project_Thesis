using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RupieCounter : MonoBehaviour
{
    public ItemEffects items;
    public GameObject player;
    public Text text;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindWithTag("Player");
        text = GetComponent<Text>();
        items = player.GetComponent<ItemEffects>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        text.text ="" + items.rupies;
	}
}
