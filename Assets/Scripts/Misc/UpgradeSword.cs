using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSword : MonoBehaviour
{

    public Animator anim;
    public GameObject player;
    public ItemEffects items;
    public PlayerAttack attack;
    public bool upgraded = false;

    public PlayerMovement pmove;

    public AudioSource effectplayer;
    public AudioClip upgrade;
    public AudioClip lava;

    public GameObject mainText;
    public Text text;
    public GameObject frame;
    public Image image;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        anim = player.GetComponent<Animator>();
        items = player.GetComponent<ItemEffects>();
        attack = player.GetComponent<PlayerAttack>();
        effectplayer = GetComponent<AudioSource>();

        pmove = player.GetComponent<PlayerMovement>();

        mainText = GameObject.FindWithTag("text");
        text = mainText.GetComponent<Text>();
        frame = GameObject.Find("TextFrame");
        image = frame.GetComponent<Image>();

        effectplayer.clip = lava;
        effectplayer.loop = lava;
        effectplayer.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            if (Input.GetKeyDown(KeyCode.E) && upgraded == false)
            {
                if (items.gotmanual == false && items.gotmanualx == true)
                {
                    effectplayer.clip = upgrade;
                    effectplayer.Play();
                    anim.SetBool("Upgraded", true);
                    upgraded = true;
                    attack.damage += 17;

                    pmove.enabled = false;
                    anim.enabled = false;
                    Invoke("Unfreeze", 4);

                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);
                    Invoke("Fade", 2);

                    text.text = "Sword upgraded!";
                }
                else if (items.gotmanual == true && items.gotmanualx == false)
                {
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);
                    Invoke("Fade", 2);

                    text.text = "The manual is in Chinese... I have to translate it somehow.";
                }
                else if (items.gotmanual == false && items.gotmanual == false)
                {
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);
                    Invoke("Fade", 2);

                    text.text = "I don't know how to use this...";
                }
            }
        }
    }
    void Fade()
    {
        text.CrossFadeAlpha(1f, 1, false);
        image.CrossFadeAlpha(1f, 1, false);
    }
    void Unfreeze()
    {
        pmove.enabled = true;
        anim.enabled = true;
    }
}
