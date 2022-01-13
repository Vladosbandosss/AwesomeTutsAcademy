using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TimeManger : MonoBehaviour
{
    [SerializeField] private Text timerText;

    public float timeTowin = 300f;

    private bool gameOver;

    private GameObject artifact;

    private StringBuilder _stringBuilder;

    private void Awake()
    {
        artifact=GameObject.FindWithTag("Artifact");
        
        _stringBuilder = new StringBuilder();
    }

    private void Update()
    {
        if (gameOver || !artifact)
        {
            return;
        }

        timeTowin -= Time.deltaTime;

        if (timeTowin <= 0f)
        {
            timeTowin = 0f;
            gameOver = true;
            
            Destroy(artifact);
            
            GameOverUIController.instance.GameOverInfo("You win");
        }

        //timerText.text = "Time Remaining " + (int) timeTowin;
        DisplayTime((int)timeTowin);
    }

    private void DisplayTime(int time)
    {
        _stringBuilder.Length = 0;
        
        _stringBuilder.Append("Time Remaining");
        _stringBuilder.Append(time);

        timerText.text = _stringBuilder.ToString();
    }
}
