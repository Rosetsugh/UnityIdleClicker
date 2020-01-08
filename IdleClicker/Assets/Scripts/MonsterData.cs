using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterData : MonoBehaviour
{
    public static MonsterData monster;
    public float monsterMult;
    private float monsterHealth = 100;
    private float monsterCombatPower = 10;
    void Awake ()
    {
        if (monster == null)      
            monster = this;        
    }
    void Start ()
    {

    }
    public float CalculateMonsterHealth ()
    {
        float health = 100;
        if (gameBoss.instance.GetCurrentStage() == 1)
            return health;
      
        health = monsterHealth * Mathf.Pow(monsterMult, gameBoss.instance.GetCurrentStage());
        return health;
    }
    public float CalculateMonsterPower ()
    {
        float power = 100;
        if (gameBoss.instance.GetCurrentStage() == 1)
            return power;

        power = monsterCombatPower * Mathf.Pow(monsterMult, gameBoss.instance.GetCurrentStage());
        return power;
    }
}
