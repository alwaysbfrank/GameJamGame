﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsAndInstruction : MonoBehaviour
{
    public void backToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
