using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Useless : MonoBehaviour
{
    public GameObject mainText;
    public Text text;

    public GameObject player;

    public int random;
    public ItemEffects items;

    public GameObject frame;
    public Image image;

    // Use this for initialization
    void Start()
    {
        mainText = GameObject.FindWithTag("text");
        text = mainText.GetComponent<Text>();

        player = GameObject.FindWithTag("Player");
        items = player.GetComponent<ItemEffects>();
        frame = GameObject.Find("TextFrame");
        image = frame.GetComponent<Image>();

        InvokeRepeating("Roll", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
  
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (random < 51)
                {
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);
                    Invoke("Fade", 2);
                    text.text = "Nothing useful in here.";
                }
                if (random > 50 && random < 101)
                {
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);
                    Invoke("Fade", 2);
                    text.text = "There's nothing I can do with these!";
                }
                if (random > 100 && random < 151)
                {
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);
                    Invoke("Fade", 2);
                    text.text = "A bunch of useless stuff...";
                }
                if (random > 150 && random < 201)
                {
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);
                    Invoke("Fade", 2);
                    text.text = "I can't use this trash!";
                }
                if (random > 200 && random < 250)
                {
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);
                    Invoke("Fade", 2);
                    text.text = "Were you expecting to find treasure? Seriously...";
                }
                if (random == 250 && items.gotcape == false)
                {
                    items.gotcape = true;

                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);
                    Invoke("Fade", 2);

                    text.text = "Found Etheral Cape! Better not glitch out the game with this...";
                }
            }
        }
    }

    public void Roll()
    {
        random = Random.Range(1, 251);
    }
    void Fade()
    {
        text.CrossFadeAlpha(1f, 1, false);
        image.CrossFadeAlpha(1f, 1, false);
    }
}

