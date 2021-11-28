using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeScript : MonoBehaviour
{
    [Range(0, 100)] public float hearingDistance;
    public GameObject humanPlayer;
    public GameObject stonePlayer;
    public GameObject gasPlayer;
    private GameObject activePlayer;
    private AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        activePlayer = humanPlayer;
        PlayerSwitcherEventSystem.FromGasToHuman += HumanActive;
        PlayerSwitcherEventSystem.FromHumanToGas += GasActive;
        PlayerSwitcherEventSystem.FromHumanToStone += StoneActive;
        PlayerSwitcherEventSystem.FromStoneToHuman += HumanActive;
    }

    private void OnDisable()
    {
        PlayerSwitcherEventSystem.FromGasToHuman -= HumanActive;
        PlayerSwitcherEventSystem.FromHumanToGas -= GasActive;
        PlayerSwitcherEventSystem.FromHumanToStone -= StoneActive;
        PlayerSwitcherEventSystem.FromStoneToHuman -= HumanActive;
    }

    public void HumanActive()
    {
        activePlayer = humanPlayer;
    }

    public void GasActive()
    {
        activePlayer = gasPlayer;
    }

    public void StoneActive()
    {
        activePlayer = stonePlayer;
    }

    void Update()
    {
        var distanceToPlayer = Vector3.Distance(activePlayer.transform.position, transform.position);
        if (distanceToPlayer > hearingDistance)
        {
            _audio.volume = 0f;
            return;
        }

        _audio.volume = 1 - distanceToPlayer / hearingDistance;
    }
}
