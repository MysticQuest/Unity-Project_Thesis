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

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        items = player.GetComponent<ItemEffects>();

        mainText = GameObject.FindWithTag("text");
        text = mainText.GetComponent<Text>();
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
                else
                {
                    text.text = "It's locked. I think I saw a bat running off with my keys earlier...";
                }
            }
        }
    }
}