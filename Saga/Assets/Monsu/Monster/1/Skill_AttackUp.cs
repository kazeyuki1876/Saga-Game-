using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_AttackUp : Skill_FoundationScript
{
    public GameObject attackUp_ParticleSystem;
    //加速時間の上限
    public float skillTime0 = 5;
    private float skillTime;
    //加速前の速度
    public float attack0;
    //加速の倍率
    public float attackUpMagnification = 2;
    //加速スタート
    public void AttackUp_Start()
    {
        //   Debug.Log("attackUpTimeStartisSkillStart");
        if (isSkillStart)
        {
            // Debug.Log("attackUpTimeStart");
            isSkillStart = false;
            attackUp_ParticleSystem.SetActive(true);
            skillTime = skillTime0;
            skillcoolTime = skillCoolTimeMax;
            //記録加速の倍率
            // speed0 = my.GetComponent<MonsterInstinct>().mySpeed;
            //攻撃力アップ
            my.GetComponent<MonsterInstinct>().myDamage = attack0 * attackUpMagnification;
            //攻撃力アップ終了（しゅうりょう）
            //  Invoke("SpeedUp_End", skillTime0);
        }
    }
    public void SpeedUp_Cooling()
    {
        if (skillTime > 0)
        {
            //  Debug.Log("attackUpskillTime:" + skillTime);
            skillTime -= Time.deltaTime;
            if (skillTime < 0)
            {
                attackUp_ParticleSystem.SetActive(false);
                skillTime = 0;
                my.GetComponent<MonsterInstinct>().myDamage = attack0;
                //     Debug.Log("attackUpTimeEND");
            }
        }
    }
}
