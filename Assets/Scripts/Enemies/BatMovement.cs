using UnityEngine;
using System.Collections;

public class BatMovement : MonoBehaviour
{

    public float speed;
    public GameObject[] collisions;
    public float timer;
    public float timerMax;
    public int rand = 1;

    public float aggroRange;
    public float aggroRange2;
    public GameObject player;
    public GameObject house;
    public Transform batpos;
    public Transform playerpos;
    public Transform housepos;
    


    // Use this for initialization
    void Start()
    {
       collisions = GameObject.FindGameObjectsWithTag("GenCollisions");

       batpos = GetComponent<Transform>();
       player = GameObject.FindGameObjectWithTag("Player");
       playerpos = player.GetComponent<Transform>();

       house = GameObject.FindGameObjectWithTag("House");
       housepos = house.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        /*       Collider2D[] aggroplayer = Physics2D.OverlapCircleAll(batpos.position, aggroRange, 0);
               foreach (Collider2D entity in aggroplayer)
               {
                   if (entity == player)
                   {
                       Debug.Log("FAIL");
                       transform.Translate(Vector2.MoveTowards(transform.position, playerpos.position, speed * Time.deltaTime));
                   }
               }*/

        if (Vector2.Distance(batpos.position, playerpos.position) < aggroRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerpos.position - playerpos.up * 0.01f, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(batpos.position, housepos.position) < aggroRange2)
        {
            transform.position = Vector2.MoveTowards(transform.position, housepos.position, speed * Time.deltaTime);
        }
        else
        { 
            if (timer > timerMax)
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

    /*public void Change();
    {

    }*/
     

}              






