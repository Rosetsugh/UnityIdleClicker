using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class LoadGameData : MonoBehaviour
{
    public TextAsset GameData;
    public GameObject StorePrefab;
    public GameObject StorePanel; 

    public void Start ()
    {
        Invoke("LoadData", .1f); 
    }


    public void LoadData ()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(GameData.text);

        XmlNodeList StoreList = xmlDoc.GetElementsByTagName("store"); 

        foreach (XmlNode StoreInfo in StoreList)
        {
            GameObject NewStore = (GameObject)Instantiate(StorePrefab);
            Store storeobj = NewStore.GetComponent<Store>(); 

            XmlNodeList StoreNodes = StoreInfo.ChildNodes;
            foreach (XmlNode StoreNode in StoreNodes)
            {
                if (StoreNode.Name == "baseStoreProfit")
                {
                    storeobj.baseStoreProfit = float.Parse(StoreNode.InnerText); 
                } 
                else if (StoreNode.Name == "baseStoreCost")
                {
                    storeobj.baseStoreCost = float.Parse(StoreNode.InnerText); 
                } 
                else if (StoreNode.Name == "name")
                {
                    storeobj.name = StoreNode.InnerText;
                   
                } 
                else if (StoreNode.Name == "storeCount")
                {
                    storeobj.storeCount = int.Parse(StoreNode.InnerText);
                } 
                else if (StoreNode.Name == "storeMultiplier") 
                {
                    storeobj.storeMultiplier =  float.Parse(StoreNode.InnerText);
                } 
                else if (StoreNode.Name == "unlockRequirements")
                {
                    storeobj.unlockRequirements = float.Parse(StoreNode.InnerText);
                }
                else if (StoreNode.Name == "storeUnlocked")
                {
                    storeobj.storeUnlocked = bool.Parse(StoreNode.InnerText);
                }

            }
            NewStore.transform.SetParent(StorePanel.transform); 
        }
    }
}
