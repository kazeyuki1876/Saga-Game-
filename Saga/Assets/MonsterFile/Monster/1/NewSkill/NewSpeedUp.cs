using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpeedUp : NewSkill_AbilityUp
{//速度
    /// <summary>
    /// このスクリプトはモンスターの速度をアップする発動タイミング　コントローラー
    /// </summary>

    private void Start()
    {//アップしたい能力　
        ability0 = GetComponent<MonsterInstinct>().mySpeed;
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
        GetComponent<MonsterInstinct>().mySpeed = abilityUp;
    }
}
