using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSword : MonoBehaviour
{

    public Animator anim;
    public GameObject player;
    public ItemEffects items;
    public PlayerAttack attack;
    public bool upgraded = false;

    public AudioSource effectplayer;

    public GameObject mainText;
    public Text text;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        anim = player.GetComponent<Animator>();
        items = player.GetComponent<ItemEffects>();
        attack = player.GetComponent<PlayerAttack>();
        effectplayer = GetComponent<AudioSource>();

        mainText = GameObject.FindWithTag("text");
        text = mainText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            if (Input.GetKeyDown(KeyCode.E) && upgraded == false)
            {
                if (items.gotmanual == true)
                {
                    effectplayer.Play();
                    anim.SetBool("Upgraded", true);
                    upgraded = true;
                    attack.damage += 17;
                }
                else
                {
                    text.text = "I don't know how to use this...";
                }
            }
        }
    }
}
