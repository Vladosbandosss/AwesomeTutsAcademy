using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMowe : MonoBehaviour
{
    private float speed = 1f;
    private float acceleration = 0.2f;
    private float maxSpeed = 3.2f;

    [HideInInspector] public bool isCameraMoving;

    private void Start()
    {
        isCameraMoving = true;
    }

    private void Update()
    {
        if (isCameraMoving)
        {
            MoveCamera();
        }
    }

    private void MoveCamera()
    {
        Vector3 temp = transform.position;

        float oldY = temp.y;
        float newY = temp.y - (speed * Time.deltaTime);

        temp.y = Mathf.Clamp(temp.y, oldY, newY);
        
        transform.position = temp;

        speed += acceleration * Time.deltaTime;

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }
}
