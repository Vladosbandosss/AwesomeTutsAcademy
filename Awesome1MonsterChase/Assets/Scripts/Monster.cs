using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector] public float speed;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        speed = 7f;
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(speed, _rb.velocity.y);
    }
}
