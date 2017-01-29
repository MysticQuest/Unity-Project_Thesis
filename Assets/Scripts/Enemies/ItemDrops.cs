using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrops : MonoBehaviour {

    public GameObject itemDrop1;
    public GameObject itemDrop2;
    public GameObject itemDrop3;
    public GameObject genericDrop1;
    public GameObject genericDrop2;
    public GameObject genericDrop3;
    public int randomDrop;

    public GameObject bat;
    public Health health;

    // Use this for initialization
    void Start ()
    {
        health = this.GetComponent<Health>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        randomDrop = Random.Range(1, 101);
        if (itemDrop1 != null)
        {
            genericDrop1 = Instantiate(itemDrop1, transform.position, Quaternion.identity) as GameObject;
        }
	}
}
