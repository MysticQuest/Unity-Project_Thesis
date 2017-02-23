using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SceneMusic : MonoBehaviour
{
    public AudioSource musicplayer;

    public AudioClip day;
    public AudioClip night;
    public AudioClip menu;
    public AudioClip boss;
    public AudioClip gameover;
    public AudioClip victory;

    public DayNight time;
    public float timer;

    public GameObject canvas;
    public GameObject player;

    public bool bossclip = false;

    public Health health;

    public GameObject house;

    public GameObject black;
    public Image blackimage;
    public GameObject ending;
    public Text endtext;

    public GameObject maincam;
    public AudioListener listen;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        musicplayer = GetComponent<AudioSource>();
        Day();
        player = GameObject.FindWithTag("Player");

        health = GetComponent<Health>();

        house = GameObject.FindWithTag("HouseHitbox");

        black = GameObject.Find("Black");
        blackimage = black.GetComponent<Image>();
        ending = GameObject.Find("Ending");
        endtext = ending.GetComponent<Text>();

        maincam = GameObject.Find("Main Camera");
        listen = maincam.GetComponent<AudioListener>();

        listen.enabled = false;
    }

    void Update ()
    {
        time = canvas.GetComponent<DayNight>();
        timer = time.timer;
        if (time.day > 2 && timer > 160f)
        {
            bossclip = true;
        }

        if (timer > 105f && musicplayer.clip != night && (player != null && house != null) && bossclip == false)
        {
            Invoke("Night", 4);
            musicplayer.volume -= Time.deltaTime * 0.017f;            
        }
        else if (musicplayer.clip != day && timer < 100f && (player != null && house != null))
        {
            Invoke("Day", 4);
            musicplayer.volume -= Time.deltaTime * 0.017f;
        }
        else if (musicplayer.clip != boss && timer > 160f && time.day > 2 && (player != null && house != null))
        {
            Invoke("Boss", 10);
            musicplayer.volume -= Time.deltaTime * 0.017f;
        }
        else if (musicplayer.clip != gameover && (player == null || house == null))
        {
            Gameover();
        }
    }

    public void Day()
    {
        musicplayer.clip = day;
        musicplayer.Play();
        if (musicplayer.volume < 0.068f)
        {
            musicplayer.volume += Time.deltaTime * 0.017f;
        }
        
    }

    public void Night()
    {
        musicplayer.clip = night;
        musicplayer.Play();
        while (musicplayer.volume < 0.068f)
        {
            musicplayer.volume += Time.deltaTime * 0.017f;
        }
    }

    public void Boss()
    {
        musicplayer.clip = boss;
        musicplayer.Play();
        musicplayer.volume = 0.70f;
        if (musicplayer.volume < 0.068f)
        {
            musicplayer.volume += Time.deltaTime * 0.017f;
        }
    }

    public void Gameover()
    {
        musicplayer.clip = gameover;
        musicplayer.Play();
        musicplayer.volume = 0.070f;

        blackimage.CrossFadeAlpha(255f, 2f, true);
        endtext.CrossFadeAlpha(255f, 3f, true);

        endtext.text = "Game Over";
        listen.enabled = true;

        Time.timeScale = 0;
    }

}