using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateGameObjects : MonoBehaviour
{
   private void Update()
   {
      DeactiveGameObj();
   }

   private void DeactiveGameObj()
   {
      if (Camera.main.transform.position.y > transform.position.y + 9f)
      {
         gameObject.SetActive(false);
      }
   }
}
