using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private GameData _gameData;
    
    [HideInInspector]
    public int bestCore, diamondScore;
    
    [HideInInspector]
    public bool[] birds;

    [HideInInspector] 
    public int selectedIndex;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        InitializeGameData();
    }
    
    private void InitializeGameData()
    {
        LoadGameData();

        if (_gameData == null)//если ранее не сохр сохр иниц
        {
            bestCore = 0;
            diamondScore = 0;
            selectedIndex = 0;
            
            birds = new bool[7];//7 тк 7 птиц

            birds[0] = true;

            for (int i = 1; i < birds.Length; i++)
            {
                birds[i] = false;
            }

            _gameData = new GameData();
            _gameData.BestScore = bestCore;
            _gameData.DiamondScore = diamondScore;
            _gameData.SelecdetIndex = selectedIndex;
            _gameData.Birds = birds;
            
            SaveGameData();

        }
    }

    public void SaveGameData()
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Create(Application.persistentDataPath + TagManager.GAMEDATA);

            if (_gameData != null)
            {
                _gameData.BestScore = bestCore;
                _gameData.DiamondScore = diamondScore;
                _gameData.SelecdetIndex = selectedIndex;
                _gameData.Birds = birds;

                bf.Serialize(file, _gameData);
            }
        }
        catch (Exception e)
        {

        }
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }
    }//save game data

    private void LoadGameData()
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            file = File.Open(Application.persistentDataPath + TagManager.GAMEDATA, FileMode.Open);

            _gameData = (GameData) bf.Deserialize(file);

            if (_gameData != null)
            {
                bestCore = _gameData.BestScore;
                diamondScore = _gameData.DiamondScore;
                selectedIndex = _gameData.SelecdetIndex;
                birds = _gameData.Birds;
            }
        }
        catch (Exception e)
        {
          
        } 
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }
    }
    
}
