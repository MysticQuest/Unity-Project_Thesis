using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    Animator anim;
    public int startingHealth;
    public int currentHealth;
    public bool isDead;
    public bool isDamaged;

    public BatMovement batMovement;
    public BatAttack batAttack;
    public KnightMovement knightMovement;
    public KnightAttack knightAttack;

    //public GameObject bat;
    //public GameObject knight;
    //public GameObject monster;

    public GameObject target;

    public GameObject itemDrop1;
    public GameObject itemDrop2;
    public GameObject itemDrop3;
    public GameObject genericDrop1;
    public GameObject genericDrop2;
    public GameObject genericDrop3;
    public int randomDrop;

    public GameObject player;
    public ItemEffects items;

    public Rigidbody2D body;
    //public Collider2D[] col;
    //public Transform pos;

    public AudioSource effectplayer;

    // Use this for initialization
    void Start()
    {
        /*bat = GameObject.Find("Bat");
        knight = GameObject.Find("Knight");
        monster = GameObject.Find("Monster");*/

        anim = GetComponent<Animator>();

        currentHealth = startingHealth;

        player = GameObject.FindWithTag("Player");
        items = player.GetComponent<ItemEffects>();

        effectplayer = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        randomDrop = Random.Range(1, 101);
        target = this.gameObject;

        /*bat = GameObject.Find("Bat(Clone)");
        knight = GameObject.Find("Knight");
        monster = GameObject.Find("Monster");*/
    }

    public void Damaged(int damage)
    {
        isDamaged = true;
        currentHealth -= damage;
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    public void Death()
    {
        effectplayer.Play();
        anim.SetTrigger("Death");

        body = GetComponent<Rigidbody2D>();
        //col = GetComponent<Collider2D>();
        //col.enabled = false;
        //col = gameObject.GetComponents<BoxCollider2D>();

        foreach (Collider2D c in GetComponents<Collider2D>())
        {
            c.enabled = false;
        }

        body.isKinematic = true;
        body.velocity = Vector2.zero;

        //body.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;

        if (target.name == "Bat(Clone)")
        {
            batMovement = GetComponent<BatMovement>();
            batAttack = GetComponent<BatAttack>();
            batMovement.enabled = false;
            batAttack.enabled = false;
        }
        if (target.name == "Knight(Clone)" || target.name == "Monster(Clone)")
        {
            knightMovement = GetComponent<KnightMovement>();
            knightAttack = GetComponent<KnightAttack>();
            knightAttack.enabled = false;
            knightMovement.enabled = false;
        }

        Destroy(gameObject, 2);
        isDead = true;

        Invoke("DropItem", 1);

        //knightMovement.enabled = false;
        //batMovement.enabled = false;
    }

    void DropItem()
    {
        if (target.name == "Bat(Clone)")
        {
            if (randomDrop <= 45)
            {
                genericDrop1 = Instantiate(itemDrop1, transform.position, Quaternion.identity) as GameObject;
            }
            else if (randomDrop >= 40 && randomDrop <= 75)
            {
                genericDrop2 = Instantiate(itemDrop2, transform.position, Quaternion.identity) as GameObject;
            }
            else if (randomDrop >= 85 && items.gotgloves == false)
            {
                genericDrop3 = Instantiate(itemDrop3, transform.position, Quaternion.identity) as GameObject;
            }
        }
        else if (target.name == "Monster(Clone)")
        {
            if (randomDrop <= 45)
            {
                genericDrop1 = Instantiate(itemDrop1, transform.position, Quaternion.identity) as GameObject;
            }
            else if (randomDrop >= 40 && randomDrop <= 65)
            {
                genericDrop2 = Instantiate(itemDrop2, transform.position, Quaternion.identity) as GameObject;
            }
            else if (randomDrop >= 90 && items.gotmanual == false)
            {
                genericDrop3 = Instantiate(itemDrop3, transform.position, Quaternion.identity) as GameObject;
            }
        }
        else if (target.name == "Knight(Clone)")
        {
            if (randomDrop <= 45)
            {
                genericDrop1 = Instantiate(itemDrop1, transform.position, Quaternion.identity) as GameObject;
            }
            else if (randomDrop >= 40 && randomDrop <= 55)
            {
                genericDrop2 = Instantiate(itemDrop2, transform.position, Quaternion.identity) as GameObject;
            }
            else if (randomDrop >= 95 && items.gotplate == false)
            {
                genericDrop3 = Instantiate(itemDrop3, transform.position, Quaternion.identity) as GameObject;
            }
        }

    }
}
