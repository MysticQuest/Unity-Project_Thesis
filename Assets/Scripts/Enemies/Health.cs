using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    Animator anim;
    public int startingHealth;
    public int currentHealth;
    public bool isDead;
    public bool isDamaged;

    public BatMovement batMovement;
    public KnightMovement knightMovement;

    public GameObject bat;
    public GameObject knight;
    public GameObject monster;

    // Use this for initialization
    void Start ()
    {
        bat = GameObject.Find("Bat");
        knight = GameObject.Find("Knight");
        monster = GameObject.Find("Monster");

        anim = GetComponent<Animator>();
        batMovement = GetComponent<BatMovement>();
        knightMovement = GetComponent<KnightMovement>();
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
        //   knightMovement.enabled = false;
        //batMovement.enabled = false;
        Destroy(gameObject);
    }
}
