using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPanel : MonoBehaviour
{
    public GameObject icon1;
    public GameObject icon2;
    public GameObject icon3;
    public GameObject icon4;
    public GameObject icon5;
    public GameObject icon6;

    public bool gotkey;
    public bool gotgloves;
    public bool gotboots;
    public bool gotplate;
    public bool gotmanual;
    public bool gotcape;

    public ItemEffects items;
    public GameObject player;


    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindWithTag("Player");
        items = player.GetComponent<ItemEffects>();

        icon1 = GameObject.Find("ItemPanel/icon1");
        icon2 = GameObject.Find("ItemPanel/icon2");
        icon3 = GameObject.Find("ItemPanel/icon3");
        icon4 = GameObject.Find("ItemPanel/icon4");
        icon5 = GameObject.Find("ItemPanel/icon5");
        icon6 = GameObject.Find("ItemPanel/icon6");

        icon1.SetActive(false);
        icon2.SetActive(false);
        icon3.SetActive(false);
        icon4.SetActive(false);
        icon5.SetActive(false);
        icon6.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        gotkey = items.gotkey;
        gotgloves = items.gotgloves;
        gotboots = items.gotboots;
        gotplate = items.gotplate;
        gotmanual = items.gotmanual;
        gotcape = items.gotcape;

        if (gotkey == true)
        {
            icon1.SetActive(true);
        }
        if (gotgloves == true)
        {
            icon2.SetActive(true);
        }
        if (gotboots == true)
        {
            icon3.SetActive(true);
        }
        if (gotmanual == true)
        {
            icon4.SetActive(true);
        }
        if (gotplate == true)
        {
            icon5.SetActive(true);
        }
        if (gotcape == true)
        {
            icon6.SetActive(true);
        }
	} 
}
