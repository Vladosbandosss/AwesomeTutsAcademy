using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour
{
    private GameObject[] backGrounds;
    private float lastY;

    private void Start()
    {
        GetBGandSetLastY();
    }

    private void GetBGandSetLastY()
    {
        backGrounds = GameObject.FindGameObjectsWithTag(TagManager.BGTAG);
        lastY = backGrounds[0].transform.position.y;

        for (int i = 1; i < backGrounds.Length; i++)
        {
            if (lastY > backGrounds[i].transform.position.y)
            {
                lastY = backGrounds[i].transform.position.y;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagManager.BGTAG))
        {
            if (other.transform.position.y == lastY)
            {
                Vector3 temp = other.transform.position;
                float height = ((BoxCollider2D) other).size.y;

                for (int i = 0; i < backGrounds.Length; i++)
                {
                    if (!backGrounds[i].activeInHierarchy)
                    {
                        temp.y -= height;

                        lastY = temp.y;

                        backGrounds[i].transform.position = temp;
                        backGrounds[i].SetActive(true);
                    }
                }
            }
        }
    }
}
