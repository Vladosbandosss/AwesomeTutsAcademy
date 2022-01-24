using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BirdScript : MonoBehaviour
{
   private Rigidbody2D _rb;
   private SpriteRenderer _sr;

   private float moveSpeed = 3.5f;
   private bool goLeft;

   private Animator _anim;
   private float jumpForce = 5f;
   private float secondJumpForce = 7f;
   private bool firstJump, secondJump;

   private void Awake()
   {
      _rb = GetComponent<Rigidbody2D>();
      _sr = GetComponent<SpriteRenderer>();
      _anim = GetComponent<Animator>();
   }

   private void Start()
   {
      firstJump = true;
      secondJump = true;
   }

   private void Update()
   {
      if (GamePlayController.instance.playGame)
      {
         Move();
         
         if (Input.GetMouseButtonDown(0))
         {
            Jump();
         }
      }
     
   }

   private void Move()
   {
      if (goLeft)
      {
         _rb.velocity = new Vector2(-moveSpeed, _rb.velocity.y);
      }
      else
      {
         _rb.velocity = new Vector2(moveSpeed, _rb.velocity.y);
      }

      
   }

   private void Jump()
   {
      if (firstJump)
      {
         firstJump = false;
         _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
         _anim.SetTrigger(TagManager.FLYTRIGGER);
      }else if (secondJump)
      {
         secondJump = false;
         _rb.velocity = new Vector2(_rb.velocity.x, secondJumpForce);
         _anim.SetTrigger(TagManager.FLYTRIGGER);
      }
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.CompareTag(TagManager.BORDERTAG))
      {
         goLeft = !goLeft;
         _sr.flipX = goLeft;
      }

      if (other.gameObject.CompareTag(TagManager.GROUNDTAG))
      {
         if (_rb.velocity.y <= 1f)
         {
            firstJump = true;
            secondJump = true;
         }
        
      }

      if (other.gameObject.CompareTag(TagManager.DOGTAG))
      {
         GamePlayController.instance.GameOver();
         _anim.Play(TagManager.DEADBIRD);
      }
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if(other.CompareTag(TagManager.DIAMONTAG))
      {
         other.gameObject.SetActive(false);
         int diamondBonus = Random.Range(1, 3);
         int scoreBonus = Random.Range(0, 2);
         GamePlayController.instance.DisplayScore(scoreBonus,diamondBonus);
      }
   }
}//class
