using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameBoss : MonoBehaviour
{
    public delegate void UpdateBalance();
    public delegate void UpdateExp();
    public static event UpdateExp OnUpdateExp;
    public static event UpdateBalance OnUpdateBalance;

    public static gameBoss instance;
    private int currentStage = 1;
    private float currentExp; 
    private float currentBalance;
    private float totalEarnings; 

    void Start()
    {
        currentBalance = 6.0f;
        totalEarnings = currentBalance;
        if (OnUpdateBalance != null)
        {
            OnUpdateBalance();
        }        
    }

    void Awake ()
    {
        if (instance == null)
            instance = this;
    }

    public void AddToBalance (float amount, float exp)
    {
        currentBalance += amount;
        totalEarnings += amount;
        currentExp += exp;
        if (OnUpdateBalance != null)
        {
            OnUpdateBalance();
        }
        if (OnUpdateExp != null)
        {
            OnUpdateExp();
        }
    }

    public void SubtractFromBalance (float amount, float exp)
    {
        currentBalance -= amount;
        currentExp -= exp;
        if (OnUpdateBalance != null)
        {
            OnUpdateBalance(); 
        }
        if (OnUpdateExp != null)
        {
            OnUpdateExp();
        }
    }
    public float TotalEarnings ()
    {
        return totalEarnings; 
    }

    public bool CanBuy (float amount)
    {
        if (amount > currentBalance)
            return false;        

        return true;         
    }
    public float GetCurrentBalance ()
    {
        return currentBalance;
    }
    public float GetCurrentExp ()
    {
        return currentExp;
    }
    public void ReduceCurrentExp (float amount)
    {
        currentExp -= amount;
    }
    public int GetCurrentStage ()
    {
        return currentStage; 
    }
    public void IncreaseStage ()
    {
        currentStage += 1;
    }
    public void ResetStage ()
    {
        currentStage = 1;
    }


}
