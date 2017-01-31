using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffects : MonoBehaviour
{

    public PlayerHealth health;
    public PlayerMovement movement;
    public PlayerAttack attack;
    public GameObject player;

    public GameObject barrel;
    public Rigidbody2D barrelmass;

    public GameObject[] hearts;
    public GameObject[] rupies1;
    public GameObject[] rupies2;
    public GameObject[] rupies3;

    public GameObject speedboots;
    public GameObject manual;
    public GameObject strengthgloves;
    public GameObject goldenplate;
    public GameObject stonesword;
    public GameObject firesword;

    public bool gotmanual = false;
    public bool gotgloves = false;
    public bool gotplate = false;
    public bool gotstone = false;

    public int rupies = 0;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        health = player.GetComponent<PlayerHealth>();
        movement = player.GetComponent<PlayerMovement>();
        attack = player.GetComponent<PlayerAttack>();

        barrel = GameObject.FindWithTag("barrel");
        barrelmass = barrel.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        hearts = GameObject.FindGameObjectsWithTag("heart");
        rupies1 = GameObject.FindGameObjectsWithTag("rupie1");
        rupies2 = GameObject.FindGameObjectsWithTag("rupie2");
        rupies3 = GameObject.FindGameObjectsWithTag("rupie3");

        speedboots = GameObject.FindWithTag("speedboots");
        manual = GameObject.FindWithTag("manual");
        strengthgloves = GameObject.FindWithTag("strengthgloves");
        goldenplate = GameObject.FindWithTag("goldenplate");
        stonesword = GameObject.FindWithTag("stonesword");
        firesword = GameObject.FindWithTag("firesword");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        foreach (GameObject heart in hearts)
        {
            if (other.gameObject == heart)
            {
                health.currentHealth += 25;
                Destroy(other.gameObject);
            }
        }
        foreach (GameObject rupie1 in rupies1)
        {
            if (other.gameObject == rupie1)
            {
                rupies += 1;
                Debug.Log("Rupies:" + rupies);
                Destroy(other.gameObject);
            }
        }
        foreach (GameObject rupie2 in rupies2)
        {
            if (other.gameObject == rupie2)
            {
                rupies += 5;
                Debug.Log("Rupies:" + rupies);
                Destroy(other.gameObject);
            }
        }
        foreach (GameObject rupie3 in rupies3)
        {
            if (other.gameObject == rupie3)
            {
                rupies += 15;
                Debug.Log("Rupies:" + rupies);
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject == speedboots)
        {
            movement.speed = 2f;
            Destroy(other.gameObject);
        }
        if (other.gameObject == manual && gotmanual == false)
        {
            gotmanual = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject == strengthgloves && gotgloves == false)
        {
            gotgloves = true;
            attack.damage += 3;
            barrelmass.mass = 0.1f;
            Destroy(other.gameObject);
        }
        if (other.gameObject == goldenplate && gotplate == false)
        {
            gotplate = true;
            health.regen = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject == stonesword && gotgloves == true)
        {
            //change animations
            attack.damage += 10;
            Destroy(other.gameObject);
        }
        if (other.gameObject == firesword && gotstone == true && gotmanual == true)
        {
            //change animations
            attack.damage += 12;
            Destroy(other.gameObject);
        }
    }

}

