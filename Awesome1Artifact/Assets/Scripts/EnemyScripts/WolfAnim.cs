using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WolfAnim : MonoBehaviour
{
   [SerializeField] private Sprite[] wolfAnimSprites;

   [SerializeField] private float animTimeTreshHold=0.15f;

   private WolfAI _wolfAI;

   private SpriteRenderer _sr;

   private int state = 0;
   private float animTimer;

   private void Awake()
   {
      _wolfAI = GetComponent<WolfAI>();
      _sr = GetComponent<SpriteRenderer>();
   }

   private void Update()
   {

      if (_wolfAI.isMoving)
      {
         if (Time.time > animTimer)
         {
            _sr.sprite = wolfAnimSprites[state];
            state++;
         
            if (state == wolfAnimSprites.Length)
            {
               state = 0;
            }
         
            animTimer = Time.time + animTimeTreshHold;
         }
         
      }
      else
      {
         _sr.sprite = wolfAnimSprites[0];
         _sr.flipX = _wolfAI.left;
      }

      //
   }
}
