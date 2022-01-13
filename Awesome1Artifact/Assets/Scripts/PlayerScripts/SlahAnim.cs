using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlahAnim : MonoBehaviour
{
   [SerializeField] private Sprite[] slashSprites;

   [SerializeField] private float timeTreshHold = 0.06f;

   [SerializeField] private int damage=35;

   private float timer;
   private int state = 0;

   private SpriteRenderer _sr;

   private void Awake()
   {
      _sr = GetComponent<SpriteRenderer>();
   }

   private void Update()
   {
      if (Time.time > timer)
      {
         if (state == slashSprites.Length)
         {
            Destroy(gameObject);
            return;
         }
         else
         {
            _sr.sprite = slashSprites[state];
            state++;
            timer = Time.time + timeTreshHold;
         }
      }
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Wolf"))
      {
         other.GetComponent<WolfHealth>().TakeDamage(damage);
      }
   }
}
