using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameBoss : MonoBehaviour
{
    public delegate void UpdateBalance();
    public static event UpdateBalance OnUpdateBalance;

    public static gameBoss instance; 
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

    public void AddToBalance (float amount)
    {
        currentBalance += amount;
        totalEarnings += amount;
        if (OnUpdateBalance != null)
        {
            OnUpdateBalance();
        }
    }

    public void SubtractFromBalance (float amount)
    {
        currentBalance -= amount;
        if (OnUpdateBalance != null)
        {
            OnUpdateBalance(); 
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
}
