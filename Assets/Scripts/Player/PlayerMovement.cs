using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D body1;
    public Animator anim;
    public bool isAttacking;


    // Use this for initialization
    void Start()
    {

        body1 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isAttacking = anim.GetBool("IsAttacking");
        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("IsWalking", true);
            anim.SetFloat("Input_x", movement_vector.x);
            anim.SetFloat("Input_y", movement_vector.y);
        }
        else {
            anim.SetBool("IsWalking", false);
        }

        if (isAttacking == false)
        {
            body1.MovePosition(body1.position + movement_vector * Time.deltaTime * 1.0F);
        }
        else
        {
            body1.MovePosition(body1.position + movement_vector * Time.deltaTime * 0.5F);
        }
    }
}