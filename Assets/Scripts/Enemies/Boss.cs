using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

    public float speed;

    public List<GameObject> waypoints;
    public GameObject closest = null;
    public Transform closestPosition;

    public GameObject player;
    public GameObject house;
    //public GameObject bosslight;
    public Transform playerpos;
    //public Transform playerpos2;
    public Transform housepos;
    public float playerposY;

    GameObject finalwaypoint;
    Transform stop;
    
    public float attackCooldown;
    //public float attackCooldownM;
    public float timerCooldown;
    public float timer;
    public float timerMax;
    public int rand;
    public float animtimer;
    GameObject[] collisions;

    public Animator anim;
    public Animator animlight;
    Rigidbody2D body;
    Vector2 knightvector;
    int x;

    public float aggroRange;
    public float aggroRange2;
    public float attackRange;
    Transform knightpos;

    Vector3 prevPos;

    //public bool IsAttacking = false;

    public Transform target;
    public float xDir;
    public float yDir;

    //public float attackTimer = 0; // revert attack animation timer
    public float attackDuration = 5f;

    public GameObject fire;
    public BossFire firescript;
    public float firetimer;
    //public GameObject genericfireball;

    //public bool bossdead;
    public Health health;
    public GameObject music;
    public AudioSource musicplayer;
    public AudioSource bossplayer;

    public GameObject black;
    public Image blackimage;
    public GameObject ending;
    public Text endtext;

    // Use this for initialization
    void Start()
    {
        fire = GameObject.FindWithTag("fire");
        firescript = fire.GetComponent<BossFire>();

        player = GameObject.FindWithTag("Player");
        house = GameObject.FindWithTag("House");
        //bosslight = GameObject.Find("bosslight");

        knightpos = GetComponent<Transform>();
        playerpos = player.GetComponent<Transform>();
        housepos = house.GetComponent<Transform>();

        health = GetComponent<Health>();

        waypoints = GameObject.FindGameObjectsWithTag("Waypoint").ToList();
        finalwaypoint = GameObject.Find("C");
        stop = finalwaypoint.GetComponent<Transform>();

        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //animlight = bosslight.GetComponent<Animator>();

        collisions = GameObject.FindGameObjectsWithTag("GenCollisions");

        music = GameObject.Find("MusicPlayer");
        musicplayer = music.GetComponent<AudioSource>();
        bossplayer = GetComponent<AudioSource>();

        black = GameObject.Find("Black");
        blackimage = black.GetComponent<Image>();
        ending = GameObject.Find("Ending");
        endtext = ending.GetComponent<Text>();

    }


    // Update is called once per frame
    void Update()
    {
        animtimer += Time.deltaTime;
        timerCooldown += Time.deltaTime;
        firetimer += Time.deltaTime;

        if (health.currentHealth <= 0)
        {
            //bossdead = true;
            musicplayer.mute = true;
            bossplayer.Play();

            blackimage.CrossFadeAlpha(255f, 3f, false);
            endtext.CrossFadeAlpha(255f, 3f, false);

            endtext.text = "Victory!";

            Time.timeScale = 0;
        }

        //smooth animations
        
        if (Vector2.Distance(knightpos.position, playerpos.position) < aggroRange)
        {
            xDir = playerpos.position.x - transform.position.x;
            if (animtimer > 0.5)
            {
                anim.SetFloat("x", xDir);
            }
        }
        else if (Vector2.Distance(knightpos.position, housepos.position) <= attackRange + 0.5)
        {
            xDir = housepos.position.x - transform.position.x;
            if (animtimer > 1)
            {
                anim.SetFloat("x", xDir);
                animtimer = 0;
            }
        }
        else
        {
            knightvector = transform.position - prevPos;
            anim.SetFloat("x", knightvector.x);
            if (animtimer > 0.5)
            {
                prevPos = transform.position;
                animtimer = 0;
            }
        }

        //smooth animations end

        //fireball and attack animations

        if ((Vector2.Distance(knightpos.position, playerpos.position) <= attackRange && timerCooldown > attackCooldown) || (Vector2.Distance(knightpos.position, housepos.position) <= attackRange + 0.6f && timerCooldown > attackCooldown))
        {
            anim.SetBool("IsAttacking", true);
            if (timerCooldown > attackDuration)
            {
                timerCooldown = 0;
            }
        }
        else anim.SetBool("IsAttacking", false);



        //movement stuff

        if (Vector2.Distance(knightpos.position, playerpos.position) < aggroRange && Vector2.Distance(knightpos.position, playerpos.position) > attackRange)
        {
            waypoints.Clear();
            closest = null;
            closestPosition = null;
            transform.position = Vector2.MoveTowards(transform.position, playerpos.position, speed * Time.deltaTime);

        }
        else if (Vector2.Distance(knightpos.position, housepos.position) < aggroRange2 && Vector2.Distance(knightpos.position, housepos.position) > attackRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, housepos.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(knightpos.position, playerpos.position) > aggroRange)
        {

            closestWaypoint();
            if (closest != null)
            {
                closestPosition = closest.GetComponent<Transform>();
                transform.position = Vector2.MoveTowards(transform.position, closestPosition.position, speed * Time.deltaTime);
                if (closestPosition.position == transform.position)
                {
                    waypoints.Remove(closest);
                }
                if (transform.position == stop.position)
                {
                    waypoints.Clear();
                    //closestPosition.position = Vector2.MoveTowards(transform.position, playerpos.position, speed * Time.deltaTime);
                }
            }

            else
            {
                timer += Time.deltaTime;
                if (timer > timerMax)// && transform.position == stop.position)
                {
                    rand = Random.Range(1, 9);
                    timerMax = Random.Range(1, 3);
                    timer = 0;
                }

                switch (rand)
                {
                    case 1:
                        transform.Translate(Vector2.up * speed * Time.deltaTime);
                        break;
                    case 2:
                        transform.Translate(-Vector2.up * speed * Time.deltaTime);
                        break;
                    case 3:
                        transform.Translate(Vector2.right * speed * Time.deltaTime);
                        break;
                    case 4:
                        transform.Translate(-Vector2.right * speed * Time.deltaTime);
                        break;
                    case 5:
                        transform.Translate((Vector2.up + Vector2.right).normalized * speed * Time.deltaTime);
                        break;
                    case 6:
                        transform.Translate((Vector2.up + Vector2.left).normalized * speed * Time.deltaTime);
                        break;
                    case 7:
                        transform.Translate((Vector2.down - Vector2.right).normalized * speed * Time.deltaTime);
                        break;
                    case 8:
                        transform.Translate((Vector2.down - Vector2.left).normalized * speed * Time.deltaTime);
                        break;
                }
            }
        }
        else return;

    }

    public GameObject closestWaypoint()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject destination in waypoints)
        {
            Vector3 diff = destination.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = destination;
                distance = curDistance;
            }
        }
        return closest;
    }

    public void OnCollisionStay2D(Collision2D other)
    {
        foreach (GameObject collision in collisions)
        {
            if (other.gameObject == collision)
            {
                rand = Random.Range(1, 9);
            }
        }
    }
}
