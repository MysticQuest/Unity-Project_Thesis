using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : MonoBehaviour
{

    public GameObject fireball;
    public GameObject genericfireball;
    public GameObject player;
    public GameObject fire;

    public Rigidbody2D body;
    public Transform target;
    public Transform location;
    public Transform source;

    public float speed = 0.5f;
    //public Vector3 vector;

    public Animator bossanim;
    public Boss bossC;
    public GameObject boss;
    public float firetimer;
    private Transform bosspos;

    public AudioSource effectplayer;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        source = GetComponent<Transform>();
        location = source.transform;

        boss = GameObject.Find("Boss");
        bossanim = boss.GetComponent<Animator>();

        bosspos = boss.GetComponent<Transform>();
        bossC = boss.GetComponent<Boss>();

        effectplayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        firetimer += Time.deltaTime;
        target = player.transform;

        if (firetimer > 1 && bossanim.GetBool("IsAttacking") && Vector2.Distance(bosspos.position, target.position) < bossC.aggroRange)
        {
            Fireball();
            firetimer = 0;
        }
        //location.LookAt(target);

        //Vector3 difference = target.position - fire.transform.position;
        //float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        //vector = new Vector3(0, 0, target.z);
        //location.position = vector; 

        float AngleRad = Mathf.Atan2(target.transform.position.y - source.transform.position.y, target.transform.position.x - source.transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        location.rotation = Quaternion.Euler(0, 0, AngleDeg + 90);
    }


    public void Fireball()
    {
        {
            genericfireball = Instantiate(fireball, location.position, location.rotation) as GameObject;
            //genericfireball.GetComponent<Rigidbody2D>();
            body = genericfireball.GetComponent<Rigidbody2D>();

            body.velocity = (target.position - location.position).normalized * speed;

            effectplayer.Play();

            //explosion attempt
            //StartCoroutine(Explosion());
            //body.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

            //Destroy(genericfireball, 1f);

            //projectile shoot attempts  
            //body.velocity = Vector2.MoveTowards(location.position, target.position, speed * Time.deltaTime).normalized;
            //body.velocity = new Vector2(target.position.x, target.position.y);
            //body.velocity = transform.forward * speed;
            //body.AddForce(body.velocity, (ForceMode2D.Force));
            //genericfireball.GetComponent<Rigidbody2D>().AddForce(player.transform.forward * speed * Time.deltaTime);
        }
    }

    //IEnumerator Explosion()
    //{
    //    yield return new WaitForSeconds(2);
    //}
}
