using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf＿Skill : MonoBehaviour
{/// <summary>
/// 狼の加速スキル
/// </summary>
    Skill_SpeedUp Wolf_SpeedUp = new Skill_SpeedUp();
    [SerializeField]
    private float skillTime0=5, skillCoolTimeMax = 10,
        speedMagnification=1.5f;
    //ParticleSystem
    [SerializeField]
    private GameObject SpeedUp_ParticleSystem;
    // Start is called before the first frame update
    void Start()
    {//
        SpeedUp_ParticleSystem.SetActive(false);
        //スキルの持ち主は
        Wolf_SpeedUp.my = gameObject;
        //狼の加速できる時間
        Wolf_SpeedUp.skillTime0 = skillTime0;//
        //狼の加速倍率
        Wolf_SpeedUp.speedMagnification = speedMagnification;
        //クールタイム
        Wolf_SpeedUp.skillCoolTimeMax = skillCoolTimeMax;
        Wolf_SpeedUp.speed0= GetComponent<MonsterInstinct>().mySpeed;
        Wolf_SpeedUp.SpeedUp_ParticleSystem = SpeedUp_ParticleSystem;  
    }

    // Update is called once per frame
    void Update()
    {//もし　ターゲットあったら加速
        if (GetComponent<MonsterInstinct>().target != null)
        {
            Wolf_SpeedUp.SpeedUp_Start();
        }
      //加速クルータイム
        Wolf_SpeedUp.SpeedUp_Cooling();
        //スキルクールタイム
        Wolf_SpeedUp.SkillCooling();
      
    }
}
/*
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
    public bool isSkillStart = true;
    //スキルのクールタイム
    public float skillCoolTimeMax = 1;
    //再使用もでの時間
    public float skillcoolTime = 1;
    //スキル冷却(れいきゃく)
    void SkillCooling()
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

    //---
    //加速時間の上限
    public float skillTime0 = 5;
    //加速前の速度
    public float speed0;
    //加速の倍率
    public float speedMagnification = 2;
    //加速スタート
    void SpeedUp_Start()
    {
        if (isSkillStart)
        {
            isSkillStart = false;
            skillcoolTime = skillCoolTimeMax;
            //記録加速の倍率
            speed0 = my.GetComponent<MonsterInstinct>().mySpeed;
            //加速
            my.GetComponent<MonsterInstinct>().mySpeed = speed0 * speedMagnification;
            //加速終了（しゅうりょう）
            // invoke("SpeedUp_End", skillTime0);
            Invoke("Skill_SpeedUp", 5.0f);
        }
    }
    private void SpeedUp_End()
    {
        my.GetComponent<MonsterInstinct>().mySpeed = speed0;
    }
     
     
     
     
     */
