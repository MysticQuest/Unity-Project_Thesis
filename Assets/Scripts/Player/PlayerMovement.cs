using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D body1;
    public Animator anim;
    //public Animation anim2;
    public bool isAttacking;
    public float speed = 1f;
    public Vector2 movement_vector;

    public GameObject sword;
    public SpriteRenderer layer;

    public GameObject player;

    public float dirx;
    public float diry;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        body1 = GetComponent<Rigidbody2D>();
        anim = player.GetComponent<Animator>();

        //anim2 = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        isAttacking = anim.GetBool("IsAttacking");
        movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("IsWalking", true);
            anim.SetFloat("Input_x", movement_vector.x);
            anim.SetFloat("Input_y", movement_vector.y);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

        //sword layer problem

        diry = anim.GetFloat("Input_y");
        dirx = anim.GetFloat("Input_x");
        sword = GameObject.Find("sword");
        if (sword != null)
        {
            layer = sword.GetComponent<SpriteRenderer>();
            if (diry < 0)
            {
                layer.sortingOrder = 6;
            }
            else layer.sortingOrder = 5;
        }
    


        //

        if (isAttacking == false)
        {
            body1.MovePosition(body1.position + movement_vector * Time.deltaTime * 1.0F * speed);
        }
        else
        {
            body1.MovePosition(body1.position + movement_vector * Time.deltaTime * 0.5F * speed);
        }
    }
}
