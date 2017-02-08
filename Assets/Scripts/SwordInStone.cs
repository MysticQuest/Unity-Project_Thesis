using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordInStone : MonoBehaviour {

    public Animator anim;
    public GameObject player;
    public ItemEffects items;
    public PlayerAttack attack;
    public bool gotstone = false;

    public AudioSource effectplayer;

    public PlayerMovement pmove;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindWithTag("Player");
        anim = player.GetComponent<Animator>();
        items = player.GetComponent<ItemEffects>();
        attack = player.GetComponent<PlayerAttack>();
        effectplayer = GetComponent<AudioSource>();

        pmove = player.GetComponent<PlayerMovement>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            if (items.gotgloves == true)
            {
                if (Input.GetKeyDown(KeyCode.E) && gotstone == false)
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
            }
        }
    }

    void Unfreeze()
    {
        pmove.enabled = true;
        anim.enabled = true;
    }
}
