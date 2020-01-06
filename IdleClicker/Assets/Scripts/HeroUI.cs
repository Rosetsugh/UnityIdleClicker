using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroUI : MonoBehaviour
{
    // Start is called before the first frame update

    private string heroName;
    public Text heroNameBox; 
    public Text strBox;
    public Text intBox;
    public Text dexBox;
    public Text conBox;
    public Text combatPowerBox; 


    void Start()
    {
        heroName = DetermineHeroName(HeroData.hero.GetCombatPower());
        heroNameBox.text = heroName;
        strBox.text = HeroData.hero.GetHeroStr().ToString();
        intBox.text = HeroData.hero.GetHeroInt().ToString();
        dexBox.text = HeroData.hero.GetHeroDex().ToString();
        conBox.text = HeroData.hero.GetHeroCon().ToString(); 
        combatPowerBox.text = "Combat Power: " + HeroData.hero.GetCombatPower(); 
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
