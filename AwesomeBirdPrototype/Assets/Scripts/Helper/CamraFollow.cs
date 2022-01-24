using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraFollow : MonoBehaviour
{
    private GameObject player;

    private Vector3 temp;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYERTAG);
    }

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (player)
        {
            temp = transform.position;
            temp.y = player.transform.position.y;
            transform.position = temp;
        }
    }
}
