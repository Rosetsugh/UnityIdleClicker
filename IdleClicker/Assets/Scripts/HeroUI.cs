using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroUI : MonoBehaviour
{
    // Start is called before the first frame update

    public int strVal, intVal, dexVal, conVal;
    private string heroName;
    public Text heroNameBox; 
    public Text strBox;
    public Text intBox;
    public Text dexBox;
    public Text conBox;
    public Text combatPowerBox; 
    int combatPower; 

    void Start()
    {
        combatPower = strVal + intVal + dexVal + conVal;
        heroName = DetermineHeroName(combatPower);
        heroNameBox.text = heroName;
        strBox.text = strVal.ToString();
        intBox.text = intVal.ToString();
        dexBox.text = dexVal.ToString();
        conBox.text = conVal.ToString();
        combatPowerBox.text = "Combat Power: " + combatPower; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private string DetermineHeroName (int powah)
    {
        string name; 
        if (powah < 1000)
        {
            name = "Rookie Hero";
        }else
        {
            name = "Super Hero"; 
        }
        return name; 
    }

}
