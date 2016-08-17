using UnityEngine;
using System.Collections;

public class BatMovement : MonoBehaviour
{

    public float speed;
    public GameObject[] collisions;
    public float timer;
    public float timerMax;
    public int rand = 1;

    // Use this for initialization
    void Start()
    {
        collisions = GameObject.FindGameObjectsWithTag("GenCollisions");
       
    }

    // Update is called once per frame
    void Update()
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






