using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{

    public static GameManger instance;

    [SerializeField] private GameObject[] players;
    
    private int charIndex;

    public int CharIndex
    {
        get { return charIndex; }
        set { charIndex = value; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishLoading;
    }

    void OnLevelFinishLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GamePlay")
        {
            Instantiate(players[charIndex]);
        }
       
    }
}
