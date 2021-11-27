using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerSwitcherScript : MonoBehaviour
{
    public GameObject playerHuman;

    public GameObject playerStone;

    public GameObject playerGas;

    public Vector3 startingPosition;

    private int currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = 0;
        ActivateHuman(transform.position);
    }

    void FromHumanToStone()
    {
        ActivateStone(playerHuman.transform.position);
    }

    void FromStoneToHuman()
    {
        ActivateHuman(playerStone.transform.position);
    }

    void FromGasToHuman()
    {
        ActivateHuman(playerGas.transform.position);
    }

    void FromHumanToGas()
    {
        ActivateGas(playerHuman.transform.position);
    }

    void ActivateHuman(Vector3 position)
    {
        playerStone.SetActive(false);
        playerGas.SetActive(false);
        playerHuman.transform.position = position;
        playerHuman.SetActive(true);
    }

    void ActivateGas(Vector3 position)
    {
        playerStone.SetActive(false);
        playerHuman.SetActive(false);
        playerGas.transform.position = position;
        playerGas.SetActive(true);
    }

    void ActivateStone(Vector3 position)
    {
        playerGas.SetActive(false);
        playerHuman.SetActive(false);
        playerStone.transform.position = position;
        playerStone.SetActive(true);
    }
}
