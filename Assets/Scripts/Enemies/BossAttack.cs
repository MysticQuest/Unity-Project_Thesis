using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Boss stuff;
    public GameObject boss;
    public GameObject player;
    public GameObject house;

    public Animator animlight;
    public Animator anim;

    public float lightcd = 10;
    //public float animtimer = 0;
    public int damage = 1;

    public PlayerHealth playerHealth;
    public HouseHealth houseHealth;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindWithTag("Player");
        house = GameObject.FindWithTag("HouseHitbox");
        boss = GameObject.Find("Boss");

        playerHealth = player.GetComponent<PlayerHealth>();
        houseHealth = house.GetComponent<HouseHealth>();

        animlight = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        stuff = boss.GetComponent<Boss>();
        anim = boss.GetComponent<Animator>();
        //animtimer += Time.deltaTime;

        if ( stuff.timerCooldown > 4 && anim.GetBool("IsAttacking") == true)
        {
            animlight.Play("bosslight");
            //animtimer = 0;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerHealth.Damaged(damage);
        }
        else if (other.gameObject == house)
        {
            houseHealth.Damaged(damage);
        }
    }
}
