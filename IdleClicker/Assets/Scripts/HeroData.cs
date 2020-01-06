using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroData : MonoBehaviour
{
    public int strVal, intVal, dexVal, conVal;
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
    public int GetHeroInt ()
    {
        return intVal; 
    }

    public int GetHeroDex ()
    {
        return dexVal;
    }

    public int GetHeroCon ()
    {
        return conVal; 
    }
    public int GetCombatPower ()
    {
        return combatPower; 
    }

}
