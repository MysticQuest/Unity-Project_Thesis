using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    
    public int startingHealth = 100;
    public float currentHealth;
    public bool isDead;
    public bool isDamaged;
    public bool regen = false;
    public float maxHealth = 100;

    public PlayerMovement playerMovement;
    public float damagedtimer;
    public float damagecd;

    public AudioSource effectplayer;
    public AudioClip splats;

    public Animator anim;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        currentHealth = startingHealth;

        effectplayer = GetComponent<AudioSource>();
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
        effectplayer.clip = splats;
        effectplayer.volume = 0.5f;
        effectplayer.Play();
        anim.SetBool("IsDead", true);

        //   anim.SetTrigger("Dead");
        playerMovement.enabled = false;
        foreach (Collider2D c in GetComponents<Collider2D>())
        {
            c.enabled = false;
        }
        Destroy(gameObject,2);
    }
}
