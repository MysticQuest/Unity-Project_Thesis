using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barrel : MonoBehaviour
{
    public GameObject mainText;
    public Text text;
    public GameObject frame;
    public Image image;

    public GameObject player;
    public ItemEffects items;

    // Use this for initialization
    void Start()
    {
        mainText = GameObject.FindWithTag("text");
        text = mainText.GetComponent<Text>();

        player = GameObject.FindWithTag("Player");
        items = player.GetComponent<ItemEffects>();
        frame = GameObject.Find("TextFrame");
        image = frame.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player && items.gotgloves == false)
        {
            text.canvasRenderer.SetAlpha(255f);
            image.canvasRenderer.SetAlpha(255f);
            Invoke("Fade", 2);

            text.text = "It's way too heavy to move...";
        }
    }
    void Fade()
    {
        text.CrossFadeAlpha(1f, 1, false);
        image.CrossFadeAlpha(1f, 1, false);
    }
}
