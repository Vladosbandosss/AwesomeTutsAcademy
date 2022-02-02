using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferences
{
   public static string EasyDifficulty = "EasyDifficulty";
   public static string MediumDifficulty = "MediumDifficulty";
   public static string HardDifficulty = "HardDifficulty";
   
   public static string EasyDifficultyScore = "EasyDifficultyScore";
   public static string MediumDifficultyScore = "MediumDifficultyScore";
   public static string HardDifficultyScore = "HardDifficultyScore";
   
   public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
   public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
   public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";

   public static string IsMusicOn = "IsMusicOn";
   
   //исп инты для понятия да или нет 0 непрвда 1 правда

   public static void SetEasyDifficultyState(int difficulty)
   {
      PlayerPrefs.SetInt(GamePreferences.EasyDifficulty,difficulty);
   }

   public static int GetEasyDifficultyState()
   {
      return PlayerPrefs.GetInt(GamePreferences.EasyDifficulty);
   }
   
   
   public static void SetMediumDifficultyState(int difficulty)
   {
      PlayerPrefs.SetInt(GamePreferences.MediumDifficulty,difficulty);
   }
   
   public static int GetMediumDifficultyState()
   {
      return PlayerPrefs.GetInt(GamePreferences.MediumDifficulty);
   }
   
   
   public static void SetHardDifficultyState(int difficulty)
   {
      PlayerPrefs.SetInt(GamePreferences.HardDifficulty,difficulty);
   }
   
   public static int GetHardDifficultyState()
   {
      return PlayerPrefs.GetInt(GamePreferences.HardDifficulty);
   }

   public static void SetMusicState(int state)
   {
      PlayerPrefs.SetInt(GamePreferences.IsMusicOn,state);
   }

   public static int GetMusicState()
   {
      return PlayerPrefs.GetInt(GamePreferences.IsMusicOn);
   }
   
   
   public static void SetEasyDifficultyScore(int score)
   {
      PlayerPrefs.SetInt(GamePreferences.EasyDifficultyScore,score);
   }

   public static int GetEasyDifficultyScore()
   {
      return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyScore);
   }
   
   
   public static void SetMediumDifficultyScore(int score)
   {
      PlayerPrefs.SetInt(GamePreferences.MediumDifficultyScore,score);
   }
   
   public static int GetMediumDifficultyScore()
   {
      return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyScore);
   }
   
   
   public static void SetHardDifficultyScore(int score)
   {
      PlayerPrefs.SetInt(GamePreferences.HardDifficultyScore,score);
   }
   
   public static int GetHardDifficultyScore()
   {
      return PlayerPrefs.GetInt(GamePreferences.HardDifficultyScore);
   }
   
   public static void SetEasyDifficultyCoin(int coin)
   {
      PlayerPrefs.SetInt(GamePreferences.EasyDifficultyCoinScore,coin);
   }

   public static int GetEasyDifficultyCoin()
   {
      return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyCoinScore);
   }
   
   
   public static void SetMediumDifficultyCoin(int coin)
   {
      PlayerPrefs.SetInt(GamePreferences.MediumDifficultyCoinScore,coin);
   }
   
   public static int GetMediumDifficultyCoin()
   {
      return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyCoinScore);
   }
   
   
   public static void SetHardDifficultyCoin(int coin)
   {
      PlayerPrefs.SetInt(GamePreferences.HardDifficultyCoinScore,coin);
   }
   
   public static int GetHardDifficultyCoin()
   {
      return PlayerPrefs.GetInt(GamePreferences.HardDifficultyCoinScore);
   }
   
   
   
   
   
   
   


}
