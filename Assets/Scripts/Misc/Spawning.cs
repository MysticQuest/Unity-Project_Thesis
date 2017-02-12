using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour
{
    public DayNight globaltimer;
    public DayNight daycount;

    public float timer1 = 0.0f;
    public float timer2 = 0.0f;
    public float timer3 = 0.0f;
    public float timer4 = 0.0f;
    public float bfreq;
    public float kfreq;
    public float mfreq;

    //public Rigidbody2D fail;

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject spawn5;
    public GameObject spawn6;
    public GameObject spawnA;
    public GameObject spawnB;

    public Transform tspawn1;
    public Transform tspawn2;
    public Transform tspawn3;
    public Transform tspawn4;
    public Transform tspawn5;
    public Transform tspawn6;
    public Transform tspawnA;
    public Transform tspawnB;

    public Transform location;
    public GameObject[] bsum;
    public GameObject[] msum;
    public GameObject[] ksum;
    public int bmax = 10;
    public int mmax = 5;
    public int kmax = 3;

    public GameObject genericBat;
    public GameObject Bat;
    public GameObject genericKnight;
    public GameObject Knight;
    public GameObject genericMonster;
    public GameObject Monster;
    public GameObject Boss;
    public GameObject genericBoss;

    public bool bossup = false;

    void Start()
    {
        globaltimer = GameObject.Find("Canvas").GetComponent<DayNight>();
        daycount = GameObject.Find("Canvas").GetComponent<DayNight>();

        spawn1 = GameObject.Find("spawn1");
        spawn2 = GameObject.Find("spawn2");
        spawn3 = GameObject.Find("spawn3");
        spawn4 = GameObject.Find("spawn4");
        spawn5 = GameObject.Find("spawn5");
        spawn6 = GameObject.Find("spawn6");
        spawnA = GameObject.Find("spawnA");
        spawnB = GameObject.Find("spawnB");

        tspawn1 = spawn1.GetComponent<Transform>();
        tspawn2 = spawn2.GetComponent<Transform>();
        tspawn3 = spawn3.GetComponent<Transform>();
        tspawn4 = spawn4.GetComponent<Transform>();
        tspawn5 = spawn5.GetComponent<Transform>();
        tspawn6 = spawn6.GetComponent<Transform>();
        tspawnA = spawnA.GetComponent<Transform>();
        tspawnB = spawnB.GetComponent<Transform>();


    }

    void Update()
    {
        bfreq = Random.Range(5, 7);
        kfreq = Random.Range(15, 20);
        if (daycount.day < 2)
        {
            mfreq = Random.Range(12, 16);
        }
        else
        {
            mfreq = Random.Range(6, 9);
        }


        timer1 += Time.deltaTime;
        timer2 += Time.deltaTime;
        timer3 += Time.deltaTime;

        bsum = GameObject.FindGameObjectsWithTag("Bat");
        msum = GameObject.FindGameObjectsWithTag("Monster");
        ksum = GameObject.FindGameObjectsWithTag("Knight");

        if (timer1 >= mfreq && globaltimer.timer > 120f && globaltimer.timer < 200f)
            SpawnMonster();

        if (timer2 >= bfreq)
            SpawnBat();

        if (timer3 >= kfreq) //&& daycount.day > 2)
            SpawnKnight();

        if (daycount.day > 2 && globaltimer.timer > 170f && bossup == false)
            SpawnBoss();

    }

    void SpawnBat()
    {
        timer2 = 0;

        int randomPick = Random.Range(1, 7);

        if (randomPick == 1)
        {
            location = tspawn1;
        }
        if (randomPick == 2)
        {
            location = tspawn2;
        }
        if (randomPick == 3)
        {
            location = tspawn3;
        }
        if (randomPick == 4)
        {
            location = tspawn4;
        }
        if (randomPick == 5)
        {
            location = tspawn5;
        }
        if (randomPick == 6)
        {
            location = tspawn6;
        }

        if (bsum.Length < bmax)
        {
            genericBat = Instantiate(Bat, location.position, location.rotation) as GameObject;
            genericBat.GetComponent<Rigidbody>();
        }
        else return;
    }

    void SpawnMonster()
    {
        timer1 = 0;

        int randomPick = Random.Range(1, 3);

        if (randomPick == 1)
        {
            location = tspawnA;
        }
        if (randomPick == 2)
        {
            location = tspawnB;
        }

        if (msum.Length < mmax)
        {
            genericMonster = Instantiate(Monster, location.position, location.rotation) as GameObject;
            genericMonster.GetComponent<Rigidbody>();
        }
    }

    void SpawnKnight()
    {
        timer3 = 0;

        int randomPick = Random.Range(1, 3);

        if (randomPick == 1)
        {
            location = tspawnA;
        }
        if (randomPick == 2)
        {
            location = tspawnB;
        }

        if (ksum.Length < kmax)
        {
            genericKnight = Instantiate(Knight, location.position, location.rotation) as GameObject;
            genericKnight.GetComponent<Rigidbody>();
        }
    }

    void SpawnBoss()
    {
        location = tspawnB;
        bossup = true;
        genericBoss = Instantiate(Boss, location.position, location.rotation) as GameObject;
        genericBoss.GetComponent<Rigidbody>();
    }

}


