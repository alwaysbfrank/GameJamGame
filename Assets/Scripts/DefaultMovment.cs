using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMovment : MonoBehaviour
{
    public int speed;
    public int jumpForce;
    public int sprintSpeed;
    public int fallDamageThreshold;
    public bool isStone;

    private Rigidbody2D rb;
    //private bool isGrounded;
    private int defultSpeed;
    private SpriteRenderer sr;
    private float maxYVel;
    //private Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        defultSpeed = speed;
        //isGrounded = true;
        isStone = false;
        //animator = GetComponent<Animator>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        Move();
        Jump();
        Sprint();
    }

    void Move()
    {
        float xDisplacement = Input.GetAxis("Horizontal");

        if (xDisplacement > 0)
        {
            sr.flipX = false;
        }
        else if (xDisplacement < 0)
        {
            sr.flipX = true;
        }

        Vector3 displacementVector = new Vector3(xDisplacement, 0, 0);
        transform.Translate(displacementVector * speed * Time.deltaTime);

        //animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
        {
            //isGrounded = false;
            maxYVel = 0;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            //animator.SetBool("Jump", true);
        }
        if (rb.velocity.y != 0)
        {
            if (rb.velocity.y < maxYVel)
            {
                maxYVel = rb.velocity.y;
            }
        }
        if (maxYVel < fallDamageThreshold && rb.velocity.y == 0)
        {
            //Destroy(gameObject);
            Debug.Log("Death");
        }
    }

    void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && rb.velocity.y == 0)
        {
            speed = sprintSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = defultSpeed;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        isGrounded = true;
    //        //animator.SetBool("Jump", false);
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        isGrounded = false;
    //    }
    //}
}
