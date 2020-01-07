using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    public GameObject idlePanel;
    public GameObject characterPanel; 

    public void LoadCharacterPanel ()
    {
        characterPanel.gameObject.SetActive(true);
        idlePanel.gameObject.SetActive(false);
    }
    public void LoadIdlePanel ()
    {
        characterPanel.gameObject.SetActive(false);
        idlePanel.gameObject.SetActive(true);
    }
    public void Quit ()
    {
        Application.Quit();
    }


}
