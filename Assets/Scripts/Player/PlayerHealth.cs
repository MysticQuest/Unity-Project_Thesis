using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    Animator anim;
    public int startingHealth = 100;
    public float currentHealth;
    public bool isDead;
    public bool isDamaged;
    public bool regen = false;
    public float maxHealth = 100;

    public PlayerMovement playerMovement;
    public float damagedtimer;
    public float damagecd;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
        damagedtimer += Time.deltaTime;
        if (regen == true)
        {
            currentHealth += Time.deltaTime;
            maxHealth = 150;
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
	}

    public void Damaged(int damage)
    {
        isDamaged = true;
        currentHealth -= damage;
        Debug.Log(currentHealth);
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    public void Death()
    {
        isDead = true;
        //   anim.SetTrigger("Dead");
        playerMovement.enabled = false;
        Destroy(gameObject);
    }
}
