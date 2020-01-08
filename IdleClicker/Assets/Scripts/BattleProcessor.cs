using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleProcessor : MonoBehaviour
{
    public Button battle;
    public Slider heroHealth;
    public Slider monsterHealth;

    private float heroBaseHealth = HeroData.hero.GetHeroHealth();
    private float monsterBaseHealth = MonsterData.monster.CalculateMonsterHealth();
    private float currentMonsterHealth;
    private float currentHeroHealth; 
    
    void Start ()
    {
        currentMonsterHealth = monsterBaseHealth;
        currentHeroHealth = heroBaseHealth;
        heroHealth.value = currentHeroHealth / heroBaseHealth;
        monsterHealth.value = currentMonsterHealth / monsterBaseHealth;
    }

    public void OnAttack ()
    {
        currentMonsterHealth -= HeroData.hero.GetCombatPower(); 
        if(currentMonsterHealth <= 0)
        {
            gameBoss.instance.IncreaseStage(); 
            monsterBaseHealth = MonsterData.monster.CalculateMonsterHealth();
            currentMonsterHealth = monsterBaseHealth;
            return;
        }
        currentHeroHealth -= MonsterData.monster.CalculateMonsterPower(); 
        if(currentHeroHealth <= 0)
        {
            gameBoss.instance.ResetStage();
            monsterBaseHealth = MonsterData.monster.CalculateMonsterHealth();
            currentMonsterHealth = monsterBaseHealth;
            heroBaseHealth = HeroData.hero.GetHeroHealth();
            currentHeroHealth = heroBaseHealth; 
        }
        heroHealth.value = currentHeroHealth / heroBaseHealth;
        monsterHealth.value = currentMonsterHealth / monsterBaseHealth;
    }
}
