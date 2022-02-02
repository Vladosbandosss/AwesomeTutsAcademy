using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private float xAxis;

    private Rigidbody2D _rb;
    private Animator _anim;
    private SpriteRenderer _sr;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (xAxis > 0)
        {
            _rb.velocity = new Vector2(speed, _rb.velocity.y);
            
            _anim.SetBool(TagManager.PLAYERWALKPARAMETR,true);

            _sr.flipX = false;

        }else if (xAxis < 0)
        {
            _rb.velocity = new Vector2(-speed, _rb.velocity.y);
            
            _anim.SetBool(TagManager.PLAYERWALKPARAMETR,true);
            
            _sr.flipX = true;
            
        }
        else
        {
            _rb.velocity = new Vector2(0f, _rb.velocity.y);
            _anim.SetBool(TagManager.PLAYERWALKPARAMETR,false);
        }
    }
    
}//class
