using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBackPack : MonoBehaviour
{
    public int maxNumberToStore = 50;
    public int currentNumbersOfStoredFruits;

    [SerializeField] private Text backPackInfoTxt;


    private void Start()
    {
        SetInfoText(0);
    }

    public void AddFruits(int amount)
    {
        currentNumbersOfStoredFruits += amount;
        
        if (currentNumbersOfStoredFruits > maxNumberToStore)
        {
            currentNumbersOfStoredFruits = maxNumberToStore;
        }
        
        SetInfoText(currentNumbersOfStoredFruits);
        
    }

    public int TakeFruits()
    {
        int takenFruits = currentNumbersOfStoredFruits;
        currentNumbersOfStoredFruits = 0;
        
        SetInfoText(currentNumbersOfStoredFruits);

        return takenFruits;
    }

    private void SetInfoText(int amount)
    {
        backPackInfoTxt.text = "BackPack:" + amount + "/" + maxNumberToStore;
    }



}
