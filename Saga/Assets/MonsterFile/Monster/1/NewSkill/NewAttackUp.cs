using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAttackUp : NewSkill_AbilityUp
{//攻撃力
    /// <summary>
    /// このスクリプトはモンスターの速度をアップする発動タイミング　コントローラー
    /// </summary>

    private void Start()
    {//アップしたい能力　
        ability0 = GetComponent<MonsterInstinct>().myDamage;
        //ability0の初期はゼロなので　モンスターの能力をゼロにならないように
        abilityUp = ability0;
        //スキルははじめから使える
        isSkillStart = true;
    }
    void Update()
    {    //スキル維持時間　カウントダウン  
        SkillMovecontrol();
        ////スキル冷却(れいきゃく)　カウントダウン  
        CountingDown();
        //ターゲットあったら　スキル使う
        if (GetComponent<MonsterInstinct>().target != null)
        {
            Skill_Start();
        }
        //今の速度
        GetComponent<MonsterInstinct>().myDamage = abilityUp;
    }
}

//NewSkill_AttackUp