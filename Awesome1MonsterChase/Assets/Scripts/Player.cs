using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D _rb;

    private SpriteRenderer _sr;
    
    private Animator _anim;
    private string WALKANIMANION = "Walk";

    private bool isGrounded=true;
    private string GROUNDTAG = "Ground";

    private float mimXposToMove = -50f, maxPosToMove = 50f;

    private string ENEMYTAG = "Enemy";

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PlayerMoveKeyBoard();
        AnimatePlayer();
        
        if (Input.GetButtonDown("Jump")&&isGrounded)
        {
           PlayerJump();
        }
    }
    
    private void PlayerMoveKeyBoard()
    {
        movementX = Input.GetAxisRaw("Horizontal")*moveForce*Time.deltaTime;

        transform.position += new Vector3(movementX, 0f, 0f);

        Vector3 temp = transform.position;
        if (temp.x > maxPosToMove)
        {
            temp.x = maxPosToMove;
        }

        if (temp.x < mimXposToMove)
        {
            temp.x = mimXposToMove;
        }

        transform.position = temp;
    }

    private void AnimatePlayer()
    {
        if (movementX > 0)
        {
            _anim.SetBool(WALKANIMANION,true);
            _sr.flipX = false;
        }else if (movementX < 0)
        {
            _anim.SetBool(WALKANIMANION,true);
            _sr.flipX = true;
        }
        else
        {
            _anim.SetBool(WALKANIMANION,false);
        }
    }

    private void PlayerJump()
    {
        isGrounded = false;
        _rb.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(GROUNDTAG))
        {
            isGrounded = true;
        }

        if (other.gameObject.CompareTag(ENEMYTAG))
        {
            Destroy(gameObject);
        }
    }
}
