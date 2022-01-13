using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Canvas howToPlayCanvas;

    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void HowToPlay(bool isHow)
    {
        if (isHow)
        {
            howToPlayCanvas.enabled = true;
        }
        else
        {
            howToPlayCanvas.enabled = false;
        }
    }
}
