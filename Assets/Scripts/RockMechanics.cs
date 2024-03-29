﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMechanics : MonoBehaviour
{

    public int force;
    private Rigidbody2D rb;
    public float delay;
    private float timer;
    public float rotationSpeed;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = 0;
        rb.mass = 10;
        rb.freezeRotation = false;
    }

    void FixedUpdate()
    {
        Movement();

    }

    void Movement()
    {
        if (timer > delay && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            float movement = Input.GetAxisRaw("Horizontal");
            float dir = movement / Mathf.Abs(movement);
            Vector2 moveVector = new Vector2(movement * force, 0);
            rb.AddForce(moveVector, ForceMode2D.Impulse);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(90 * dir, Vector3.back), Time.deltaTime * rotationSpeed);
            transform.Rotate(Vector3.back, 90 * dir);
            timer = 0;
        }
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x / 2, rb.velocity.y);
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
            }
        }
        timer += Time.fixedDeltaTime;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }




}
