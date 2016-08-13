using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    Rigidbody2D body1;
    Animator anim;
//    public float damage = 50.0F;
    public float attackCooldown = 1F;
    public bool IsAttacking = false;

    void Start ()
    {

        body1 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
	
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("IsAttacking", true);
            IsAttacking = true;
        }
        
           
        
        else
        {
            anim.SetBool("IsAttacking", false);
            IsAttacking = false;
        }
               
	}

    void OnTriggerStay2D(Collider2D PlayerHit)
    {

        if (PlayerHit.gameObject.tag == "Enemy")
        {
            if (IsAttacking == true)
            {
                Debug.Log("You dealt some damage!");
                Destroy(PlayerHit.gameObject);
            }
        }
    }

    /*void AttackMechanics()
    {
        if (IsAttacking == true) return;
        IsAttacking = true;
        StartCoroutine("AttackCooldown");
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        IsAttacking = false;
    }
    */

}
