using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalToGas : MonoBehaviour
{

    [Range(0, 100)] public float gasThreshold;
    [Range(0, 100)] public float heatPower;
    [Range(0, 100)] public float cooloffPower;
    [Range(0, 1)] public float tolerance;

    private float currentTemp;

    private bool isCurrentlyHeated;
    
    // Start is called before the first frame update
    void Start()
    {
        currentTemp = 0f;
        isCurrentlyHeated = false;
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
        //LogState();
        var shouldHeatUp = isCurrentlyHeated && currentTemp < gasThreshold;
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
        currentTemp = Math.Min(gasThreshold, currentTemp + heatPower * Time.deltaTime);
    }

    private void CoolDown()
    {
        currentTemp = Math.Max(0f, currentTemp - cooloffPower * Time.deltaTime);
    }

    public bool ShouldBeGas()
    {
        return currentTemp > gasThreshold - tolerance;
    }

    public bool ShouldBeNormal()
    {
        return currentTemp < gasThreshold - tolerance;
    }
}

public static class Extenstions
{
    public static bool IsHeat(this Collider2D collider2D)
    {
        return collider2D.CompareTag("Heat");
    }
}
