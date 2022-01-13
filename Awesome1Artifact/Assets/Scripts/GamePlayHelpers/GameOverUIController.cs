using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
   public static GameOverUIController instance;
   
   [SerializeField] private Canvas goCanvas;

   [SerializeField] private Text gameOverText;

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }
   }

   public void GameOverInfo(string goInfo)
   {
      gameOverText.text = goInfo;
      goCanvas.enabled = true;
   }

   public void RestartGame()
   {
      SceneManager.LoadScene("GamePlay");
   }

   public void MainMenu()
   {
      SceneManager.LoadScene("MainMenu");
   }
}
