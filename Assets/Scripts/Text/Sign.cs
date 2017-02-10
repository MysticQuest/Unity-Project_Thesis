using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject mainText;
    public Text text;

    public GameObject player;

    public GameObject frame;
    public Image image;

	// Use this for initialization
	void Start ()
    {
        mainText = GameObject.FindWithTag("text");
        text = mainText.GetComponent<Text>();

        player = GameObject.FindWithTag("Player");
        frame = GameObject.Find("TextFrame");
        image = frame.GetComponent<Image>();
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
                text.canvasRenderer.SetAlpha(255f);
                image.canvasRenderer.SetAlpha(255f);
                Invoke("Fade", 2);

                text.text = "FUCK OFF";
            }
        }
    }

    void Fade()
    {
        text.CrossFadeAlpha(1f, 1, false);
        image.CrossFadeAlpha(1f, 1, false);
    }
}
