using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] clouds;

    private float distanceBetweenClouds = 3f;

    private float minX,maxX;

    private float lastCloudPositionY;
    
    private float positionY = -1.5f;
    
    private int controlX;

    [SerializeField]private GameObject[] collectables;

    private GameObject player;

    private void Start()
    {
        SetMinMax();
        
        CreateClouds();
    }

    private void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));

        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }
    
    private void Shuffle(GameObject[]arrayToShuffle)
    {
        for (int i = 0; i < arrayToShuffle.Length; i++)
        {
            GameObject temp = arrayToShuffle[i];
            int randomIndex = Random.Range(i, arrayToShuffle.Length);
            arrayToShuffle[i] = arrayToShuffle[randomIndex];
            arrayToShuffle[randomIndex] = temp;
            
            //
        }
    }

    private void CreateClouds()
    {
        Shuffle(clouds);
        
        for (int i = 0; i < clouds.Length; i++)
        {
            Vector3 temp = clouds[i].transform.position;
            temp.y = positionY;
            
            if (controlX == 0)
            { 
                temp.x = Random.Range(0f, maxX);
                controlX = 1;
            }else if (controlX == 1)
            {
                temp.x = Random.Range(0f, minX);
                controlX = 2;
            }else if (controlX == 2)
            {
                temp.x = Random.Range(1f, maxX);
                controlX = 3;
            }
            else if (controlX == 3)
            {
                temp.x = Random.Range(-1f, minX);
                controlX = 0;
            }
            
            clouds[i].transform.position = temp;
             
            Instantiate(clouds[i], temp, Quaternion.identity);
            
            lastCloudPositionY = positionY;
            positionY -= distanceBetweenClouds;

            if (clouds[i].tag !=TagManager.CLOUDDEADLY)
            {
                if (Random.Range(0,5) > 3)
                {
                    int randomSpawnCollectableIndex = Random.Range(0, collectables.Length);
                    GameObject coll = Instantiate(collectables[randomSpawnCollectableIndex]);
                    coll.transform.position = temp;

                    Vector3 tempcoll = coll.transform.position;
                    tempcoll.y += 0.5f;
                    coll.transform.position = tempcoll;

                }
            }
           

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagManager.CLOUDTAG) || other.CompareTag(TagManager.CLOUDDEADLY))
        {
            if (other.transform.position.y == lastCloudPositionY)
            {
                Shuffle(clouds);
                //Shuffle(collectables);
                CreateClouds();
            }
        }
    }
}
