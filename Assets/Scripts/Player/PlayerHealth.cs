using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public bool isDead;
    public bool isDamaged;
    public bool regen = false;
    public float maxHealth = 100f;
    public float currentHealth = 100f;

    public PlayerMovement playerMovement;
    public GameObject player;
    //public float damagedtimer;
    //public float damagecd;

    public AudioSource effectplayer;
    public AudioClip splats;

    public Animator anim;

    //public GameObject blood;
    //public Transform blood;
    public SpriteRenderer bleed;
    public float bleedtimer;

    public GameObject house;
    public HouseHealth houseHealth;
    public GameObject cheats;
    public Text cheatnote;
    public AudioSource note;
    public AudioClip notecheat;
    public bool cheatmode = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        currentHealth = maxHealth;

        effectplayer = GetComponent<AudioSource>();

        //blood = GameObject.Find("Player.bleed");
        //bleed = blood.GetComponent<SpriteRenderer>();

        bleed = transform.Find("bleed").GetComponent<SpriteRenderer>();

        player = GameObject.FindWithTag("Player");

        house = GameObject.FindWithTag("HouseHitbox");
        houseHealth = house.GetComponent<HouseHealth>();
        cheats = GameObject.Find("Cheats");
        cheatnote = cheats.GetComponent<Text>();
        note = player.GetComponent<AudioSource>();

        cheatnote.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //damagedtimer += Time.deltaTime;
        bleedtimer += Time.deltaTime;


        if (regen == true)
        {
            currentHealth += Time.deltaTime * 2f;
            maxHealth = 150;
            if (cheatmode == true)
            {
                currentHealth += Time.deltaTime * 20f;
            }
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (bleedtimer > 0.8f)
        {
            bleed.enabled = false;
            bleedtimer = 0;
        }


        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            cheatmode = true;
            note.clip = notecheat;
            note.Play();
        }

        if (cheatmode == true)
        {
            houseHealth.currentHealth += Time.deltaTime * 80f;
            currentHealth += Time.deltaTime * 30f;
            cheatnote.enabled = true;
        }
    }

    public void Damaged(int damage)
    {
        bleed.enabled = true;
        isDamaged = true;
        currentHealth -= damage;
        Debug.Log(currentHealth);
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    public void Death()
    {
        isDead = true;
        effectplayer.clip = splats;
        effectplayer.volume = 0.5f;
        effectplayer.Play();
        anim.SetBool("IsDead", true);

        //   anim.SetTrigger("Dead");
        playerMovement.enabled = false;
        foreach (Collider2D c in GetComponents<Collider2D>())
        {
            c.enabled = false;
        }
        Invoke("GameoverP", 3);
        Destroy(gameObject,2);
    }

    public void GameoverP()
    {
        Time.timeScale = 0;
    }
}
