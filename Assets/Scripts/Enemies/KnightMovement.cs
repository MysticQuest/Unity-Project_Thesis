using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class KnightMovement : MonoBehaviour
{

    public float speed;

    //public GameObject[] waypoints;
    public List<GameObject> waypoints;
    public GameObject closest = null;
    public Transform closestPosition;

    public GameObject player;
    public GameObject house;
    public Transform playerpos;
    //public Transform playerpos2;
    public Transform housepos;
    //public float playerposY;

    GameObject finalwaypoint;
    Transform stop;

    //Vector3 direction;
    public float attackCooldown;
    //public float attackCooldownM;
    public float timerCooldown;
    public float timer;
    public float timerMax;
    public int rand;
    float animtimer;
    GameObject[] collisions;

    public Animator anim;
    Rigidbody2D body;
    Vector2 knightvector;
    int x;
    int y;

    public float aggroRange;
    public float aggroRange2;
    public float attackRange;
    Transform knightpos;

    Vector3 prevPos;

    public bool IsAttacking = false;

    //public Transform target;
    public float xDir;
    public float yDir;

    private SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {

        player = GameObject.FindWithTag("Player");
        house = GameObject.FindWithTag("House");

        //playerposY = playerpos.position.y+1;
        //playerpos2 = new Vector3(x,y,z);

        knightpos = GetComponent<Transform>();
        playerpos = player.GetComponent<Transform>();
        housepos = house.GetComponent<Transform>();


        //waypoints = GameObject.FindGameObjectsWithTag("Waypoint");

        waypoints = GameObject.FindGameObjectsWithTag("Waypoint").ToList();
        finalwaypoint = GameObject.Find("C");
        stop = finalwaypoint.GetComponent<Transform>();

        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        collisions = GameObject.FindGameObjectsWithTag("GenCollisions");

        sprite = this.GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        //knight layer
        if (gameObject.name == "Knight(Clone)")
        {
            if (knightpos.position.y > playerpos.position.y)
            {
                sprite.sortingOrder = 5;
            }
            else sprite.sortingOrder = 7;
        }


        /*
                knightvector = (new Vector2(x, y)).normalized;
                body.velocity = knightvector;
                anim.SetFloat("x", knightvector.x);
                anim.SetFloat("y", knightvector.y);
                */

        //target = GameObject.Find("Player").transform;

        animtimer += Time.deltaTime;

        if (Vector2.Distance(knightpos.position, playerpos.position) < aggroRange)
        {
            xDir = playerpos.position.x - transform.position.x;
            yDir = playerpos.position.y - transform.position.y;
            if (animtimer > 0.5)
            {
                anim.SetFloat("x", xDir);
                anim.SetFloat("y", yDir);
            }
        }
        else if (Vector2.Distance(knightpos.position, housepos.position) <= attackRange + 0.5)
        {
            xDir = housepos.position.x - transform.position.x;
            yDir = housepos.position.y - transform.position.y;
            if (animtimer > 2)
            {
                anim.SetFloat("x", xDir);
                anim.SetFloat("y", yDir);
                animtimer = 0;
            }
        }
        else
        {
            knightvector = transform.position - prevPos;
            anim.SetFloat("x", knightvector.x);
            anim.SetFloat("y", knightvector.y);
            if (animtimer > 0.5)
            {
                prevPos = transform.position;
                animtimer = 0;
            }
        }

        if ((Vector2.Distance(knightpos.position, playerpos.position) <= attackRange && timerCooldown > attackCooldown) || (Vector2.Distance(knightpos.position, housepos.position) <= attackRange + 0.6f && timerCooldown > attackCooldown))
        {
            anim.SetBool("IsAttacking", true);
            timerCooldown = 0;
        }
        else anim.SetBool("IsAttacking", false);

        timerCooldown += Time.deltaTime;

        if (Vector2.Distance(knightpos.position, playerpos.position) < aggroRange && Vector2.Distance(knightpos.position, playerpos.position) > attackRange)
        {
            waypoints.Clear();
            closest = null;
            closestPosition = null;

            if (gameObject.name == "Knight(Clone)")
            {
                transform.position = Vector2.MoveTowards(transform.position, playerpos.position - playerpos.up * 0.3f, speed * Time.deltaTime);
            }

            else if (gameObject.name == "Monster(Clone)")
            {
                transform.position = Vector2.MoveTowards(transform.position, playerpos.position + playerpos.up * 0.3f, speed * Time.deltaTime);
            }

        }
        else if (Vector2.Distance(knightpos.position, housepos.position) < aggroRange2)
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
                if (timer > timerMax)// && transform.position == stop.position)
                {
                    rand = Random.Range(1, 9);
                    timerMax = Random.Range(1, 3);
                    timer = 0;
                }
                timer += Time.deltaTime;
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


        /*        timer += Time.deltaTime;
                if (timer > 3)
                {
                    direction = (new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f))).normalized;
                    timer = 0;
                }
                else
                {
                    return;
                }*/


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

