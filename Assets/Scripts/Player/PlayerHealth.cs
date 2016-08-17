using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    Animator anim;
    public int startingHealth = 100;
    public int currentHealth;
    public bool isDead;
    public bool isDamaged;

    public PlayerMovement playerMovement;

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
