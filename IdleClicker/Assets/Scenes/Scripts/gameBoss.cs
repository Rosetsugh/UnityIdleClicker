using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameBoss : MonoBehaviour
{
    private float currentBalance;
    public Text currentBalanceText;

    void Start()
    {
        currentBalance = 6.0f;
        currentBalanceText.text = currentBalance.ToString("C2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddToBalance (float amount)
    {
        currentBalance += amount;
        currentBalanceText.text = currentBalance.ToString("C2");

    }
    public void SubtractFromBalance (float amount)
    {
        currentBalance -= amount;
        currentBalanceText.text = currentBalance.ToString("C2");
    }

    public float CurrentBalance ()
    {
        return currentBalance;
    }
}
