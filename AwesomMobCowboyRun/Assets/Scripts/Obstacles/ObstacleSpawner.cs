using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;

    [SerializeField] private Transform spawnPos;


    private void Start()
    {
        StartCoroutine(nameof(SpawningObstacles));
    }


    private void SpawnRandomObstacle()
    {
        var temp = spawnPos.position;
        temp.z = 0;
        spawnPos.position = temp;
        int randomIndex = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[randomIndex], temp, Quaternion.identity);
    }

    private IEnumerator SpawningObstacles()
    {
        yield return new WaitForSeconds(4f);
        SpawnRandomObstacle();

        StartCoroutine(nameof(SpawningObstacles));
    }
    
}
