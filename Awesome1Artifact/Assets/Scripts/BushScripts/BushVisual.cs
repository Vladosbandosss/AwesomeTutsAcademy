using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BushVisual : MonoBehaviour
{
    [SerializeField] private Sprite[] bushSprites, fruitSprites, drySprites;

    [SerializeField] private SpriteRenderer[] fruitsRenderers;
    public enum BushVariant
    {
        Green,
        Cyan,
        Yellow
    }
    BushVariant _bushVariant;

    [SerializeField] private float hideTimePerFruit = 0.2f;
    private SpriteRenderer _sr;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();

        _bushVariant = (BushVariant) Random.Range(0, bushSprites.Length);
        _sr.sprite = bushSprites[(int) _bushVariant];

        if (Random.Range(0, 2) == 1)
        {
            _sr.flipX = true;
        }

        for(int i = 0; i < fruitsRenderers.Length; i++)
        {
            fruitsRenderers[i].sprite = fruitSprites[(int) _bushVariant];
            fruitsRenderers[i].enabled = false;
        }
    }

    public BushVariant GetBushVariant()
    {
        return _bushVariant;
    }

    public void SetToDry()
    {
        _sr.sprite = drySprites[(int) _bushVariant];
    }

    IEnumerator _HideFruits(float time, int index)
    {
        yield return new WaitForSeconds(time);
        fruitsRenderers[index].enabled = false;
    }

    public void HideFruits()
    {
        float waitTimeForFruit = hideTimePerFruit;

        for (int i = 0; i < fruitsRenderers.Length; i++)
        {
            StartCoroutine(_HideFruits(waitTimeForFruit,i));
            waitTimeForFruit += hideTimePerFruit;
        }
    }

    public void ShowFruits()
    {
        for (int i = 0; i < fruitsRenderers.Length; i++)
        {
            fruitsRenderers[i].enabled = true;
        }
    }
}
