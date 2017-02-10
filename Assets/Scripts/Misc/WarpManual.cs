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

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        items = player.GetComponent<ItemEffects>();

        mainText = GameObject.FindWithTag("text");
        text = mainText.GetComponent<Text>();
        frame = GameObject.Find("TextFrame");
        image = frame.GetComponent<Image>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (items.gotkey == true)
                {
                    other.transform.position = target.position;
                }
                if (items.gotkey == false && items.gotkey2 == false)
                {
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);
                    Invoke("Fade", 2);

                    text.text = "It's locked. I think I saw a bat running off with my keys earlier...";
                }
                if (items.gotkey == false && items.gotkey2 == true)
                {
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);
                    Invoke("Fade", 2);

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
}