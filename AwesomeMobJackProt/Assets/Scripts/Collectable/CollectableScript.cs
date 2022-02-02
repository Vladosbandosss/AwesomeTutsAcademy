using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(DestroyCollectables),10f);
    }

    private void DestroyCollectables()
    {
        Destroy(gameObject);
    }
}
