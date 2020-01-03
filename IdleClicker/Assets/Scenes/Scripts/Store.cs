using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Store : MonoBehaviour 
{
    float baseStoreCost;
    float baseStoreProfit;

    private int storeCount;
    public Text storeCountText;
    public Slider progressSlider; 

    float storeTimer = 4f;
    float currentTimer = 0f;
    bool startTimer;
    public gameBoss gameManager;

    void Start()
    {
        storeCount = 1;
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
                float amount = baseStoreProfit * storeCount;
                gameManager.AddToBalance(amount); 
            }
        }
        progressSlider.value = currentTimer / storeTimer;
    }

    public void BuyStoreOnClick ()
    {
        if(baseStoreCost > gameManager.CurrentBalance())
            return;

        storeCount += 1;
        storeCountText.text = storeCount.ToString();
        gameManager.SubtractFromBalance(baseStoreCost);
    }
    public void StoreOnClick ()
    {
        if (!startTimer)
            startTimer = true; 
    }
}
