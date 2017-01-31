using UnityEngine;
using System.Collections;

public class WarpManual : MonoBehaviour
{
    public Transform target;
    public Interactables inter;
    public GameObject player;
    public GameObject keychest;

    void Start()
    {
        keychest = GameObject.FindWithTag("key");
        player = GameObject.FindWithTag("Player");
        inter = keychest.GetComponent<Interactables>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (inter.gotkey == true)
                {
                    other.transform.position = target.position;
                }
                else Debug.Log("it's locked");
            }
        }
    }
}