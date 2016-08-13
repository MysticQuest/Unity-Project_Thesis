using UnityEngine;
using System.Collections;

public class BatMovement : MonoBehaviour {

    public Transform target;
    public float speed = 3f;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update ()
    {
                  transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
