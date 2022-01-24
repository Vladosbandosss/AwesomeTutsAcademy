using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    [SerializeField] private Text scoreText, bestScoreText, diamondScoreText, totalDiamondScoreText;
    private int countScore, countDiamond;

    [SerializeField] private GameObject mainMenuObg, gameOverObj, birdMenuObg;

    [HideInInspector] public bool playGame;

    public Text mainMenuDisplayBestScoreText, birdMenuDisplayBestScoreText, birdMenuDisplayDiamondScoreText;

    public GameObject[] birds;
    public GameObject[] birsPriceText;
    public GameObject[] birdIcons;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        mainMenuDisplayBestScoreText.text = "Best: " + GameManager.instance.bestCore;
        bestScoreText.text="Best: "+GameManager.instance.bestCore;
        totalDiamondScoreText.text = "Total: " + GameManager.instance.diamondScore;
    }

    public void DisplayScore(int score, int diamond)
    {
        countScore += score;
        countDiamond += diamond;

        scoreText.text = countScore.ToString();
        diamondScoreText.text = countDiamond.ToString();
    }

    public void PlayGame()
    {
        if (!playGame)
        {
            mainMenuObg.SetActive(false);
            playGame = true;

            bestScoreText.text = "Best: " + GameManager.instance.bestCore;
            totalDiamondScoreText.text = "Total: " + GameManager.instance.diamondScore;
        }
    }

    public void GameOver()
    {
        playGame = false;
        
        gameOverObj.SetActive(true);
        gameOverObj.GetComponent<Animator>().Play(TagManager.FADEINGOPANELANIM);
        //save game data
        int currentBestScore = GameManager.instance.bestCore;

        if (currentBestScore < countScore)
        {
            GameManager.instance.bestCore = countScore;
        }

        GameManager.instance.diamondScore += countDiamond;

        if (countScore >= 25)
        {
            GameManager.instance.birds[GameManager.instance.birds.Length - 1] = true;
        }
        GameManager.instance.SaveGameData();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        gameOverObj.SetActive(false);
        birdMenuObg.SetActive(false);
        mainMenuObg.SetActive(true);
    }

    public void BirdMenu()
    {
        birdMenuObg.SetActive(true);
        mainMenuObg.SetActive(false);

        birdMenuDisplayBestScoreText.text ="Best: "+ GameManager.instance.bestCore;
        birdMenuDisplayDiamondScoreText.text =GameManager.instance.diamondScore.ToString();
    }
}
