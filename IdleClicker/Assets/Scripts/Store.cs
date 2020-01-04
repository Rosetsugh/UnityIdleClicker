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
    public bool isManagerUnlocked;
    public int storeCount;
    public float storeMultiplier;

    private bool startTimer;
    private float currentTimer = 0f;
    private float nextStoreCost;    

    public Text storeCountText;
    public Slider progressSlider;
    public Text storeButtonCostText;
    public gameBoss gameManager;
    public Button buyButton;

    void Start()
    {
        storeCountText.text = storeCount.ToString();
        nextStoreCost = baseStoreCost;
        storeButtonCostText.text = "Buy " + nextStoreCost.ToString("C2");
    }

    void Update()
    {
        if (startTimer)
        {
            currentTimer += Time.deltaTime;
            if (currentTimer >= storeTimer)
            {
                currentTimer = 0;                
                startTimer = false;
                float amount = baseStoreProfit * storeCount;
                gameManager.AddToBalance(amount); 
                if (isManagerUnlocked)                
                    startTimer = true;                
            }
        }
        progressSlider.value = currentTimer / storeTimer;
        CheckStoreBuy();
    }
    public void CheckStoreBuy ()
    {
        if(gameManager.CanBuy(nextStoreCost))
        {
            buyButton.interactable = true;
        } else
        {
            buyButton.interactable = false;
        }
    }


    public void BuyStoreOnClick ()
    {
        if(gameManager.CanBuy(nextStoreCost))
        {
            storeCount += 1;
            storeCountText.text = storeCount.ToString();
            gameManager.AddToBalance(-nextStoreCost);
            nextStoreCost = (baseStoreCost * Mathf.Pow(storeMultiplier, storeCount));
            storeButtonCostText.text = "Buy " + nextStoreCost.ToString("C2");
        }        
    }
    public void StoreOnClick ()
    {
        if (storeCount >= 1)
        {
           if (!startTimer)
               startTimer = true;
        }
         
    }
}
