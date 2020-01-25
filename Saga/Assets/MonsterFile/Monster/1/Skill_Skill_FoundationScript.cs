using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_FoundationScript : MonoBehaviour
{
    /// <summary>
    /// スキル　スビートアップ
    /// スキルが始めると　このオブジェクトの速度が速くなる
    /// 時間後　遅くなる　モンスター専用
    /// </summary>
    /// 
    //全てスキルの基礎
    //スキルの持ち主
    public GameObject my;
    //スキル使えるか
    public bool isSkillStart = false;
    //スキルのクールタイム
    public float skillCoolTimeMax = 1;
    //再使用もでの時間
    public float skillcoolTime = 1;
    //スキル冷却(れいきゃく)
    public void SkillCooling()
    {
        if (skillcoolTime > 0)
        {
            skillcoolTime -= Time.deltaTime;
            if (skillcoolTime < 0)
            {
                skillcoolTime = 0;
                isSkillStart = true;
            }
        }
    }
}
