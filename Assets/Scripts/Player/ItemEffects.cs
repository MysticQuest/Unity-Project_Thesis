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
    //public GameObject strengthgloves;
    public GameObject goldenplate;
    public GameObject stonesword;
    public GameObject firesword;
    public GameObject key;

    public bool gotkey = false;
    public bool gotboots = false;
    public bool gotmanual = false;
    public bool gotgloves = false;
    public bool gotplate = false;

    public bool gotstone = false;

    public int rupies = 0;

    public AudioSource effectplayer;
    public AudioClip coin;
    public AudioClip heartsound;
    public AudioClip item;
    public AudioClip keys;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        health = player.GetComponent<PlayerHealth>();
        movement = player.GetComponent<PlayerMovement>();
        attack = player.GetComponent<PlayerAttack>();

        //barrel = GameObject.FindWithTag("barrel");
        //barrelmass = barrel.GetComponent<Rigidbody2D>();

        effectplayer = GetComponent<AudioSource>();

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
        key = GameObject.FindWithTag("key");
        goldenplate = GameObject.FindWithTag("goldenplate");
        stonesword = GameObject.FindWithTag("stonesword");
        firesword = GameObject.FindWithTag("firesword");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        foreach (GameObject heart in hearts)
        {
            if (other.gameObject == heart && health.currentHealth < health.maxHealth)
            {
                effectplayer.clip = heartsound;
                effectplayer.Play();
                health.currentHealth += 20;
                Destroy(other.gameObject);
            }
        }
        foreach (GameObject rupie1 in rupies1)
        {
            if (other.gameObject == rupie1)
            {
                effectplayer.clip = coin;
                effectplayer.Play();
                rupies += 1;
                Debug.Log("Rupies:" + rupies);
                Destroy(other.gameObject);
            }
        }
        foreach (GameObject rupie2 in rupies2)
        {
            if (other.gameObject == rupie2)
            {
                effectplayer.clip = coin;
                effectplayer.Play();
                rupies += 5;
                Debug.Log("Rupies:" + rupies);
                Destroy(other.gameObject);
            }
        }
        foreach (GameObject rupie3 in rupies3)
        {
            if (other.gameObject == rupie3)
            {
                effectplayer.clip = coin;
                effectplayer.Play();
                rupies += 15;
                Debug.Log("Rupies:" + rupies);
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject == speedboots)
        {
            effectplayer.clip = item;
            effectplayer.Play();
            movement.speed = 2f;
            gotboots = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject == manual && gotmanual == false)
        {
            effectplayer.clip = item;
            effectplayer.Play();
            gotmanual = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject == key && gotkey == false)
        {
            effectplayer.clip = keys;
            effectplayer.Play();
            gotkey = true;            
            Destroy(other.gameObject);
        }
        if (other.gameObject == goldenplate && gotplate == false)
        {
            effectplayer.clip = item;
            effectplayer.Play();
            gotplate = true;
            health.regen = true;
            Destroy(other.gameObject);
        }
        /*if (other.gameObject == stonesword && gotgloves == true)
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
        }*/
    }

}

