using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour
{
    [SerializeField] private float speed=0.1f;
    
    private Vector2 offset=Vector2.zero;
    private Material mat;

    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
        offset = mat.GetTextureOffset("_MainTex");
    }

    private void Update()
    {
        offset.x += speed * Time.deltaTime;
        mat.SetTextureOffset("_MainTex",offset);
    }
}
