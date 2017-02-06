using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject fireexplosion;
    public GameObject genericexplosion;
    public float lifespan;

    public GameObject player;
    public GameObject house;
    public PlayerHealth playerHealth;
    public HouseHealth houseHealth;
    public int damage = 15;


    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindWithTag("Player");
        house = GameObject.FindWithTag("HouseHitbox");
        playerHealth = player.GetComponent<PlayerHealth>();
        houseHealth = house.GetComponent<HouseHealth>();

        StartCoroutine(Waitforit());
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator Waitforit()
    {
        yield return new WaitForSeconds(0.8f);
        genericexplosion = Instantiate(fireexplosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(genericexplosion, 0.7f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerHealth.Damaged(damage);
            genericexplosion = Instantiate(fireexplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(genericexplosion, 0.7f);
        }
        else if (other.gameObject == house)
        {
            houseHealth.Damaged(damage);
            genericexplosion = Instantiate(fireexplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(genericexplosion, 0.7f);
        }
    }

}
