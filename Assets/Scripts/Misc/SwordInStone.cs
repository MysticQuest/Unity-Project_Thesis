using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordInStone : MonoBehaviour {

    public Animator anim;
    public GameObject player;
    public ItemEffects items;
    public PlayerAttack attack;
    public bool gotstone = false;

    public AudioSource effectplayer;

    public PlayerMovement pmove;

    public GameObject mainText;
    public Text text;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindWithTag("Player");
        anim = player.GetComponent<Animator>();
        items = player.GetComponent<ItemEffects>();
        attack = player.GetComponent<PlayerAttack>();
        effectplayer = GetComponent<AudioSource>();

        pmove = player.GetComponent<PlayerMovement>();

        mainText = GameObject.FindWithTag("text");
        text = mainText.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            if (Input.GetKeyDown(KeyCode.E) && gotstone == false)
            {
                if (items.gotgloves == true)
                {
                    effectplayer.Play();
                    anim.SetBool("HasSword", true);
                    gotstone = true;
                    pmove.enabled = false;
                    anim.enabled = false;
                    attack.damage += 10;
                    //anim.Play("Idle.idle_down");
                    Invoke("Unfreeze",4);
                    Destroy(gameObject,4);
                }
                else
                {
                    text.text = "I am not strong enough to pull it out of the stone...";
                }
            }
        }
    }

    void Unfreeze()
    {
        pmove.enabled = true;
        anim.enabled = true;
    }
}
