using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 3f;

    private Rigidbody2D _rb;

    private Vector2 moveVector;

    private SpriteRenderer _sr;

    private float harvestTimer;
    private bool isHarvesting;

    private GameObject artifact;

    private Animator _anim;
    
    private string HORIZONTALINPUT = "Horizontal";
    private string VERTICALINPUT = "Vertical";

    private string WALKINGANIMATIONPARAMENTR = "isWalking";

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Time.time > harvestTimer)
        {
            isHarvesting = false;
        }
        
        FlipSprite();
        AnimatePlayer();
        
        
    }

    private void FixedUpdate()
    {
        if (isHarvesting)
        {
            _rb.velocity=Vector2.zero;
        }
        else
        {
            moveVector = new Vector2(Input.GetAxis(HORIZONTALINPUT), Input.GetAxis(VERTICALINPUT));

            if (moveVector.sqrMagnitude > 1)
            {
                moveVector = moveVector.normalized;
            }

            _rb.velocity = new Vector2(moveVector.x * movementSpeed, moveVector.y * movementSpeed);
        }
    }

    private void FlipSprite()
    {
        if (Input.GetAxisRaw(HORIZONTALINPUT) == 1)
        {
            _sr.flipX = false;
        }else if (Input.GetAxisRaw(HORIZONTALINPUT) == -1)
        {
            _sr.flipX = true;
        }
    }

    private void AnimatePlayer()
    {
        if (Math.Abs(Input.GetAxis(HORIZONTALINPUT))>0||Math.Abs(Input.GetAxis(VERTICALINPUT))>0)
        {
           _anim.SetBool(WALKINGANIMATIONPARAMENTR,true);
        }
        else
        {
            _anim.SetBool(WALKINGANIMATIONPARAMENTR,false);
        }
    }

    public void HarvestStopMovement(float time)
    {
        isHarvesting = true;
        harvestTimer = Time.time + time;
    }

    public bool IsHarvesting()
    {
        return isHarvesting;
    }

   
}
