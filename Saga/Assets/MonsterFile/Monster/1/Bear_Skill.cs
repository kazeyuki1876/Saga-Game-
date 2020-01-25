using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear_Skill : MonoBehaviour
{/// <summary>
/// 熊の攻撃アップスキル
/// </summary>
    Skill_AttackUp Bear_AttackUp = new Skill_AttackUp();
    [SerializeField]
    private float skillTime0 = 9999, skillCoolTimeMax = 9999,
        attackUpMagnification = 1.5f;
    //ParticleSystem
    [SerializeField]
    private GameObject attackUp_ParticleSystem;
    [SerializeField]
    private float myHp0;
    [SerializeField]
    private bool isMyHp;
    //private int myHp<>
    // Start is called before the first frame update
    void Start()
    {//最終から使える
        Bear_AttackUp.isSkillStart = true;
        //HP<35％
        myHp0 = GetComponent<MonsterInstinct>().myHp * 0.35f;
        //スキル起動したか
        isMyHp = false;
        attackUp_ParticleSystem.SetActive(false);
        //スキルの持ち主は
        Bear_AttackUp.my = gameObject;
        //熊の攻撃アップできる時間
        Bear_AttackUp.skillTime0 = skillTime0;//
        //熊の攻撃アップ倍率
        Bear_AttackUp.attackUpMagnification = attackUpMagnification;
        //クールタイム
        Bear_AttackUp.skillCoolTimeMax = skillCoolTimeMax;
        Bear_AttackUp.attack0 = GetComponent<MonsterInstinct>().myDamage;
        Bear_AttackUp.attackUp_ParticleSystem = attackUp_ParticleSystem;
    }
    // Update is called once per frame
    void Update()
    {//もし　ターゲットあったら加速
        if (GetComponent<MonsterInstinct>().myHp < myHp0 && !isMyHp)
        {
            //Debug.Log(" if (GetComponent<MonsterInstinct>().myHp < myHp0 &&!isMyHp)");
            isMyHp = true;
            Bear_AttackUp.AttackUp_Start();
        }
     
        //HPが低い時に発動のでクルー処理などのいりません
        //加速クルータイム
        //   Wolf_SpeedUp.SpeedUp_Cooling();
        //スキルクールタイム
        //   Wolf_SpeedUp.SkillCooling();

    }
}

