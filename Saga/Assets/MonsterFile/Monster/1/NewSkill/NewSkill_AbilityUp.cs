﻿using System.Collections;
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
    public GameObject Skill_ParticleSystem;


    public void SkillMovecontrol()
    {
        Debug.Log("SkillMovecontrol");

        if (skillTime > 0)
        {
            InOperation();
            //スキル維持時間　カウントダウン  
            skillTime -= Time.deltaTime;

            if (skillTime < 0)
            {
                NotInOperation();
            }

        }
    }
    //
    private void InOperation()
    {
        Skill_ParticleSystem.SetActive(true);
        abilityUp = ability0 * abilityMagnification;
        Debug.Log("Move NO");
    }

    private void NotInOperation()
    {
        skillTime = 0;
        abilityUp = ability0;
        Skill_ParticleSystem.SetActive(false);
        Debug.Log("Move OFF");
    }






}