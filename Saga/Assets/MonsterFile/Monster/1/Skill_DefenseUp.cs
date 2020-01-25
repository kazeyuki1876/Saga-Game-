using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_DefenseUp : Skill_FoundationScript
{
    public GameObject defenseUp_ParticleSystem;
    //加速時間の上限
    public float skillTime0 = 5;
    private float skillTime;
    //加速前の速度
    public float defense0;
    //加速の倍率
    public float defenseUpMagnification = 2;
    //加速スタート
    public void SpeedUp_Start()
    {
        if (isSkillStart)
        {
            isSkillStart = false;
            defenseUp_ParticleSystem.SetActive(true);
            skillTime = skillTime0;
            skillcoolTime = skillCoolTimeMax;
            //記録加速の倍率
            // speed0 = my.GetComponent<MonsterInstinct>().mySpeed;
            //加速 
            my.GetComponent<MonsterInstinct>().myDefense =(int)( defense0 * defenseUpMagnification);
            //加速終了（しゅうりょう）
            // invoke("SpeedUp_End", skillTime0);

            //  Invoke("SpeedUp_End", skillTime0);
        }
    }
    public void SpeedUp_Cooling()
    {

        if (skillTime > 0)
        {
            //Debug.Log("skillTime:"+ skillTime);
            skillTime -= Time.deltaTime;
            if (skillTime < 0)
            {
                defenseUp_ParticleSystem.SetActive(false);
                skillTime = 0;
                my.GetComponent<MonsterInstinct>().myDefense = defense0;
                Debug.Log("skillTimeEND");
            }
        }
    }
}
