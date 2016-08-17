using UnityEngine;
using System.Collections;

public class BatAttack : MonoBehaviour {

    public int damage = 10;
    public int attackCooldown = 1;

    public GameObject player;
    public Health health;
    public PlayerHealth playerHealth;
    public bool inRange;
    public float timer;


	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        health = GetComponent<Health>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            inRange = false;
        }   
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>=attackCooldown && inRange && health.currentHealth >=0)
        {
            Attack();
        }
    }

    void Attack()
    {
        timer = 0f;
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.Damaged(damage);
        }
    }
}
