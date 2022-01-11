using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterSpawner : MonoBehaviour
{
   [SerializeField] private GameObject[] monsters;

   [SerializeField] private Transform leftPos, rightPos;

   private GameObject spawnedMonster;

   private int randomIndex;
   private int randomSide;

   private int minTimeForSpawn = 1, maxTimeForSpawn = 5;

   private float minMonsterSpeed = 4f, maxMonsterSpeed = 8f;
   
   private void Start()
   {
      StartCoroutine(nameof(SpawnMonsters));
   }

   private IEnumerator SpawnMonsters()
   {
      while (true)
      {
         yield return new WaitForSeconds(Random.Range(minTimeForSpawn, maxTimeForSpawn));

         randomIndex = Random.Range(0, monsters.Length);
         randomSide = Random.Range(0, 2);

         spawnedMonster = Instantiate(monsters[randomIndex]);

         if (randomSide == 0)
         {//left
            spawnedMonster.transform.position = leftPos.position;
            spawnedMonster.GetComponent<Monster>().speed = Random.Range(minMonsterSpeed,maxMonsterSpeed);
         }
         else
         {//right
            spawnedMonster.transform.position = rightPos.position;
            spawnedMonster.GetComponent<Monster>().speed = Random.Range(-minMonsterSpeed,-maxMonsterSpeed);
            spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
         }
      }
   }
}
