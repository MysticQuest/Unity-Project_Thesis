using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseHealth : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth;
    public bool isDead;
    public bool isDamaged;

    public Animator anim;
    public GameObject explosion;

    public GameObject hfire1;
    public GameObject hfire2;
    public GameObject hfire3;

    public AudioSource boom;

    //public GameObject musicplayer;
    //public AudioSource music;

    // Use this for initialization
    void Start() {
        explosion = GameObject.Find("explosion");
        currentHealth = maxHealth;
        anim = explosion.GetComponent<Animator>();

        hfire1 = GameObject.Find("housefire1");
        hfire2 = GameObject.Find("housefire2");
        hfire3 = GameObject.Find("housefire3");

        boom = explosion.GetComponent<AudioSource>();

        //musicplayer = GameObject.Find("MusicPlayer");
        //music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (maxHealth/currentHealth > 1.2f)
        {
            hfire1.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            hfire1.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (maxHealth / currentHealth > 2f)
        {
            hfire2.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            hfire2.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (maxHealth / currentHealth > 3.5f)
        {
            hfire3.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            hfire3.GetComponent<SpriteRenderer>().enabled = false;
        }

    }

    public void Damaged(int damage)
    {
        isDamaged = true;
        currentHealth -= damage;
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    public void Death()
    {
        isDead = true;
        anim.SetTrigger("Destroyed");
        boom.Play();
        Destroy(gameObject,0.5f);
    }


}
