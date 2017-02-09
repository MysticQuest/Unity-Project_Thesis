using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactables : MonoBehaviour
{

    public GameObject player;
    public ItemEffects items;
    public PlayerAttack attack;

    public GameObject barrel;
    public Rigidbody2D barrelmass;

    public AudioSource effectplayer;

    public Text text;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        effectplayer = GetComponent<AudioSource>();
        items = player.GetComponent<ItemEffects>();
        attack = player.GetComponent<PlayerAttack>();

        barrel = GameObject.FindWithTag("barrel");
        barrelmass = barrel.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (items.gotkey == true && items.gotgloves == false)
                {
                    effectplayer.Play();
                    attack.damage += 3;
                    barrelmass.mass = 0.5f;
                    items.gotgloves = true;
                }
            }
        }
    }
}
