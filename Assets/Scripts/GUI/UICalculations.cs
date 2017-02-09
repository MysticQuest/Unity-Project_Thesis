using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICalculations : MonoBehaviour
{
    public PlayerHealth playerhealth;
    public HouseHealth househealth;

    public GameObject housebar;
    public GameObject playerbar;
    public GameObject player;
    public GameObject house;

    public float cHealth;
    public float mHealth;
    public float hcHealth;
    public float hmHealth;

    public float healthratio;
    public float househealthratio;
 
	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindWithTag("Player");
        house = GameObject.FindWithTag("HouseHitbox");

        playerhealth = player.GetComponent<PlayerHealth>();
        househealth = house.GetComponent<HouseHealth>();

        housebar = GameObject.Find("housebar");
        playerbar = GameObject.Find("playerbar");
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        mHealth = playerhealth.maxHealth;
        cHealth = playerhealth.currentHealth;
        hmHealth = househealth.maxHealth;
        hcHealth = househealth.currentHealth;

        healthratio = cHealth / mHealth;
        househealthratio = hcHealth / hmHealth;

        playerbar.transform.localScale = new Vector2(healthratio, playerbar.transform.localScale.y);
        housebar.transform.localScale = new Vector2(househealthratio, housebar.transform.localScale.y);
    }
}
