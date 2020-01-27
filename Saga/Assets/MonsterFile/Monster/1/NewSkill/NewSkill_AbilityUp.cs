using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSkill_AbilityUp : Skill_FoundationScript_Ver_1
{
    //このスクリプトCLASSは能力アップ類スキル
    //能力アップ前のデータ
    public float ability0;//
    //能力アップアップの倍率
    public float abilityMagnification = 2;
    //出力
    public float abilityUp;//
    public GameObject[] Skill_ParticleSystem;


    private void Start()
    {
        skillTime = 0;
    }
    public void SkillMovecontrol()
    {
        //  Debug.Log("SkillMovecontrol");
        skillTime -= Time.deltaTime;
        if (skillTime > 0)
        {
            InOperation();
        }

        if (skillTime <= 0)
        {
            NotInOperation();
        }
    }
    //
    private void InOperation()
    {

        for (int i = 0; i < Skill_ParticleSystem.Length; i++)
        {
            Skill_ParticleSystem[i].SetActive(true);
        }
        abilityUp = ability0 * abilityMagnification;
        Debug.Log("Move NO");
    }

    void NotInOperation()
    {
        skillTime = 0;
        abilityUp = ability0;
        for (int i = 0; i < Skill_ParticleSystem.Length; i++)
        {
            Skill_ParticleSystem[i].SetActive(false);
        }
        //  Debug.Log("Move OFF");
    }






}
