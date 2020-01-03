using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Store : MonoBehaviour
{
    private int storeCount;
    public Text storeCountText;

    void Start()
    {
        storeCount = 1;
    }

    void Update()
    {
        
    }
    public void BuyStoreOnClick ()
    {
        storeCount += 1;
        storeCountText.text = storeCount.ToString();
    }
}
