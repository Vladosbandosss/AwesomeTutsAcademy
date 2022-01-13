using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAI : MonoBehaviour
{
   [SerializeField] private bool isEater;

   [SerializeField] private float moveSpeed = 1f;

   [SerializeField] private int attackDamage = 5;

   [SerializeField] private float attackTimerTreshHold = 1f;

   [SerializeField] private float eatTimeTreshHold = 2f;

   [SerializeField] private LayerMask bushMask;

   [HideInInspector] public bool isMoving, left;

   private Artifact _artifact;

   private BushFruits _bushFruitsTarget;

   private float attackTimer;
   private float eatTimer;

   private bool killingBush;
   private bool isAttacking;

   private void Start()
   {
      if (isEater)
      {
         SearchForTarget();
         killingBush = false;
      }
      else
      {
         isAttacking = false;
      }

      _artifact = GameObject.FindWithTag("Artifact").GetComponent<Artifact>();
   }

   private void Update()
   {
      if (!_artifact)
      {
         return;
      }

      if (isEater)
      {
         if (_bushFruitsTarget && _bushFruitsTarget.enabled && _bushFruitsTarget.HasFruits() && !killingBush)
         {
            if (Vector2.Distance(transform.position, _bushFruitsTarget.transform.position) > 0.5f)
            {
               float step = moveSpeed * Time.deltaTime;

               transform.position = Vector2.MoveTowards(transform.position,
                  _bushFruitsTarget.transform.position, step);
               
               isMoving = true;
            }
            else
            {
               isMoving = false;
               _bushFruitsTarget.HasFruits();
               eatTimer = Time.time + eatTimeTreshHold;
               killingBush = true;
            }
         }
         else if (killingBush)
         {
            if (Time.time > eatTimer)
            {
               _bushFruitsTarget.EatBushFruits();
               killingBush = false;
               SearchForTarget();
            }
         }
         else
         {
            SearchForTarget();
         }

         if (_bushFruitsTarget)
         {
            if (_bushFruitsTarget.transform.position.x < transform.position.x)
            {
               left = true;
            }
            else
            {
               left = false;
            }
         }
         
         if (!_bushFruitsTarget)
         {
            SearchForTarget();
         }

         

        
      }
      else
      {
         if (Vector2.Distance(transform.position, _artifact.transform.position) > 1.5f)
         {
            float step = moveSpeed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position,
               _artifact.transform.position, step);

            isMoving = true;
         }else if (!isAttacking)
         {
            isAttacking = true;
            attackTimer = Time.time + attackTimerTreshHold;
            
            isMoving = false;
         }

         if (isAttacking)
         {
            if (Time.time > attackTimer)
            {
               Attack();
               attackTimer = Time.time + attackTimerTreshHold;
            }
         }

         if (_artifact.transform.position.x < transform.position.x)
         {
            left = true;
         }
         else
         {
            left = false;
         }
      }
      
   }

   private void SearchForTarget()
   {
      
      _bushFruitsTarget = null;

      Collider2D[] hits;

      for (int i = 1; i < 50; i++)
      {
         hits = Physics2D.OverlapCircleAll(transform.position, Mathf.Exp(i), bushMask);

         foreach (var hit in hits)
         {
            if (hit && hit.GetComponent<BushFruits>().HasFruits() && hit.GetComponent<BushFruits>().enabled)
            {
               _bushFruitsTarget = hit.GetComponent<BushFruits>();
               break;
            }
         }

         if (_bushFruitsTarget)
         {
            break;
         }
      }
   }//поиск

   private void Attack()
   {
      _artifact.TakeDamage(attackDamage);
   }
}
