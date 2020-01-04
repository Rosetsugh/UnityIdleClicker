using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStore : MonoBehaviour
{
    public Text storeCountText;
    public Slider progressSlider;
    public Text storeButtonCostText;
    public Button buyButton;
    public Store store; 

    void Awake ()
    {
        store = transform.GetComponent<Store>(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        storeCountText.text = store.storeCount.ToString();
        storeButtonCostText.text = store.GetNextStoreCost().ToString("C2");
    }

    // Update is called once per frame
    void Update()
    {
        progressSlider.value = store.GetCurrentTimer() / store.GetStoreTimer();
        UpdateUI();
    }
    public void UpdateUI()
    {
        // Hide panel until you can afford the store
        CanvasGroup cg = this.transform.GetComponent<CanvasGroup>();
        if (!store.storeUnlocked && gameBoss.instance.TotalEarnings() >= store.unlockRequirements)
        {
            cg.interactable = true;
            cg.alpha = 1;
        }
        else
        {
            cg.interactable = false;
            cg.alpha = 0;
        }
        if (gameBoss.instance.CanBuy(store.GetNextStoreCost()))
        {
            buyButton.interactable = true;
        }
        else
        {
            buyButton.interactable = false;
        }
        storeCountText.text = store.storeCount.ToString();
        storeButtonCostText.text = store.GetNextStoreCost().ToString("C2");
    }
}
