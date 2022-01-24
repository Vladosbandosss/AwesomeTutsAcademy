using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WarningSpawner : MonoBehaviour
{
    private float spawnLeft = -2.25f, spawnRight = 2.25f;
    private SpriteRenderer _sr;

    public GameObject dogPrefab;
    private float pushForce = 10f;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        RandomPos();
        
        InvokeRepeating(nameof(SpawnObstacle),Random.Range(3f,5f),5);
    }

    private void RandomPos()
    {
        Vector3 temp = transform.position;

        if (Random.Range(0, 2) > 0)
        {
            temp.x = spawnLeft;
            _sr.flipX = true;
        }
        else
        {
            temp.x = spawnRight;
        }

        transform.position = temp;
    }

    private void SpawnObstacle()
    {
        GameObject obstacle = Instantiate(dogPrefab);
        
        Vector3 temp = transform.position;

        if (transform.position.x > 0)
        {
            obstacle.transform.position = new Vector3(temp.x + 5f, temp.y, 0f);
            
            obstacle.GetComponent<Rigidbody2D>().velocity =
                new Vector2(-pushForce, obstacle.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            obstacle.transform.position = new Vector3(temp.x + -5f, temp.y, 0f);
            
            obstacle.GetComponent<SpriteRenderer>().flipX = true;
            
            obstacle.GetComponent<Rigidbody2D>().velocity =
                new Vector2(pushForce, obstacle.GetComponent<Rigidbody2D>().velocity.y);
        }

        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(nameof(TurnOnOfWarningSign));
        }
    }

    private IEnumerator TurnOnOfWarningSign()
    {
        yield return new WaitForSeconds(2f);
        _sr.enabled = false;
        
        yield return new WaitForSeconds(1f);
        _sr.enabled = true;
    }
}
