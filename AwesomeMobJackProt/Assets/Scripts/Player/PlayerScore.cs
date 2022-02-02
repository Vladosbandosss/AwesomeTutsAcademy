using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private AudioClip coinClip, lifeClip;

    private CameraMowe _cameraScript;

    private bool canScore;

    private Vector3 previousPos;

    public static int scoreCount;
    public static int lifeCount;
    public static int coinCount;

    private void Awake()
    {
        _cameraScript = Camera.main.GetComponent<CameraMowe>();
    }

    private void Start()
    {
        previousPos = transform.position;
        canScore = true;
    }

    private void Update()
    {
        // CountScore();
    }

    private void CountScore()
    {
        if (canScore)
        {
            if (transform.position.y < previousPos.y)
            {
                scoreCount++;
            }

            scoreCount /= 10;
            previousPos = transform.position;
            GamePlayController.instance.SetScore(scoreCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagManager.COINTAG))
        {
            coinCount++;
            scoreCount += 10;
            GamePlayController.instance.SetScore(scoreCount);
            GamePlayController.instance.SetCoinScore(coinCount);
            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag(TagManager.LIFETAG))
        {
            lifeCount++;
            scoreCount += 20;
            GamePlayController.instance.SetScore(scoreCount);
            GamePlayController.instance.SetLifeScore(lifeCount);
            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag(TagManager.BOUNDSTAG))
        {
            _cameraScript.isCameraMoving = false;
            canScore = false;
            GamePlayController.instance.GameOverShowPanel(scoreCount, coinCount);
            lifeCount--;
            transform.position = new Vector3(500, 500, 0);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(TagManager.CLOUDDEADLY))
        {
            lifeCount--;
            if (lifeCount < 0)
            {
                _cameraScript.isCameraMoving = false;
                canScore = false;
                GamePlayController.instance.GameOverShowPanel(scoreCount, coinCount);

                transform.position = new Vector3(500, 500, 0);
            }
            else
            {
                GamePlayController.instance.SetLifeScore(lifeCount);
            }
        }
    }
}
