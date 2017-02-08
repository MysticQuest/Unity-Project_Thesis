using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSword : MonoBehaviour
{

    public Animator anim;
    public GameObject player;
    public ItemEffects items;
    public PlayerAttack attack;
    public bool upgraded = false;

    public AudioSource effectplayer;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        anim = player.GetComponent<Animator>();
        items = player.GetComponent<ItemEffects>();
        attack = player.GetComponent<PlayerAttack>();
        effectplayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            if (items.gotmanual == true)
            {
                if (Input.GetKeyDown(KeyCode.E) && upgraded == false)
                {
                    effectplayer.Play();
                    anim.SetBool("Upgraded", true);
                    upgraded = true;
                    attack.damage += 17;
                }
            }
        }
    }
}
