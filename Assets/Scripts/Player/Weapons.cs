using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {

    public PlayerAttack pattack;
    public PlayerHealth playerHealth;
    public Health health;
    public GameObject player;
    public GameObject[] enemies;
    public GameObject enemy;
    public float timer;

    public AudioSource effectplayer;
    public AudioClip punch;

    public Vector2 velocity;

    public BatMovement batmove;

    public float knocktimer;
    public float knockcd = 0.0f;

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
        knocktimer += Time.deltaTime;

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

        foreach (GameObject enemy in enemies)
        {
            if (other.gameObject == enemy.gameObject)
            {
                health = enemy.GetComponent<Health>();
                if (pattack.IsAttacking == true)
                {
                    effectplayer.Play();
                    pattack.inRange = true;

                    //problematic knockback attempts (work only on Y) - transform overrides physics (rigidbody movement)

                    /*if (knocktimer > knockcd)
                    {
                        //batmove = other.GetComponent<BatMovement>();
                        //batmove.enabled = false;
                        //other.transform.position = Vector2.MoveTowards(other.transform.position, player.transform.position, -2 * Time.deltaTime);

                        knocktimer = 0;
                        Vector3 knockback = (transform.position - player.transform.position).normalized * 30f * Time.deltaTime;
                        other.transform.position = (knockback + other.transform.position);
                    }*/
                
                    //other.transform.position = new Vector2(player.transform.position + other.transform.position *0.02f * Time.deltaTime).normalized;

                    /*Rigidbody2D otherRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
                    Vector2 knockbackDir = (new Vector2(other.transform.position.x, other.transform.position.y) - new Vector2(player.transform.position.x, player.transform.position.y)).normalized;
                    Vector2 knockbackDirRounded = new Vector2(Mathf.Round(knockbackDir.x), Mathf.Round(knockbackDir.y));
                    otherRigidbody.velocity = new Vector2(knockbackDirRounded.x * 16, knockbackDirRounded.y * 2);
                    velocity = otherRigidbody.velocity;*/

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
                //batmove.enabled = true;
            }
        }
    }

    /*void OnTriggerStay2D(Collider2D other)
    {
        foreach (GameObject enemy in enemies)
        {
            if (other.gameObject == enemy.gameObject)
            {
                if (knocktimer > knockcd)
                {
                    //batmove = other.GetComponent<BatMovement>();
                    //batmove.enabled = false;
                    //other.transform.position = Vector2.MoveTowards(other.transform.position, player.transform.position, -2 * Time.deltaTime);

                    knocktimer = 0;
                    Vector3 knockback = transform.position - player.transform.position;
                    other.transform.position = knockback + other.transform.position;
                }
            }
        }
    }*/

}
