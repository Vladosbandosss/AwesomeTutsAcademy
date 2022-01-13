using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlash : MonoBehaviour
{
   [SerializeField] private GameObject slashPrefab;

   [SerializeField] private float attackCoolDown = 0.3f;

   private float attackTimer;

   private AudioSource _audioSource;

   private Camera mainCamera;

   private Vector3 spawnPos;

   private void Awake()
   {
      _audioSource = GetComponent<AudioSource>();
      mainCamera = Camera.main;
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > attackTimer)
      {
         Slash();
         _audioSource.Play();
         attackTimer = Time.time + attackCoolDown;
      }
   }

   private void Slash()
   {
      spawnPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
      spawnPos.z = 0;

      Instantiate(slashPrefab, spawnPos, Quaternion.identity);
   }
}
