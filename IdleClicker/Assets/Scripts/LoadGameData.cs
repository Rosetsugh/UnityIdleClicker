using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameData : MonoBehaviour
{
    public TextAsset GameData;
    public GameObject StorePrefabBlackSmith;
    public GameObject StorePrefabHerbalist;
    public GameObject StorePrefabAlchemist;
    public GameObject StorePanel; 

    public void Start ()
    {
        LoadData();
        //Invoke("LoadData", .1f); 
    }


    public void LoadData ()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(GameData.text);

        XmlNodeList StoreList = xmlDoc.GetElementsByTagName("store"); 

        for (int i = 0; i < StoreList.Count; i++)
        {
            GameObject NewStore;
            Store storeobj;
            XmlNodeList StoreNodes;
            if (i < 3)
            {
                NewStore = (GameObject)Instantiate(StorePrefabBlackSmith);
                storeobj = NewStore.GetComponent<Store>();
                StoreNodes = StoreList[i].ChildNodes;
            } else if (i >= 3 && i < 6)
            {
                NewStore = (GameObject)Instantiate(StorePrefabHerbalist);
                storeobj = NewStore.GetComponent<Store>();
                StoreNodes = StoreList[i].ChildNodes;
            } else
            {
                NewStore = (GameObject)Instantiate(StorePrefabAlchemist);
                storeobj = NewStore.GetComponent<Store>();
                StoreNodes = StoreList[i].ChildNodes;
            }
            foreach (XmlNode StoreNode in StoreNodes)
            {
                if (StoreNode.Name == "name")
                {
                    string SetName = StoreNode.InnerText;
                    Text storeText = storeobj.transform.Find("StoreNameText").GetComponent<Text>();
                    storeText.text = SetName;
                }
                else if (StoreNode.Name == "image")
                {
                    Sprite newSprite = Resources.Load<Sprite>(StoreNode.InnerText);
                    Image storeImage = storeobj.transform.Find("Image").GetComponent<Image>();
                    storeImage.sprite = newSprite;
                }
                else if (StoreNode.Name == "baseStoreProfit")
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
                    storeobj.storeMultiplier = float.Parse(StoreNode.InnerText);
                }
                else if (StoreNode.Name == "unlockRequirements")
                {
                    storeobj.unlockRequirements = float.Parse(StoreNode.InnerText);
                }
                else if (StoreNode.Name == "storeUnlocked")
                {
                    storeobj.storeUnlocked = bool.Parse(StoreNode.InnerText);
                }
                else if (StoreNode.Name == "storeTimer")
                {
                    storeobj.storeTimer = float.Parse(StoreNode.InnerText);
                }
            }
            NewStore.transform.SetParent(StorePanel.transform);
        }
    }
    /*

        foreach (XmlNode StoreInfo in StoreList)
        {
            GameObject NewStore = (GameObject)Instantiate(StorePrefabBlackSmith);
            Store storeobj = NewStore.GetComponent<Store>(); 

            XmlNodeList StoreNodes = StoreInfo.ChildNodes;
            foreach (XmlNode StoreNode in StoreNodes)
            {
                if (StoreNode.Name == "name")
                {
                    string SetName = StoreNode.InnerText;
                    Text storeText = storeobj.transform.Find("StoreNameText").GetComponent<Text>();
                    storeText.text = SetName;
                }
                else if (StoreNode.Name == "image")
                {
                    Sprite newSprite = Resources.Load<Sprite>(StoreNode.InnerText);
                    Image storeImage = storeobj.transform.Find("Image").GetComponent<Image>();
                    storeImage.sprite = newSprite;
                }
                else if (StoreNode.Name == "baseStoreProfit")
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
                else if (StoreNode.Name == "storeTimer")
                {
                    storeobj.storeTimer = float.Parse(StoreNode.InnerText);
                }
            }
            NewStore.transform.SetParent(StorePanel.transform); 
        }
    }
    */
}
