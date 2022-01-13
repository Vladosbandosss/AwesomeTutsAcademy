using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarvest : MonoBehaviour
{
   [SerializeField] private float harvestTime = 0.4f;

   private PlayerMovement _playerMovement;
   private PlayerBackPack _playerBackPack;

   private AudioSource _audioSource;

   private Collider2D collidedBush;
   private BushFruits hitBuh;

   private bool canHarvestFruits;

   private void Awake()
   {
      _playerMovement = GetComponent<PlayerMovement>();
      _playerBackPack = GetComponent<PlayerBackPack>();
      _audioSource = GetComponent<AudioSource>();
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.E))
      {
         TryHarvestFruits();
      }
   }

   private void TryHarvestFruits()
   {
      if (!canHarvestFruits)
      {
         return;
      }

      if (collidedBush != null)
      {
         hitBuh = collidedBush.GetComponent<BushFruits>();
         if (hitBuh.HasFruits())
         {
            _audioSource.Play();
           _playerMovement.HarvestStopMovement(harvestTime);
           _playerBackPack.AddFruits(hitBuh.HarvestFruit());
         }
      }
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Bush"))
      {
         canHarvestFruits = true;
         collidedBush = other;
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.CompareTag("Bush"))
      {
         canHarvestFruits = false;
         collidedBush = null;
      }
   }
}
