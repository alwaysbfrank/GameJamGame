using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockToHuman : MonoBehaviour
{
    [Range(0, 100)] public float rate;

    private float _current;

    private void OnEnable()
    {
        _current = 0f;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.IsWater())
        {
            Debug.Log("Soaking");
            _current += rate * Time.deltaTime;
        }
    }

    private void Update()
    {
        if (_current > 100)
        {
            Debug.Log("Switching to human");
            PlayerSwitcherEventSystem.SwitchFromStoneToHuman();
        }
    }
}

public static class Extensions
{
    public static bool IsWater(this Collider2D collider2D)
    {
        return collider2D.CompareTag("Water");
    }
}
