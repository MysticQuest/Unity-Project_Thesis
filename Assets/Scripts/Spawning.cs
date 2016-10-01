using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour
{

    public float timer1 = 0.0f;
    public float timer2 = 0.0f;
    public float timer3 = 0.0f;
    float bfreq;
    float kfreq;
    float mfreq;

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
    public int bsum = 0;
    public int msum = 0;
    public int ksum = 0;
    public int bmax = 50;
    public int mmax = 15;
    public int kmax = 3;

    public GameObject genericBat;
    public GameObject Bat;
    public GameObject genericKnight;
    public GameObject Knight;
    public GameObject genericMonster;
    public GameObject Monster;

    void Start()
    {
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
        bfreq = Random.Range(3, 6);
        mfreq = Random.Range(6, 9);
        kfreq = Random.Range(15, 20);

        timer1 += Time.deltaTime;
        timer2 += Time.deltaTime;
        timer3 += Time.deltaTime;

        if (timer1 >= mfreq)
            SpawnMonster();

        if (timer2 >= bfreq)
            SpawnBat();

        if (timer3 >= kfreq)
            SpawnKnight();

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

        if (bsum > bmax)
        {
            return;
        }
        genericBat = Instantiate(Bat, location.position, location.rotation) as GameObject;
        genericBat.GetComponent<Rigidbody>();
        bsum += 1;
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

        if (msum > mmax)
        {
            return;
        }
        genericMonster = Instantiate(Monster, location.position, location.rotation) as GameObject;
        genericMonster.GetComponent<Rigidbody>();
        msum += 1;
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

        if (ksum > kmax)
        {
            return;
        }
        genericKnight = Instantiate(Knight, location.position, location.rotation) as GameObject;
        genericKnight.GetComponent<Rigidbody>();
        ksum += 1;
    }

}


