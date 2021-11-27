using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanToRock : MonoBehaviour
{
    [Range(0, 100)] public float rate;

    private Rigidbody2D _rigidbody;
    private float _current;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _current = 0f;
    }

    private void Update()
    {
        if (_rigidbody.velocity.x == 0f)
        {
            _current += rate * Time.deltaTime;
        }
        else
        {
            _current = 0f;
        }

        if (_current > 100)
        {
            PlayerSwitcherEventSystem.SwitchFromHumanToStone();
        }
    }
}
