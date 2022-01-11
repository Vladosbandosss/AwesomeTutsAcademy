using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 temp;

    private void Start()
    {
       player = GameObject.FindWithTag("Player").transform;
      
    }

    private void LateUpdate()
    {
        if (!player)
        {
            return;
        }
        
        temp = transform.position;
        temp.x = player.position.x;

        transform.position = temp;
    }
}
