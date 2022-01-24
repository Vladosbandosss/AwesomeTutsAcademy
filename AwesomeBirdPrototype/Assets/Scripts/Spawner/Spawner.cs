using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;

    [SerializeField] private GameObject groundPrefab;
    private float groundYDistance = 3.3f;
    private float curentYPosition = 0f;

    [SerializeField] private GameObject[] dogs;
    private float xPos = 2.55f;

    [SerializeField] private GameObject[] collectables;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        SpawnInitialGrounds();
    }

    private void SpawnInitialGrounds()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnMoreGrounds();
        }
    }

    public void SpawnMoreGrounds()
    {
        curentYPosition += groundYDistance;

        GameObject newGround = Instantiate(groundPrefab);
        newGround.transform.position = new Vector3(0f, curentYPosition, 0f);

        int randomForDogs = Random.Range(0, 10);
        if (randomForDogs > 1)
        {
            GameObject obstacle = Instantiate(dogs[Random.Range(0, dogs.Length)]);
            if (obstacle.tag == TagManager.WARNINGTAG)
            {
                obstacle.transform.position = new Vector2(0, newGround.transform.position.y + 0.8f);
            }
            else
            {
                obstacle.transform.position = new Vector2(Random.Range(-xPos, xPos), newGround.transform.position.y+0.5f);
            }
        }
        
        SpawnCollectables();
    }

    private void SpawnCollectables()
    {
        if (Random.Range(0, 2) > 0)//тест поменяй на норм число
        {
            GameObject collect = Instantiate(collectables[Random.Range(0, collectables.Length)]);
            collect.transform.position = new Vector2(Random.Range(-xPos, xPos), curentYPosition + 0.5f);
        }
    }
}
