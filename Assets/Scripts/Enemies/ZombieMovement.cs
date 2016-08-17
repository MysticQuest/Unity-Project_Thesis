using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ZombieMovement : MonoBehaviour {

    public float speed = 3f;
    //public GameObject[] waypoints;
    public List<GameObject> waypoints;
    public GameObject closest = null;
    public Transform closestPosition;

    public GameObject player;
    public Transform playerpos;

    GameObject finalwaypoint;
    Transform stop;
    
    Vector3 direction;
    float timer;



    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindWithTag("Player");
        playerpos = player.GetComponent<Transform>();

        //waypoints = GameObject.FindGameObjectsWithTag("Waypoint");

        waypoints = GameObject.FindGameObjectsWithTag("Waypoint").ToList();
        finalwaypoint = GameObject.Find("C");
        stop = finalwaypoint.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        closestWaypoint();
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
}
