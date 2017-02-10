using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shady : MonoBehaviour
{
    public GameObject choice;
    public GameObject player;

    public ItemEffects items;

    public bool goaway1 = true;
    public bool goaway2 = false;
    public bool goaway3 = false;

    public GameObject mainText;
    public Text text;
    public GameObject frame;
    public Image image;

    public bool choice2 = false;
    public bool choice3 = false;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        choice = GameObject.Find("Choice");

        items = player.GetComponent<ItemEffects>();

        mainText = GameObject.FindWithTag("text");
        text = mainText.GetComponent<Text>();
        frame = GameObject.Find("TextFrame");
        image = frame.GetComponent<Image>();

        choice.SetActive(false);
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
                if (goaway1 == true)
                {
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);
                    Invoke("Fade", 3);

                    text.text = "Shady person: What do you want? Go away!";
                }
                if (items.gotkey == true && goaway2 == false)
                {
                    goaway1 = false;
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);
                    Invoke("Fade", 2);

                    text.text = "Shady person: I could modify that key of yours. I'll give you a discount... 3 rupies.";

                    Cursor.visible = true;
                    choice.SetActive(true);
                    Time.timeScale = 0;
                }
                if (items.gotkey2 == true)
                {
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);
                    Invoke("Fade", 2);

                    text.text = "Shady person: I could modify your key back to how it was for, say ...50 rupies.";

                    Cursor.visible = true;
                    choice.SetActive(true);
                    Time.timeScale = 0;
                }
                if (goaway2 == true && items.gotmanual == false)
                {
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);
                    Invoke("Fade", 2);

                    text.text = "Shady person: We are done... for now.";
                }
                if (goaway2 == true && items.gotmanual == true)
                {
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);
                    Invoke("Fade", 2);

                    text.text = "Shady person: Now that we are friends, want me to translate that chinese manual for 60 rupies?";

                    Cursor.visible = true;
                    choice.SetActive(true);
                    Time.timeScale = 0;
                }
                if (goaway3 == true)
                {
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);
                    Invoke("Fade", 3);

                    text.text = "Shady person: Since I took all your money, here's a tip: keep searching trash, you may find something.";
                }

            }
        }
    }



    void Fade()
    {
        text.CrossFadeAlpha(1f, 1, false);
        image.CrossFadeAlpha(1f, 1, false);
    }

    public void Yes()
    {
        if (choice2 == false && choice3 == false)
        {
            if (items.rupies > 2)
            {
                items.rupies -= 3;
                items.gotkey = false;
                items.gotkey2 = true;

                text.canvasRenderer.SetAlpha(255f);
                image.canvasRenderer.SetAlpha(255f);
                Invoke("Fade", 2);

                text.text = "Shady person: Pleasure doing buisness.";

                Cursor.visible = false;
                Time.timeScale = 1;
                choice.SetActive(false);
                choice2 = true;
            }
            else
            {
                text.canvasRenderer.SetAlpha(255f);
                image.canvasRenderer.SetAlpha(255f);
                Invoke("Fade", 2);

                text.text = "Shady person: You don't even have 3 rupies trash...";

                Cursor.visible = false;
                choice.SetActive(false);
                Time.timeScale = 1;
            }
        }
        else if (choice2 == true && choice3 == false)
        {
            if(items.rupies > 49)
            {
                items.rupies -= 50;
                items.gotkey = true;
                items.gotkey2 = false;

                text.canvasRenderer.SetAlpha(255f);
                image.canvasRenderer.SetAlpha(255f);
                Invoke("Fade", 2);

                text.text = "Shady person: Good rid... err I mean thank you.";

                Cursor.visible = false;
                choice.SetActive(false);
                Time.timeScale = 1;

                choice3 = true;
                goaway2 = true;
            }
            else
            {
                text.canvasRenderer.SetAlpha(255f);
                image.canvasRenderer.SetAlpha(255f);
                Invoke("Fade", 2);

                text.text = "Shady person: Too expensive for you, trash?";

                Cursor.visible = false;
                choice.SetActive(false);
                Time.timeScale = 1;
            }
        }
        else //if (choice3 == true)
        {
            if (items.rupies > 59)
            {
                items.rupies -= 60;
                items.gotmanual = false;
                items.gotmanualx = true;

                text.canvasRenderer.SetAlpha(255f);
                image.canvasRenderer.SetAlpha(255f);
                Invoke("Fade", 2);

                text.text = "Shady person: Alright, I translated it to english.";

                Cursor.visible = false;
                choice.SetActive(false);
                Time.timeScale = 1;

                goaway3 = true;
            }
            else
            {
                text.canvasRenderer.SetAlpha(255f);
                image.canvasRenderer.SetAlpha(255f);
                Invoke("Fade", 2);

                text.text = "Shady person: Not enough money? I hope you have fun learning Chinese, trash.";

                Cursor.visible = false;
                choice.SetActive(false);
                Time.timeScale = 1;
            }    
        }
    }

    public void No()
    {
        text.canvasRenderer.SetAlpha(255f);
        image.canvasRenderer.SetAlpha(255f);
        Invoke("Fade", 2);

        text.text = "Shady person: Your loss, trash.";

        Cursor.visible = false;
        choice.SetActive(false);
        Time.timeScale = 1;
    }
}
