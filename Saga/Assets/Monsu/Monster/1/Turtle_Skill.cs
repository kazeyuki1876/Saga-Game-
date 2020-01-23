using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle_Skill : MonoBehaviour
{/// <summary>
/// 防御力アップスキル
/// </summary>
    Skill_DefenseUp Turtle_SpeedUp = new Skill_DefenseUp();
    [SerializeField]
    private float
        skillTime0 = 5,
        skillCoolTimeMax = 10,
        defenseUpMagnification = 1.5f;
    //ParticleSystem
    [SerializeField]
    private GameObject defenseUp_ParticleSystem;
    // Start is called before the first frame update
    void Start()
    {//
        defenseUp_ParticleSystem.SetActive(false);
        //スキルの持ち主は
        Turtle_SpeedUp.isSkillStart = true;
        Turtle_SpeedUp.my = gameObject;
        //狼の加速できる時間
        Turtle_SpeedUp.skillTime0 = skillTime0;//
        //狼の加速倍率
        Turtle_SpeedUp.defenseUpMagnification = defenseUpMagnification;
        //クールタイム
        Turtle_SpeedUp.skillCoolTimeMax = skillCoolTimeMax;
        Turtle_SpeedUp.defense0 = GetComponent<MonsterInstinct>().myDefense;
        //防御力0のモンスターはあります
        if (Turtle_SpeedUp.defense0 < 1)
        {
            Turtle_SpeedUp.defense0 = 2.5f;
        }
        Turtle_SpeedUp.defenseUp_ParticleSystem = defenseUp_ParticleSystem;
    }

    // Update is called once per frame
    void Update()
    {//もし　ターゲットあったら加速
        if (GetComponent<MonsterInstinct>().target != null)
        {
            Turtle_SpeedUp.SpeedUp_Start();
        }
        //加速クルータイム
        Turtle_SpeedUp.SpeedUp_Cooling();
        //スキルクールタイム
        Turtle_SpeedUp.SkillCooling();

    }
}
