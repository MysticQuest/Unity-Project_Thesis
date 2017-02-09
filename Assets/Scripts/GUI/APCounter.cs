using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class APCounter : MonoBehaviour
{
    public PlayerAttack playerAttack;
    public GameObject player;
    public Text text;
    public GameObject apcounter;

    public int damage;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindWithTag("Player");
        apcounter = GameObject.Find("APCounter");

        text = apcounter.GetComponent<Text>();
        playerAttack = player.GetComponent<PlayerAttack>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        damage = playerAttack.damage;
        text.text ="" + playerAttack.damage;
    }
}
