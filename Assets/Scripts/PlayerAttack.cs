using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    Rigidbody2D body1;
    Animator anim;

    void Start () {

        body1 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
	
	void Update () {
        if (Input.GetMouseButton(0))
        
           anim.SetBool("IsAttacking",true);
        
        else 
           anim.SetBool("IsAttacking",false);
        
	}
}
