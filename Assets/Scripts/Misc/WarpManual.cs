using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WarpManual : MonoBehaviour
{
    public Transform target;
    public ItemEffects items;
    public GameObject player;
    public GameObject keychest;

    public GameObject mainText;
    public Text text;

    public GameObject frame;
    public Image image;

    public PlayerMovement move;

    public GameObject black;
    public Image blackimage;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        items = player.GetComponent<ItemEffects>();

        mainText = GameObject.FindWithTag("text");
        text = mainText.GetComponent<Text>();
        frame = GameObject.Find("TextFrame");
        image = frame.GetComponent<Image>();

        move = player.GetComponent<PlayerMovement>();

        black = GameObject.Find("Black");
        blackimage = black.GetComponent<Image>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player.gameObject)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (items.gotkey == true)
                {
                    move.enabled = false;

                    blackimage.CrossFadeAlpha(255f, 1f, true);

                    Invoke("Teleport", 1);
                }
                if (items.gotkey == false && items.gotkey2 == false)
                {
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);
                    //Invoke("Fade", 2);

                    text.text = "It's locked. I think I saw a bat running off with my keys earlier...";
                }
                if (items.gotkey == false && items.gotkey2 == true)
                {
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);
                    //Invoke("Fade", 2);

                    text.text = "They key doesn't fit the lock anymore...";

                } 
            }
        }
    }
    void Fade()
    {
        text.CrossFadeAlpha(1f, 1, false);
        image.CrossFadeAlpha(1f, 1, false);
    }

    public void Teleport()
    {
        Debug.Log("TELEPORT");
        //yield return new WaitForSeconds(2);
        //Time.timeScale = 1;
        player.transform.position = target.position;
        move.enabled = true;

        blackimage.CrossFadeAlpha(1f, 1f, true);

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            text.CrossFadeAlpha(1f, 2, false);
            image.CrossFadeAlpha(1f, 2, false);
        }
    }
}
