using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAttackUp : NewSkill_AbilityUp
{//攻撃力
 /// <summary>
 /// このスクリプトはモンスターの能力をアップする発動タイミング　コントローラー
 /// </summary>
 　　//最初のHP
    private float startHp;
    
    private void Start()
    {//アップしたい能力　
        ability0 = GetComponent<MonsterInstinct>().myDamage;
        //ability0の初期はゼロなので　モンスターの能力をゼロにならないように
        abilityUp = ability0;
        //スキルははじめから使える
        isSkillStart = true;

        startHp = GetComponent<MonsterInstinct>().myHp;
    }
    void Update()
    {    //スキル維持時間　カウントダウン  
        SkillMovecontrol();
        ////スキル冷却(れいきゃく)　カウントダウン  
        CountingDown();
        //HP< 　startHp*倍率
        if (GetComponent<MonsterInstinct>().myHp< startHp*0.4f)
        {
            Skill_Start();
        }
        //今の攻撃力
        GetComponent<MonsterInstinct>().myDamage = abilityUp;
    }
}

//NewSkill_AttackUp