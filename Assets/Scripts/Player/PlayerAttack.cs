using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    Rigidbody2D body1;
    Animator anim;
    public int damage = 10;
    public float attackCooldown = 0.1F;
    public bool IsAttacking = false;
    public float timer;

    public GameObject player;
    public GameObject enemy;
    public GameObject[] enemies;

    //public GameObject bat;
    //public GameObject monster;
    //public GameObject knight;

    public Health health;
    //public Health[] healtharray;
    public PlayerHealth playerHealth;
    public bool inRange;

    public Rigidbody2D body;

    void Start ()
    {
        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        //enemy = GameObject.FindWithTag("Enemy");

        body1 = GetComponent<Rigidbody2D>();

        /*if (enemy != null)
        {
            health = enemy.GetComponent<Health>();
        }*/
    }
	
	void Update ()
    {
        //bat = GameObject.FindWithTag("Bat");
        //monster = GameObject.FindWithTag("Monster");
        //knight = GameObject.FindWithTag("Knight");

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        anim = GetComponent<Animator>();
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("IsAttacking", true);
            IsAttacking = true;
        }       
        else
        {
            anim.SetBool("IsAttacking", false);
            IsAttacking = false;
        }

        timer += Time.deltaTime;

        if (timer >= attackCooldown && IsAttacking && inRange && playerHealth.currentHealth >= 0)
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
                health.Damaged(damage);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject == bat || other.gameObject == monster || other.gameObject == knight)
        foreach (GameObject enemy in enemies)
        {
            if (enemy == other.gameObject)
            {
                health = enemy.GetComponent<Health>();
                if (IsAttacking == true)
                {
                    inRange = true;

                    //problematic knockback attempts

                    Vector3 directionVector = other.transform.position - transform.position;
                    Rigidbody2D body = other.GetComponent<Rigidbody2D>();
                    if (body != null)
                    {
                        float forceMagnitude = 0.5f;
                        ForceMode2D mode = ForceMode2D.Impulse;
                        body.AddForce(directionVector.normalized * forceMagnitude, mode);
                    }
                    //Vector3 direction = (other.transform.position - transform.position).normalized;
                    //body = other.GetComponent<Rigidbody2D>();
                    //body.AddForce(direction * 10);
                    /*Vector2 directionVector = other.gameObject.transform.position - this.transform.position;
                    Rigidbody2D body = other.gameObject.GetComponent<Rigidbody2D>();
                    body.velocity = directionVector.normalized;*/
                }
                else
                {
                    inRange = false;
                }


            }
        }
    }

                    void OnTriggerExit2D(Collider2D other)
                    {
                      //if (other.gameObject == bat || other.gameObject == monster || other.gameObject == knight)
                      if (other.gameObject == enemy)
                        {
                            if (IsAttacking == true)
                            {
                                inRange = false;
                            }
                        }
                    }









                    /*void AttackMechanics()
                    {
                        if (IsAttacking == true) return;
                        IsAttacking = true;
                        StartCoroutine("AttackCooldown");
                    }

                    IEnumerator AttackCooldown()
                    {
                        yield return new WaitForSeconds(attackCooldown);
                        IsAttacking = false;
                    }
                    */

            }
