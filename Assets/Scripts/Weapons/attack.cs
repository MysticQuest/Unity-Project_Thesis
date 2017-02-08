using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour {

    public PlayerAttack pattack;
    public PlayerHealth playerHealth;
    public Health health;
    public GameObject player;
    public GameObject[] enemies;
    public GameObject enemy;
    public float timer;

    public AudioSource effectplayer;
    public AudioClip punch;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindWithTag("Player");
        pattack = player.GetComponent<PlayerAttack>();
        playerHealth = player.GetComponent<PlayerHealth>();

        effectplayer = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        timer += Time.deltaTime;

        if (timer >= pattack.attackCooldown && pattack.IsAttacking && pattack.inRange && playerHealth.currentHealth >= 0)
        {
            Attack();
        
        }
    }

    void Attack()
    {
        timer = 0f;
        if (health != null)
        {
            if (health.currentHealth > 0)
            {
                health.Damaged(pattack.damage);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject == bat || other.gameObject == monster || other.gameObject == knight)

        //        if (other.gameObject.name == "PunchCol1")
        //        {
        foreach (GameObject enemy in enemies)
        {
            if (other.gameObject == enemy.gameObject)
            {
                health = enemy.GetComponent<Health>();
                if (pattack.IsAttacking == true)
                {
                    effectplayer.Play();
                    pattack.inRange = true;


                    //problematic knockback attempts (work only on Y)

                    /*Vector3 directionVector = other.transform.position - transform.position;
                    Rigidbody2D body = other.GetComponent<Rigidbody2D>();
                    if (body != null)
                    {
                        float forceMagnitude = 0.9f;
                        ForceMode2D mode = ForceMode2D.Impulse;
                        body.AddForce(directionVector.normalized * forceMagnitude, mode);
                    }*/
                    //Vector3 direction = (other.transform.position - transform.position).normalized;
                    //body = other.GetComponent<Rigidbody2D>();
                    //body.AddForce(direction * 10);

                    //Vector2 directionVector = other.gameObject.transform.position - this.transform.position;
                    //Rigidbody2D body = other.gameObject.GetComponent<Rigidbody2D>();
                    //body.velocity = directionVector.normalized;
                }
                else
                {
                    pattack.inRange = false;
                }


            }
        }
        //        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //if (other.gameObject == bat || other.gameObject == monster || other.gameObject == knight)
        if (other.gameObject == enemy)
        {
            if (pattack.IsAttacking == true)
            {
                pattack.inRange = false;
            }
        }
    }
}
