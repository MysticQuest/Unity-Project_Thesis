using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shady : MonoBehaviour
{
    public GameObject choice;
    public GameObject player;

    public GameObject house;
    public HouseHealth houseHealth;

    public GameObject selection;
    public GameObject choiceA;

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
        choiceA = GameObject.Find("ChoiceA");
        selection = GameObject.Find("Selection");

        items = player.GetComponent<ItemEffects>();

        mainText = GameObject.FindWithTag("text");
        text = mainText.GetComponent<Text>();
        frame = GameObject.Find("TextFrame");
        image = frame.GetComponent<Image>();

        house = GameObject.FindWithTag("HouseHitbox");
        houseHealth = house.GetComponent<HouseHealth>();

        choice.SetActive(false);
        choiceA.SetActive(false);
        selection.SetActive(false);
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
                text.canvasRenderer.SetAlpha(255f);
                image.canvasRenderer.SetAlpha(255f);

                text.text = "Shady person: What do you want?";

                Cursor.visible = true;
                selection.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        choice.SetActive(false);
        choiceA.SetActive(false);
        selection.SetActive(false);
        Cursor.visible = false;
        text.CrossFadeAlpha(1f, 2, false);
        image.CrossFadeAlpha(1f, 2, false);
    }



    public void Fade()
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
                //Invoke("Fade", 2);

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
                //Invoke("Fade", 2);

                text.text = "Shady person: You don't even have 3 rupies...?";

                Cursor.visible = false;
                choice.SetActive(false);
                Time.timeScale = 1;
            }
        }
        else if (choice2 == true && choice3 == false)
        {
            if (items.rupies > 29)
            {
                items.rupies -= 30;
                items.gotkey = true;
                items.gotkey2 = false;

                text.canvasRenderer.SetAlpha(255f);
                image.canvasRenderer.SetAlpha(255f);
                //Invoke("Fade", 2);

                text.text = "Shady person: Thanks for the transaction.";

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
                //Invoke("Fade", 2);

                text.text = "Shady person: Too expensive for you?";

                Cursor.visible = false;
                choice.SetActive(false);
                Time.timeScale = 1;
            }
        }
        else //if (choice3 == true)
        {
            if (items.rupies > 39)
            {
                items.rupies -= 40;
                items.gotmanual = false;
                items.gotmanualx = true;

                text.canvasRenderer.SetAlpha(255f);
                image.canvasRenderer.SetAlpha(255f);
                //Invoke("Fade", 2);

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
                //Invoke("Fade", 2);

                text.text = "Shady person: You don't have enough money. I hope you have fun learning Chinese.";

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
        //Invoke("Fade", 2);

        text.text = "Shady person: Your loss...";

        Cursor.visible = false;
        choice.SetActive(false);
        Time.timeScale = 1;
    }



    public void Help()
    {

        if (goaway1 == true)
        {
            text.canvasRenderer.SetAlpha(255f);
            image.canvasRenderer.SetAlpha(255f);
            //Invoke("Fade", 3);

            text.text = "Shady person: What do you want? Go away!";
            selection.SetActive(false);
            Cursor.visible = false;
            Time.timeScale = 1;
        }
        if (items.gotkey == true && goaway2 == false)
        {
            goaway1 = false;
            text.canvasRenderer.SetAlpha(255f);
            image.canvasRenderer.SetAlpha(255f);
            //Invoke("Fade", 3);

            text.text = "Shady person: I could modify that key of yours. I'll give you a discount... 3 rupies.";

            Cursor.visible = true;
            selection.SetActive(false);
            choice.SetActive(true);
            Time.timeScale = 0;
            
        }
        if (items.gotkey2 == true)
        {
            text.canvasRenderer.SetAlpha(255f);
            image.canvasRenderer.SetAlpha(255f);
            //Invoke("Fade", 2);

            text.text = "Shady person: I could modify your key back to how it was for, say ...30 rupies.";

            Cursor.visible = true;
            selection.SetActive(false);
            choice.SetActive(true);
            Time.timeScale = 0;
        }
        if (goaway2 == true && items.gotmanual == false)
        {
            text.canvasRenderer.SetAlpha(255f);
            image.canvasRenderer.SetAlpha(255f);
            //Invoke("Fade", 2);

            text.text = "Shady person: We are done... for now.";
            selection.SetActive(false);
            Cursor.visible = false;
            Time.timeScale = 1;
        }
        if (goaway2 == true && items.gotmanual == true)
        {
            text.canvasRenderer.SetAlpha(255f);
            image.canvasRenderer.SetAlpha(255f);
            //Invoke("Fade", 2);

            text.text = "Shady person: Want me to translate that chinese manual you have for 40 rupies?";

            Cursor.visible = true;
            selection.SetActive(false);
            choice.SetActive(true);
            Time.timeScale = 0;
        }
        if (goaway3 == true)
        {
            text.canvasRenderer.SetAlpha(255f);
            image.canvasRenderer.SetAlpha(255f);
            //Invoke("Fade", 3);

            text.text = "Shady person: Since I took all your money, here's a tip: keep searching useless stuff, you may find something.";
            selection.SetActive(false);
            Cursor.visible = false;
            Time.timeScale = 1;
        }
    }

    public void Repair()
    {
        text.canvasRenderer.SetAlpha(255f);
        image.canvasRenderer.SetAlpha(255f);
        //Invoke("Fade", 2);

        text.text = "Shady person: I could fortify your house a little for 20 rupies, no guarantees.";

        Cursor.visible = true;
        selection.SetActive(false);
        choiceA.SetActive(true);
        Time.timeScale = 0;
    }

    public void Yes1()
    {
        if (items.rupies > 19)
        {
            items.rupies -= 20;
            houseHealth.currentHealth += 150;

            text.canvasRenderer.SetAlpha(255f);
            image.canvasRenderer.SetAlpha(255f);
            //Invoke("Fade", 2);

            text.text = "Shady person: There, good as new!";

            Cursor.visible = false;
            choiceA.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            text.canvasRenderer.SetAlpha(255f);
            image.canvasRenderer.SetAlpha(255f);
            //Invoke("Fade", 2);

            text.text = "Shady person: Want me to do it for free? Dream on.";

            Cursor.visible = false;
            choiceA.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void No1()
    {
        text.canvasRenderer.SetAlpha(255f);
        image.canvasRenderer.SetAlpha(255f);
        //Invoke("Fade", 2);

        text.text = "Shady person: Don't blame me if your house gets destroyed...";

        Cursor.visible = false;
        choiceA.SetActive(false);
        Time.timeScale = 1;

    }
}



