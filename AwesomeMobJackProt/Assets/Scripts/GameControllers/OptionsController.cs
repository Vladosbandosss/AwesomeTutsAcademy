using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
    private void Start()
    {
        
    }

    public void GOBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
