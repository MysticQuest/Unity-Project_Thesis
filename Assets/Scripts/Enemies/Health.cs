using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    Animator anim;
    public int startingHealth;
    public int currentHealth;
    public bool isDead;
    public bool isDamaged;

    public BatMovement batMovement;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        batMovement = GetComponent<BatMovement>();
        currentHealth = startingHealth;
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
        //   anim.SetTrigger("Dead");
        batMovement.enabled = false;
        Destroy(gameObject);
    }
}
