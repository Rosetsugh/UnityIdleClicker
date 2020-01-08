using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    public GameObject idlePanel;
    public GameObject characterPanel;
    public GameObject battlePanel;

    void Start ()
    {
        characterPanel.gameObject.SetActive(true);
        battlePanel.gameObject.SetActive(false);
        idlePanel.gameObject.SetActive(false);
    }

    public void LoadCharacterPanel ()
    {
        characterPanel.gameObject.SetActive(true);
        idlePanel.gameObject.SetActive(false);
        battlePanel.gameObject.SetActive(false);
    }
    public void LoadIdlePanel ()
    {
        characterPanel.gameObject.SetActive(false);
        idlePanel.gameObject.SetActive(true);
        battlePanel.gameObject.SetActive(false);
    }
    public void LoadBattlePanel ()
    {
        characterPanel.gameObject.SetActive(false);
        idlePanel.gameObject.SetActive(false);
        battlePanel.gameObject.SetActive(true);
    }


    public void Quit ()
    {
        Application.Quit();
    }


}
