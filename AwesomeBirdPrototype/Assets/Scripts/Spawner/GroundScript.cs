using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private void Update()
    {
        DeactivateGround();
    }

    private void DeactivateGround()
    {
        if (Camera.main.transform.position.y > transform.position.y + 9f)
        {
            Spawner.instance.SpawnMoreGrounds();
            gameObject.SetActive(false);
        }
    }
}
