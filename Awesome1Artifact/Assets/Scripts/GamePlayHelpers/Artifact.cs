using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
   public int health;
   public int maxHealth = 150;

   public int bleed = 2;

   private AudioSource _audioSource;

   private float bleedTimer;

   private PlayerBackPack _playerBackPack;

   private void Awake()
   {
      _audioSource = GetComponent<AudioSource>();
      health = maxHealth;
      bleedTimer = Time.time + 1f;
   }

   private void Update()
   {
      if (Time.time > bleedTimer)
      {
         health -= bleed;
         bleedTimer = Time.time + 1f;
      }
      
      CheckHealth();
   }

   public void TakeDamage(int damageAmount)
   {
      health -= damageAmount;
      
      CheckHealth();
   }

   private void CheckHealth()
   {
      if (health<=0)
      {
         health = 0;
        GameOverUIController.instance.GameOverInfo("You lose");
         Destroy(gameObject);
      }
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         if (other.GetComponent<PlayerBackPack>().currentNumbersOfStoredFruits != 0)
         {
            _audioSource.Play();

            health += other.GetComponent<PlayerBackPack>().TakeFruits();
             
            if (health > maxHealth)
            {
               health = maxHealth;
            }
         }
      }
   }
}
