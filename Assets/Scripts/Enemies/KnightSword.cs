using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSword : MonoBehaviour
{
    public GameObject player;
    public GameObject house;
    public bool inRange = false;
    public bool inRange2 = false;

    public KnightAttack kattack;
    public GameObject knight;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindWithTag("Player");
        house = GameObject.FindWithTag("HouseHitbox");

        knight = GameObject.Find("Knight(Clone)");
        kattack = knight.GetComponent<KnightAttack>(); 
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            kattack.inRange = true;
        }
        else if (other.gameObject == house)
        {
            kattack.inRange2 = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //if (other.gameObject == player)
        //{
            kattack.inRange = false;
        //}
        //if (other.gameObject == house)
        //{
            kattack.inRange2 = false;
        //}
    }
}
