using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NormalToGas : MonoBehaviour
{

    [Range(0, 100)] public float heatRate;
    [Range(0, 100)] public float cooldownRate;

    private float currentTemp;

    private bool isCurrentlyHeated;
    
    void Start()
    {
        isCurrentlyHeated = false;
    }

    private void OnEnable()
    {
        currentTemp = 0f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.IsHeat())
        {
            isCurrentlyHeated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.IsHeat())
        {
            isCurrentlyHeated = false;
        }
    }

    private void Update()
    {
        LogState();
        var shouldHeatUp = isCurrentlyHeated && currentTemp < 100f;
        if (shouldHeatUp)
        {
            HeatUp();
            return;
        }

        var shouldCoolDown = !isCurrentlyHeated && currentTemp > 0f;
        if (shouldCoolDown)
        {
            CoolDown();
        }

        if (ShouldBeGas())
        {
            PlayerSwitcherEventSystem.SwitchFromHumanToGas();
        }
    }

    private void LogState()
    {
        if (ShouldBeGas())
        {
            Debug.Log("I am gas");
            return;
        }

        if (isCurrentlyHeated)
        {
            Debug.Log("Heating in progress");
            return;
        }

        if (currentTemp > 0f)
        {
            Debug.Log("Cooling in progress");
            return;
        }

        Debug.Log("I am a cool guy");
    }

    private void HeatUp()
    {
        currentTemp += heatRate * Time.deltaTime;
    }

    private void CoolDown()
    {
        currentTemp = Math.Max(0f, currentTemp - cooldownRate * Time.deltaTime);
    }

    public bool ShouldBeGas()
    {
        return currentTemp > 100f;
    }
}

public static class Extenstions
{
    public static bool IsHeat(this Collider2D collider2D)
    {
        return collider2D.CompareTag("Heat");
    }
}
