using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerSwitcherScript : MonoBehaviour
{
    public GameObject playerHuman;

    public GameObject playerStone;

    public GameObject playerGas;

    private int currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = 1;
        ActivateHuman(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            SwitchState();
        }
    }

    private void SwitchState()
    {
        switch (currentState)
        {
            case 0:
                FromHumanToStone();
                currentState = 1;
                return;
            case 1:
                FromStoneToGas();
                currentState = 2;
                return;
            case 2:
                FromGasToHuman();
                currentState = 0;
                return;
        }
    }

    void FromHumanToStone()
    {
        ActivateStone(playerHuman.transform.position);
    }

    void FromGasToHuman()
    {
        ActivateHuman(playerGas.transform.position);
    }

    void FromStoneToGas()
    {
        ActivateGas(playerStone.transform.position);
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
