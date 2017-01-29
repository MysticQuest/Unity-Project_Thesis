using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    Animator anim;
    public int startingHealth;
    public int currentHealth;
    public bool isDead;
    public bool isDamaged;

    public BatMovement batMovement;
    public KnightMovement knightMovement;

    public GameObject bat;
    public GameObject knight;
    public GameObject monster;

    public GameObject target;

    public GameObject itemDrop1;
    public GameObject itemDrop2;
    public GameObject itemDrop3;
    public GameObject genericDrop1;
    public GameObject genericDrop2;
    public GameObject genericDrop3;
    public int randomDrop;

    // Use this for initialization
    void Start()
    {
        /*bat = GameObject.Find("Bat");
        knight = GameObject.Find("Knight");
        monster = GameObject.Find("Monster");

        batMovement = GetComponent<BatMovement>();
        knightMovement = GetComponent<KnightMovement>();*/

        anim = GetComponent<Animator>();

        currentHealth = startingHealth;

    }

    // Update is called once per frame
    void Update()
    {
        randomDrop = Random.Range(1, 101);
        target = this.gameObject;

        bat = GameObject.Find("Bat(Clone)");
        knight = GameObject.Find("Knight");
        monster = GameObject.Find("Monster");
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
        Destroy(gameObject);
        isDead = true;

        //   anim.SetTrigger("Dead");
        //   knightMovement.enabled = false;
        //batMovement.enabled = false;

        if (target.name == "Bat(Clone)")
        {
            if (randomDrop <= 33)
            {
                genericDrop1 = Instantiate(itemDrop1, transform.position, Quaternion.identity) as GameObject;
            }
            else if (randomDrop >= 33 && randomDrop <= 65)
            {
                genericDrop2 = Instantiate(itemDrop2, transform.position, Quaternion.identity) as GameObject;
            }
            else if (randomDrop >= 90)
            {
                genericDrop3 = Instantiate(itemDrop3, transform.position, Quaternion.identity) as GameObject;
            }
        }
        else if (target.name == "Monster(Clone)")
        {
            if (randomDrop <= 33)
            {
                genericDrop1 = Instantiate(itemDrop1, transform.position, Quaternion.identity) as GameObject;
            }
            else if (randomDrop >= 33 && randomDrop <= 60)
            {
                genericDrop2 = Instantiate(itemDrop2, transform.position, Quaternion.identity) as GameObject;
            }
            else if (randomDrop >= 90)
            {
                genericDrop3 = Instantiate(itemDrop3, transform.position, Quaternion.identity) as GameObject;
            }
        }
        else if (target.name == "Knight(Clone)")
        {
            if (randomDrop <= 33)
            {
                genericDrop1 = Instantiate(itemDrop1, transform.position, Quaternion.identity) as GameObject;
            }
            else if (randomDrop >= 33 && randomDrop <= 70)
            {
                genericDrop2 = Instantiate(itemDrop2, transform.position, Quaternion.identity) as GameObject;
            }
            else if (randomDrop >= 95)
            {
                genericDrop3 = Instantiate(itemDrop3, transform.position, Quaternion.identity) as GameObject;
            }
        }

    }
}
