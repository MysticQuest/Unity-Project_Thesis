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

    //public GameObject musicplayer;
    //public AudioSource music;

    // Use this for initialization
    void Start() {
        explosion = GameObject.Find("explosion");
        currentHealth = maxHealth;
        anim = explosion.GetComponent<Animator>();

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
        Destroy(gameObject);
    }


}
