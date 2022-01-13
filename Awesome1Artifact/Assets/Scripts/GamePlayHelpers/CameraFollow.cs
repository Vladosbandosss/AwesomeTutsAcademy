using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   private Transform player;

   private void Awake()
   {
      player = GameObject.FindWithTag("Player").transform;
   }

   private void LateUpdate()
   {
      Vector3 temp = transform.position;
      temp = player.position;
      temp.z = -10f;
      
      transform.position = temp;
   }
}
