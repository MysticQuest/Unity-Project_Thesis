using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordInStone : MonoBehaviour {

    public Animator anim;
    public GameObject player;
    public ItemEffects items;
    public PlayerAttack attack;
    public bool gotstone = false;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindWithTag("Player");
        anim = player.GetComponent<Animator>();
        items = player.GetComponent<ItemEffects>();
        attack = player.GetComponent<PlayerAttack>();
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
                    anim.SetBool("HasSword", true);
                    gotstone = true;
                    attack.damage += 10;
                    Destroy(gameObject);
                }
            }
        }
    }
}
