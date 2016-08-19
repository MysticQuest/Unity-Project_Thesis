using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour
{

    public float timer = 0.0f;
    float freq;

    //public Rigidbody2D fail;

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject spawn5;
    public GameObject spawn6;

    public Transform tspawn1;
    public Transform tspawn2;
    public Transform tspawn3;
    public Transform tspawn4;
    public Transform tspawn5;
    public Transform tspawn6;

    public Transform location;
    public int sum = 0;
    public int max = 60;

    public GameObject genericBat;
    public GameObject Bat;

    void Start()
    {
        spawn1 = GameObject.Find("spawn1");
        spawn2 = GameObject.Find("spawn2");
        spawn3 = GameObject.Find("spawn3");
        spawn4 = GameObject.Find("spawn4");
        spawn5 = GameObject.Find("spawn5");
        spawn6 = GameObject.Find("spawn6");

        freq = Random.Range(1, 3);

        tspawn1 = spawn1.GetComponent<Transform>();
        tspawn2 = spawn2.GetComponent<Transform>();
        tspawn3 = spawn3.GetComponent<Transform>();
        tspawn4 = spawn4.GetComponent<Transform>();
        tspawn5 = spawn5.GetComponent<Transform>();
        tspawn6 = spawn6.GetComponent<Transform>();
    }

    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= freq)

            Spawn();

    }

    void Spawn()
    {
        timer = 0;

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

        if (sum > max)
        {
            return;
        }
        genericBat = Instantiate(Bat, location.position, location.rotation) as GameObject;
        genericBat.GetComponent<Rigidbody>();
        sum += 1;
    }

}