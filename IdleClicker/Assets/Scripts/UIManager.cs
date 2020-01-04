using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text currentBalanceText;

   

    // Start is called before the first frame update
    void OnEnable ()
    {
        gameBoss.OnUpdateBalance += UpdateUI; 
    }

    void OnDisable ()
    {
        gameBoss.OnUpdateBalance -= UpdateUI;
    }

    public void UpdateUI ()
    {
        currentBalanceText.text = gameBoss.instance.GetCurrentBalance().ToString("C2"); 
    }



    void Start()
    {
        UpdateUI();   
    }
}
