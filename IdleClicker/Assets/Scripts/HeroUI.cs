using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroUI : MonoBehaviour
{
    // Start is called before the first frame update

    private string heroName;
    public Text heroNameBox, currentHeroExp;
    public Text strBox, intBox, dexBox, conBox, combatPowerBox, strBtnText, conBtnText, intBtnText, dexBtnText;
    public Button strBtn, conBtn, intBtn, dexBtn;
    


    void Start()
    {
        heroName = DetermineHeroName(HeroData.hero.GetCombatPower());
        heroNameBox.text = heroName;
        strBox.text = HeroData.hero.GetHeroStr().ToString();
        intBox.text = HeroData.hero.GetHeroInt().ToString();
        dexBox.text = HeroData.hero.GetHeroDex().ToString();
        conBox.text = HeroData.hero.GetHeroCon().ToString();
        HeroData.hero.UpdateCombatPower(); 
        combatPowerBox.text = "Combat Power: " + HeroData.hero.GetCombatPower();
        strBtnText.text = HeroData.hero.strExpReq.ToString();
        dexBtnText.text = HeroData.hero.dexExpReq.ToString();
        conBtnText.text = HeroData.hero.conExpReq.ToString();
        intBtnText.text = HeroData.hero.intExpReq.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateData ()
    {
        HeroData.hero.UpdateCombatPower();
        combatPowerBox.text = "Combat Power:" + HeroData.hero.GetCombatPower().ToString();
        currentHeroExp.text = gameBoss.instance.GetCurrentExp().ToString();

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
    public void StrButtonClick ()
    {
        HeroData.hero.IncreaseStr();
        strBox.text = HeroData.hero.GetHeroStr().ToString();
        strBtnText.text = HeroData.hero.strExpReq.ToString();
        UpdateData();
    }
    public void DexButtonClick()
    {
        HeroData.hero.IncreaseDex();
        dexBox.text = HeroData.hero.GetHeroDex().ToString();
        dexBtnText.text = HeroData.hero.dexExpReq.ToString();
        UpdateData();
    }
    public void IntButtonClick()
    {
        HeroData.hero.IncreaseInt();
        intBox.text = HeroData.hero.GetHeroInt().ToString();
        intBtnText.text = HeroData.hero.intExpReq.ToString();
        UpdateData();
    }
    public void ConButtonClick()
    {
        HeroData.hero.IncreaseCon();
        conBox.text = HeroData.hero.GetHeroCon().ToString();
        conBtnText.text = HeroData.hero.conExpReq.ToString();
        UpdateData();
    }


}
