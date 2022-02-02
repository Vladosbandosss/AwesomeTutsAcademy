using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private AudioClip jumpClip;
    
    private Rigidbody2D rb;
    
    private float jumpForce = 12f;
    
    private bool canJump =true;

    private Button jumpBtn;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        jumpBtn = GameObject.Find(TagManager.JUMPBUTTONNAME).GetComponent<Button>();
        
        jumpBtn.onClick.AddListener(()=>Jump());
    }
    
    private void Jump()
    {
        if (rb.velocity.y == 0)
        {
            canJump = true;
        }
        
        if (canJump)
        {
            canJump = false;
            
            //AudioSource.PlayClipAtPoint(jumpClip,transform.position);
            
            rb.velocity = new Vector2(0f, jumpForce);
        }
    }
}
