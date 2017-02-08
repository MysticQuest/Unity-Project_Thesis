using UnityEngine;
using System.Collections;

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

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        musicplayer = GetComponent<AudioSource>();
        Day();
        player = GameObject.FindWithTag("Player");
    }

    void Update ()
    {
        time = canvas.GetComponent<DayNight>();
        timer = time.timer;
        if (time.day > 2 && timer > 150f)
        {
            bossclip = true;
        }

        if (timer > 105f && musicplayer.clip != night && player != null && bossclip == false)
        {
            Invoke("Night", 4);
            musicplayer.volume -= Time.deltaTime * 0.017f;            
        }
        else if (musicplayer.clip != day && timer < 100f && player !=null)
        {
            Invoke("Day", 4);
            musicplayer.volume -= Time.deltaTime * 0.017f;
        }
        else if (musicplayer.clip != boss && timer > 150f && time.day > 2 && player != null)
        {
            Invoke("Boss", 10);
            musicplayer.volume -= Time.deltaTime * 0.017f;
        }
        else if (musicplayer.clip != gameover && player == null)
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
        if (musicplayer.volume < 0.068f)
        {
            musicplayer.volume += Time.deltaTime * 0.017f;
        }
    }

    public void Gameover()
    {
        musicplayer.clip = gameover;
        musicplayer.Play();
    }

}