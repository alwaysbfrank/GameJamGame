using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcherEventSystem : MonoBehaviour
{
    public delegate void SwitchPlayer();

    public static event SwitchPlayer FromHumanToGas;
    public static event SwitchPlayer FromGasToHuman;
    public static event SwitchPlayer FromHumanToStone;
    public static event SwitchPlayer FromStoneToHuman;

    public static void SwitchFromHumanToGas()
    {
        FromHumanToGas();
    }

    public static void SwitchFromGasToHuman()
    {
        FromGasToHuman();
    }

    public static void SwitchFromHumanToStone()
    {
        FromHumanToStone();
    }

    public static void SwitchFromStoneToHuman()
    {
        FromStoneToHuman();
    }
}
