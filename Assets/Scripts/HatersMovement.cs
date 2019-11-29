using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatersMovement : MonoBehaviour
{

    public float movementSpeed;
    public float JumpHeight;

    public Transform target;

    Rigidbody2D rb;
    Animator anim;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, movementSpeed * Time.deltaTime);

        if(this.gameObject.transform.position.y < - 30f)
        {
            Destroy(this.gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "Ground" || col.transform.tag == "Ice")
        {
            rb.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
        }
    }

   /* void OnCollisionStay2D(Collision2D col)
    {
        if(col.transform.tag == "Ground")
        {
            anim.SetBool("IsJumping", false);
            anim.SetFloat("Walk", 1);
        }
    }*/

    /*void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "Ground")
        {
            anim.SetBool("IsJumping", true);
            anim.SetFloat("Walk", 0);
        }
    }*/

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag == "Player")
        {
            anim.SetBool("Happy", true);
        }
    }

    
}
