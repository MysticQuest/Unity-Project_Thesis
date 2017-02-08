using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{

    public GameObject player;
    public bool gotkey = false;

    public AudioSource effectplayer;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        effectplayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            if (Input.GetKeyDown(KeyCode.E) && gotkey == false)
            {
                effectplayer.Play();
                gotkey = true;
            }
        }
    }
}
