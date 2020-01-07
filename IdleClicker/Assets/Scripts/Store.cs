using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Store : MonoBehaviour 
{
    //Public variables Define gameplay
    public float baseStoreCost;
    public float baseStoreProfit;
    public float storeTimer = 4f;
    public int storeCount;
    public float storeMultiplier;
    public bool storeUnlocked;
    public float unlockRequirements;
    public float storeExp; 

    private bool startTimer;
    public float currentTimer = 0f;
    private float nextStoreCost;

   

    void Start()
    {
        nextStoreCost = baseStoreCost;
    }

    void Update()
    {
        if (storeCount >= 1)
            startTimer = true;

        if (startTimer)
        {
            currentTimer += Time.deltaTime;
            if (currentTimer >= storeTimer)
            {
                currentTimer = 0;                
                startTimer = false;
                float amount = baseStoreProfit * storeCount;
                float exp = storeExp * storeCount;
                gameBoss.instance.AddToBalance(amount, exp);                             
            }
        }
    } 


    public void BuyStoreOnClick ()
    {
        if(gameBoss.instance.CanBuy(nextStoreCost))
        {
            storeCount += 1;
            gameBoss.instance.SubtractFromBalance(nextStoreCost, 0);
            nextStoreCost = (baseStoreCost * Mathf.Pow(storeMultiplier, storeCount));
        }        
    }
    public float GetStoreTimer ()
    {
        return storeTimer;
    }
    public float GetCurrentTimer ()
    {
        return currentTimer;
    }
    public int GetStoreCount ()
    {
        return storeCount;
    }
    public float GetNextStoreCost ()
    {
        return nextStoreCost;
    }
}
