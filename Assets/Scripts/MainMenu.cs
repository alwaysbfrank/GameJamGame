﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void newGame()
    {
        SceneManager.LoadScene("00_level1");
    }

    public void credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void instruction()
    {
        SceneManager.LoadScene("Instruction");
    }

    public void exit()
    {
        Application.Quit();
    }
}
