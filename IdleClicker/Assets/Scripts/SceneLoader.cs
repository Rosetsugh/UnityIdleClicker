using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public enum State
    {
        Character, Battle, Idle
    }
    public State CurrentState;
    public GameObject idlePanel;
    public GameObject characterPanel;
    public GameObject battlePanel;

    void Start ()
    {
        characterPanel.SetActive(true);
        battlePanel.SetActive(false);
        idlePanel.SetActive(false);
        CurrentState = State.Character;
    }

    public void LoadCharacterPanel ()
    {
        characterPanel.SetActive(true);
        idlePanel.SetActive(false);
        battlePanel.SetActive(false);
    }
    public void OnShowBattle ()
    {
        CurrentState = State.Battle;          
    }
    public void OnShowCharacter ()
    {
        CurrentState = State.Character;
    }
    public void OnShowIdle()
    {
        CurrentState = State.Idle;
    }

 
    public void LoadIdlePanel ()
    {
        characterPanel.SetActive(false);
        idlePanel.SetActive(true);
        battlePanel.SetActive(false);
    }
    public void LoadBattlePanel ()
    {
        characterPanel.SetActive(false);
        idlePanel.SetActive(false);
        battlePanel.SetActive(true);
    }


    public void Quit ()
    {
        Application.Quit();
    }


}
