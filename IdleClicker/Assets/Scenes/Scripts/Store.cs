using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Store : MonoBehaviour
{
    float currentBalance;
    float baseStoreCost;
    float baseStoreProfit;

    private int storeCount;
    public Text storeCountText;
    public Text currentBalanceText;
    public Slider progressSlider; 

    float storeTimer = 4f;
    float currentTimer = 0f;
    bool startTimer; 

    void Start()
    {
        storeCount = 1;
        currentBalance = 2.00f;
        currentBalanceText.text =  currentBalance.ToString("C2");
        baseStoreProfit = .5f;
        baseStoreCost = 1.50f; 
    }

    void Update()
    {
        if (startTimer)
        {
            currentTimer += Time.deltaTime;
            if (currentTimer > storeTimer)
            {
                currentTimer = 0;
                startTimer = false;
                currentBalance += baseStoreProfit * storeCount;
                currentBalanceText.text = currentBalance.ToString("C2");
            }
        }
        progressSlider.value = currentTimer / storeTimer;
    }

    public void BuyStoreOnClick ()
    {
        if(baseStoreCost > currentBalance)
            return;

        storeCount += 1;
        storeCountText.text = storeCount.ToString();
        currentBalance -= baseStoreCost;
        currentBalanceText.text = currentBalance.ToString("C2");
    }
    public void StoreOnClick ()
    {
        if (!startTimer)
            startTimer = true; 
    }
}
