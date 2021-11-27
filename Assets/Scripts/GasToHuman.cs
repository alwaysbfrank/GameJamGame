using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasToHuman : MonoBehaviour
{
    
    [Range(0, 100)] public float gasThreshold;
    [Range(0, 100)] public float heatPower;
    [Range(0, 1)] public float tolerance;

    private float currentTemp;

    private void OnEnable()
    {
        currentTemp = 0f;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.IsHeat())
        {
            currentTemp = 0f;
        }
    }

    private void Update()
    {
        LogState();
        HeatUp();

        if (ShouldBeGas())
        {
            Debug.Log("Firing event");
            PlayerSwitcherEventSystem.SwitchFromGasToHuman();
        }
    }

    private void LogState()
    {
        Debug.Log("Current temp: " + currentTemp + " (threshold: " + gasThreshold + ")");
    }

    private void HeatUp()
    {
        currentTemp = Math.Min(gasThreshold, currentTemp + heatPower * Time.deltaTime);
    }

    public bool ShouldBeGas()
    {
        return currentTemp > gasThreshold - tolerance;
    }
}
