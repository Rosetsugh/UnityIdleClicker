using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    


    public Text currentBalanceText;
    public Text generatedExpText;

   

    // Start is called before the first frame update
    void OnEnable ()
    {
        gameBoss.OnUpdateBalance += UpdateUI;
        gameBoss.OnUpdateExp += UpdateUI;
    }

    void OnDisable ()
    {
        gameBoss.OnUpdateBalance -= UpdateUI;
        gameBoss.OnUpdateExp -= UpdateUI;

    }

    public void UpdateUI ()
    {
        currentBalanceText.text = gameBoss.instance.GetCurrentBalance().ToString("C2");
        generatedExpText.text = gameBoss.instance.GetCurrentExp().ToString();
    }



    void Start()
    {
        UpdateUI();   
    }
}
