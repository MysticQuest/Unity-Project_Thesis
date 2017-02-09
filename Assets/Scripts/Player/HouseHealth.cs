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


    // Use this for initialization
    void Start () {
        explosion = GameObject.Find("explosion");
        currentHealth = maxHealth;
        anim = explosion.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
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
