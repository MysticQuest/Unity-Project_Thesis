using UnityEngine;
using System.Collections;

public class BatAttack : MonoBehaviour {

    public int damage = 10;
    public int attackCooldown = 1;

    public GameObject player;
    public GameObject house;
    public Health health;
    public PlayerHealth playerHealth;
    public HouseHealth houseHealth;
    public bool inRange;
    public bool inRange2;
    public float timer;


	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindWithTag("Player");
        house = GameObject.FindWithTag("HouseHitbox");
        playerHealth = player.GetComponent<PlayerHealth>();
        houseHealth = house.GetComponent<HouseHealth>();
        health = GetComponent<Health>();
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            inRange = true;
        }
        else if (other.gameObject == house)
        {
            inRange2 = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //if (other.gameObject == player)
        //{
            inRange = false;
        //}
        //else if (other.gameObject == house)
        //{
            inRange2 = false;
        //} 
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= attackCooldown && inRange && health.currentHealth >=0)
        {
            AttackP();
        }
        else if (timer >= attackCooldown && inRange2 && health.currentHealth >= 0)
        {
            AttackH();
        }
    }

    void AttackP()
    {
        timer = 0f;
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.Damaged(damage);
        }
    }
    void AttackH()
    {
        timer = 0f;
        if (houseHealth.currentHealth > 0)
        {
            houseHealth.Damaged(damage);
        }
    }
}
