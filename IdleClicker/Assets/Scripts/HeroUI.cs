using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroUI : MonoBehaviour
{
    // Start is called before the first frame update

    private string heroName;
    public Text heroNameBox;
    public Text strBox, intBox, dexBox, conBox, combatPowerBox, currentExpBox;
    public Button strBtn, conBtn, intBtn, dexBtn;
    public Text strBtnText, conBtnText, intBtnText, dexBtnText;


    void Start()
    {
        heroName = DetermineHeroName(HeroData.hero.GetCombatPower());
        heroNameBox.text = heroName;
        strBox.text = HeroData.hero.GetHeroStr().ToString();
        intBox.text = HeroData.hero.GetHeroInt().ToString();
        dexBox.text = HeroData.hero.GetHeroDex().ToString();
        conBox.text = HeroData.hero.GetHeroCon().ToString();
        strBtnText.text = "Cost: " + HeroData.hero.strExpReq.ToString();
        dexBtnText.text = "Cost: " + HeroData.hero.dexExpReq.ToString();
        intBtnText.text = "Cost: " + HeroData.hero.intExpReq.ToString();
        conBtnText.text = "Cost: " + HeroData.hero.conExpReq.ToString();
        HeroData.hero.UpdateCombatPower(); 
        combatPowerBox.text = "Combat Power: " + HeroData.hero.GetCombatPower(); 
    }

    private void UpdateData ()
    {
        HeroData.hero.UpdateCombatPower();
        currentExpBox.text = gameBoss.instance.GetCurrentExp().ToString();
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
    public void StrButtonClick ()
    {
        HeroData.hero.IncreaseStr();
        strBox.text = HeroData.hero.GetHeroStr().ToString();
        strBtnText.text = "Cost: " + HeroData.hero.strExpReq.ToString();
        UpdateData();
    }
    public void DexButtonClick()
    {
        HeroData.hero.IncreaseDex();
        dexBox.text = HeroData.hero.GetHeroDex().ToString();
        dexBtnText.text = "Cost: " + HeroData.hero.dexExpReq.ToString();
        UpdateData();
    }
    public void IntButtonClick()
    {
        HeroData.hero.IncreaseInt();
        intBox.text = HeroData.hero.GetHeroInt().ToString();
        intBtnText.text = "Cost: " + HeroData.hero.intExpReq.ToString();
        UpdateData();
    }
    public void ConButtonClick()
    {
        HeroData.hero.IncreaseCon();
        conBox.text = HeroData.hero.GetHeroCon().ToString();
        conBtnText.text = "Cost: " + HeroData.hero.conExpReq.ToString();
        UpdateData();
    }
}
