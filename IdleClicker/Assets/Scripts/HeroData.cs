using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroData : MonoBehaviour
{
    public int strVal, intVal, dexVal, conVal;
    public float strExpReq, intExpReq, dexExpReq, conExpReq;
    public float expMult; 
    private int increaseVal = 1;
    private int combatPower;
    public static HeroData hero; 

    void Awake ()
    {
        if (hero == null)
        {
            hero = this; 
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        UpdateCombatPower();
    }
    public void UpdateCombatPower ()
    {
        combatPower = strVal + intVal + dexVal + conVal; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetHeroStr ()
    {
        return strVal;
    }
    public void IncreaseStr ()
    {
        if (gameBoss.instance.GetCurrentExp() >= strExpReq)
        {
            strVal += increaseVal;
            gameBoss.instance.ReduceCurrentExp(strExpReq);
            strExpReq = strExpReq * Mathf.Pow(expMult, (strVal - 10));
        }
    }
    public int GetHeroInt ()
    {
        return intVal; 
    }
    public void IncreaseInt()
    {
        if (gameBoss.instance.GetCurrentExp() >= intExpReq)
        {
            intVal += increaseVal;
            gameBoss.instance.ReduceCurrentExp(intExpReq);
            intExpReq = intExpReq * Mathf.Pow(expMult, (intVal - 10));
        }
    }
    public int GetHeroDex ()
    {
        return dexVal;
    }
    public void IncreaseDex()
    {
        if (gameBoss.instance.GetCurrentExp() >= dexExpReq)
        {
            dexVal += increaseVal;
            gameBoss.instance.ReduceCurrentExp(dexExpReq);
            dexExpReq = dexExpReq * Mathf.Pow(expMult, (dexVal - 10));
        }
    }

    public int GetHeroCon ()
    {
        return conVal; 
    }
    public void IncreaseCon()
    {
        if (gameBoss.instance.GetCurrentExp() >= conExpReq)
        {
            conVal += increaseVal;
            gameBoss.instance.ReduceCurrentExp(conExpReq);
            conExpReq = conExpReq * Mathf.Pow(expMult, (conVal - 10));
        }
    }

    public int GetCombatPower ()
    {
        return combatPower; 
    }
}
