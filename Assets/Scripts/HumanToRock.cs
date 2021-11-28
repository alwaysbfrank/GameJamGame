using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanToRock : MonoBehaviour
{
    [Range(0, 100)] public float rate;

    private Rigidbody2D _rigidbody;
    private float _current;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _current = 0f;
    }

    private void FixedUpdate()
    {
        //Debug.Log("turnToRock: " + _current);
        var xSpeed = Input.GetAxis("Horizontal");
        //Debug.Log("My velocity: " + xSpeed);
        if (xSpeed == 0f)
        {
            _animator.SetBool("isMoving", false);
            _current += rate * Time.fixedDeltaTime;
        }
        else
        {
            //Debug.Log("I MOVE");
            _animator.SetBool("isMoving", true);
            _current = 0f;
        }

        if (_current > 100 && !_animator.GetBool("soaks"))
        {
            PlayerSwitcherEventSystem.SwitchFromHumanToStone();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.IsWater())
        {
            _animator.SetBool("soaks", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.IsWater())
        {
            _animator.SetBool("soaks", false);
        }
    }
}
