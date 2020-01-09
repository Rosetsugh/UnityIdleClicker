using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleProcessor : MonoBehaviour
{
    public Button battle;
    public Slider heroHealth;
    public Slider monsterHealth;
    public Text heroBaseHealthText;
    public Text MonsterBaseHealthText;

    //private float heroBaseHealth = HeroData.hero.GetHeroHealth();
    private float heroBaseHealth = 100;
    private float monsterBaseHealth = 100;
    private float currentMonsterHealth;
    private float currentHeroHealth; 
  
    void Start ()
    {
        heroBaseHealth = HeroData.hero.GetHeroHealth();
        monsterBaseHealth = MonsterData.monster.CalculateMonsterHealth();
        currentMonsterHealth = monsterBaseHealth;
        currentHeroHealth = heroBaseHealth;
        heroHealth.value = currentHeroHealth / heroBaseHealth;
        monsterHealth.value = currentMonsterHealth / monsterBaseHealth;
        heroBaseHealthText.text = heroBaseHealth.ToString();
        MonsterBaseHealthText.text = monsterBaseHealth.ToString();
    }
    void Update ()
    {
      
    }
    void UpdateSliders ()
    {
        heroHealth.value = heroBaseHealth/ currentHeroHealth;
        monsterHealth.value = currentMonsterHealth / monsterBaseHealth;
        heroBaseHealthText.text = heroBaseHealth.ToString();
        MonsterBaseHealthText.text = monsterBaseHealth.ToString();
    }

    public void OnAttack ()
    {
        currentMonsterHealth -= HeroData.hero.GetCombatPower();
        Debug.Log(currentMonsterHealth);
        if(currentMonsterHealth <= 0)
        {
            gameBoss.instance.IncreaseStage(); 
            monsterBaseHealth = MonsterData.monster.CalculateMonsterHealth();
            currentMonsterHealth = monsterBaseHealth;
            return;
        }
        currentHeroHealth -= MonsterData.monster.CalculateMonsterPower();
        Debug.Log(currentHeroHealth);
        if (currentHeroHealth <= 0)
        {
            Debug.Log("Is this working? :" + currentHeroHealth);
            gameBoss.instance.ResetStage();
            monsterBaseHealth = MonsterData.monster.CalculateMonsterHealth();
            currentMonsterHealth = monsterBaseHealth;
            heroBaseHealth = HeroData.hero.GetHeroHealth();
            Debug.Log("What is the Get Hero Health equal 2" + HeroData.hero.GetHeroHealth());
            currentHeroHealth = heroBaseHealth; 
        }
        UpdateSliders();
    }
}
