using UnityEngine;
using System.Collections;

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
    public SpriteRenderer bleed;
    //public Transform blood;
    public float bleedtimer;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        currentHealth = maxHealth;

        effectplayer = GetComponent<AudioSource>();

        //blood = GameObject.Find("Player.bleed");
        //bleed = blood.GetComponent<SpriteRenderer>();

        bleed = transform.Find("bleed").GetComponent<SpriteRenderer>();

        player = GameObject.FindWithTag("Player");
	}

    // Update is called once per frame
    void Update()
    {
        //damagedtimer += Time.deltaTime;
        bleedtimer += Time.deltaTime;


        if (regen == true)
        {
            currentHealth += Time.deltaTime * 2;
            maxHealth = 150;
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
