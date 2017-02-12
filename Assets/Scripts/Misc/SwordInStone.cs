using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordInStone : MonoBehaviour {

    public Animator anim;
    public GameObject player;
    public ItemEffects items;
    public PlayerAttack attack;
    public bool gotstone = false;

    public AudioSource effectplayer;
    public AudioClip chorus;
    public AudioClip upgrade;

    public PlayerMovement pmove;

    public GameObject mainText;
    public Text text;
    public GameObject frame;
    public Image image;

    // Use this for initialization
    void Start ()
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

        effectplayer.clip = chorus;
        effectplayer.loop = chorus;
        effectplayer.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            if (Input.GetKeyDown(KeyCode.E) && gotstone == false)
            {
                if (items.gotgloves == true)
                {
                    effectplayer.clip = upgrade;
                    effectplayer.Play();
                    anim.SetBool("HasSword", true);
                    gotstone = true;

                    pmove.enabled = false;
                    anim.enabled = false;

                    attack.damage += 10;
                    //anim.Play("Idle.idle_down");
                    Invoke("Unfreeze",4);
                    Destroy(gameObject,4);

                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);
                    //Invoke("Fade", 2);

                    text.text = "The sword is coming out...!";
                }
                else
                {
                    text.canvasRenderer.SetAlpha(255f);
                    image.canvasRenderer.SetAlpha(255f);
                    //Invoke("Fade", 2);

                    text.text = "I am not strong enough to pull it out of the stone...";
                }
            }
        }
    }

    void Unfreeze()
    {
        pmove.enabled = true;
        anim.enabled = true;
    }
    void Fade()
    {
        text.CrossFadeAlpha(1f, 1, false);
        image.CrossFadeAlpha(1f, 1, false);
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
