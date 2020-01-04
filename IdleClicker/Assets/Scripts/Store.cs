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

    private bool startTimer;
    private float currentTimer = 0f;
    private float nextStoreCost;    

    public Text storeCountText;
    public Slider progressSlider;
    public Text storeButtonCostText;
    public Button buyButton;

    void Start()
    {
        storeCountText.text = storeCount.ToString();
        nextStoreCost = baseStoreCost;
        storeButtonCostText.text = "Buy " + nextStoreCost.ToString("C2");
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
                gameBoss.instance.AddToBalance(amount); 
                            
            }
        }
        
        progressSlider.value = currentTimer / storeTimer;
        CheckStoreBuy();
    }
    public void CheckStoreBuy ()
    {
        CanvasGroup cg = this.transform.GetComponent<CanvasGroup>();
        if ( !storeUnlocked && gameBoss.instance.TotalEarnings() >= unlockRequirements)
        {
            
            cg.interactable = true;
            cg.alpha = 1;
        }
        else
        {
            cg.interactable = false;
            cg.alpha = 0;
        }
        if(gameBoss.instance.CanBuy(nextStoreCost))
        {
            buyButton.interactable = true;
        } else
        {
            buyButton.interactable = false;
        }
    }


    public void BuyStoreOnClick ()
    {
        if(gameBoss.instance.CanBuy(nextStoreCost))
        {
            storeCount += 1;
            storeCountText.text = storeCount.ToString();
            gameBoss.instance.SubtractFromBalance(nextStoreCost);
            nextStoreCost = (baseStoreCost * Mathf.Pow(storeMultiplier, storeCount));
            storeButtonCostText.text = "Buy " + nextStoreCost.ToString("C2");
        }        
    }
}
