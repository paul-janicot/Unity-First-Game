using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpforce = 7f;
    Animator animator;
    bool walk = false;
    bool jump = false;
    bool isJumping = false;
    Rigidbody2D rigidbody;
   


    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jump && rigidbody.velocity.y == 0) //< 0.2f && rigidbody.velocity.y > -0.2f)
        {
            jump = false;
            animator.SetBool("Jump", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!jump)
            {
                animator.SetBool("Jump", true);
                jump = true;
                rigidbody.velocity += new Vector2(0, jumpforce);
            }



        }

        else if (Input.GetKey(KeyCode.D))
        {
            if (!walk)
            {
                animator.SetBool("Walk", true);
                walk = true;
            }
            GetComponent<SpriteRenderer>().flipX = false;
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            if (!walk)
            {
                animator.SetBool("Walk", true);
                walk = true;
            }
            animator.SetBool("Walk", true);
            GetComponent<SpriteRenderer>().flipX = true;
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            if (walk)
            {
                animator.SetBool("Walk", false);
                walk = false;
            }

        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(gameObject.name + " has hit " + collision.gameObject.name);

    }
 
}
