using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_FoundationScript_Ver_1 : MonoBehaviour
{
    //全てスキルの基礎
    // スキルが始めると　このオブジェクトの速度が速くなる
    // 時間後　遅くなる　モンスター専用
    //エフェクト　MOVEなど関係ません
    //スキルの持ち主
    // public GameObject my;いらない
    //スキル使えるか
    public bool isSkillStart = false;
    //スキルのクールタイム
    public float skillCoolTimeMax = 1;
    //再使用もでの時間
    public float skillcoolTime = 1;
    //スキル維持時間の上限
    public float skillTime0 = 5;
    //スキル維持時間
    public float skillTime;
    public void Skill_Start()
    {
        if (isSkillStart)
        {//再使用を防ぐ
            isSkillStart = false;
            //スキルカウントダウン 開始
            skillTime = skillTime0;
            //クルーカウントダウン開始
            skillcoolTime = skillCoolTimeMax;
            Debug.Log("isSkillStart");
        }
    }
    //カウントダウン  
    public void CountingDown()
    {// 
        ////スキル冷却(れいきゃく)　カウントダウン  
        if (skillcoolTime > 0)
        {
          //  Debug.Log("スキル冷却(れいきゃく)");
            skillcoolTime -= Time.deltaTime;
            if (skillcoolTime < 0)
            {
                skillcoolTime = 0;
                //冷却完了　再使用許可
                isSkillStart = true;
          //      Debug.Log("冷却完了　再使用許可)");
            }
        }
    }
}
