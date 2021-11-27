using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{

    public ParticleSystem rocks;
    public ParticleSystem steam;

    private void throwRocks()
    {
        rocks.Play();
    }

    private void releaseClouds()
    {
        steam.Play();
    }

    private void OnEnable()
    {
        PlayerSwitcherEventSystem.FromStoneToHuman += throwRocks;
        PlayerSwitcherEventSystem.FromGasToHuman += releaseClouds;
        PlayerSwitcherEventSystem.FromHumanToGas += releaseClouds;
    }

    private void OnDisable()
    {
        PlayerSwitcherEventSystem.FromStoneToHuman -= throwRocks;
        PlayerSwitcherEventSystem.FromGasToHuman -= releaseClouds;
        PlayerSwitcherEventSystem.FromHumanToGas -= releaseClouds;
    }

}
