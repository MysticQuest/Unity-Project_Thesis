using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject mainText;
    public Text text;

    public GameObject player;

	// Use this for initialization
	void Start ()
    {
        mainText = GameObject.FindWithTag("text");
        text = mainText.GetComponent<Text>();

        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                text.text = "FUCK OFF";
            }
        }
    }
}
