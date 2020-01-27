using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDefenseUp : NewSkill_AbilityUp
{//防御力
 /// <summary>
 /// このスクリプトはモンスターの速能力アップする発動タイミング　コントローラー
 /// </summary>
 /// このモンスターは　攻撃受付後　防御力が上げる
    //ダメージ受付前のHP
    public float beforeHp;
    private void Start()
    {
        //アップしたい能力　
        ability0 = GetComponent<MonsterInstinct>().myDefense;
        //ability0の初期はゼロなので　モンスターの能力をゼロにならないように
        abilityUp = ability0;
        //スキルははじめから使える
        isSkillStart = true;

        //モンスターがダメージ受付前のHP
        beforeHp = GetComponent<MonsterInstinct>().myHp;

    }
    void Update()
    {
        //スキル維持時間　カウントダウン  
        SkillMovecontrol();
        ////スキル冷却(れいきゃく)　カウントダウン  
        CountingDown();
        //HP＜beforeHp　スキル使う
      

        if (beforeHp > GetComponent<MonsterInstinct>().myHp && isSkillStart)
        {
            Skill_Start();
        }
        BeforeHpRecordMove();
        //今の防御力
        GetComponent<MonsterInstinct>().myDamage = abilityUp;
    }
    void BeforeHpRecordMove() {
        if (!isSkillStart)
        {//スキル使える前に　今のHPを記録
            beforeHp = GetComponent<MonsterInstinct>().myHp;
        }
    }
}
