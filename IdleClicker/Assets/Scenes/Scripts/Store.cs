using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    int storeCount; 

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
    }
}
