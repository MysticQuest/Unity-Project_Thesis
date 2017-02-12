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

    //public float alpha;
    public float fadetimer;

    // Use this for initialization
    void Start()
    {
        mainText = GameObject.FindWithTag("text");
        text = mainText.GetComponent<Text>();

        player = GameObject.FindWithTag("Player");
        items = player.GetComponent<ItemEffects>();
        frame = GameObject.Find("TextFrame");
        image = frame.GetComponent<Image>();

        InvokeRepeating("Roll", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        /*alpha = text.canvasRenderer.GetAlpha();

        fadetimer += Time.deltaTime;

        if (fadetimer >= 5)
        {
            text.CrossFadeAlpha(1f, 2, false);
            image.CrossFadeAlpha(1f, 2, false);
        }*/
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (random < 51)
                {
                    fadetimer = 0;
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);

                    text.text = "Nothing useful in here.";
                    
                }
                if (random > 100 && random < 201)
                {
                    fadetimer = 0;
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);

                    text.text = "There's nothing I can do with these!";
                    
                }
                if (random > 200 && random < 301)
                {
                    fadetimer = 0;
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);

                    text.text = "A bunch of useless stuff...";
                    
                }
                if (random > 300 && random < 401)
                {
                    fadetimer = 0;
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);

                    text.text = "I can't use this trash!";
                    
                }
                if (random > 400 && random < 500)
                {
                    fadetimer = 0;
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);

                    text.text = "Were you expecting to find treasure? Seriously...";
                    
                }
                if (random == 500 && items.gotcape == false)
                {
                    fadetimer = 0;
                    items.gotcape = true;

                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);

                    text.text = "Found Etheral Cape! Better not glitch out the game with this...";
                    
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            text.CrossFadeAlpha(1f, 2, false);
            image.CrossFadeAlpha(1f, 2, false);
        }
    }

    public void Roll()
    {
        random = Random.Range(1, 251);
    }
}
/*    void Fade()
    {
        text.CrossFadeAlpha(1f, 2, false);
        image.CrossFadeAlpha(1f, 2, false);
    }
*/

