using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionD : MonoBehaviour
{
    public GameObject player;
    public GameObject house;
    public PlayerHealth playerHealth;
    public HouseHealth houseHealth;
    public int damage = 1;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindWithTag("Player");
        house = GameObject.FindWithTag("HouseHitbox");
        playerHealth = player.GetComponent<PlayerHealth>();
        houseHealth = house.GetComponent<HouseHealth>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerHealth.Damaged(damage);
        }
        else if (other.gameObject == house)
        {
            houseHealth.Damaged(damage);
        }
    }
}
