using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillScriot : MonoBehaviour
{
    private int skillNum = 0, skillChangeNumMax = 2;
 

    // class `は対象にみる
    public class SkillStart
    {
        public GameObject my;
        //skill imaje
        public GameObject skillimaje;//
        //今このスキルは使えるか
        public bool isSkillStart = true;
        //このスキルの名前
        public string skillName;
        //クールタイム
        public float skillOutTime = 0;
        //クールタイムMAX 
        public float skillOutTimeMax = 10;
        //このスキルは使えるかmove
        public void SkillMoveStart()
        {
            //もし　使える
            if (isSkillStart)
            {
                isSkillStart = false;
                //スキルを放出　
              Debug.Log("スキル" + this.skillName + "を使+いました");
                // タイムに入る
                skillOutTime = skillOutTimeMax;
               Debug.Log("スキルのクールは" + skillOutTimeMax + "クールの処理に入る");
            }
        }
        //もし　このスキルはタイム中の
        public void SkillCollTimeMove()
        {
            //タイムオーバーまでの処理
            if (skillOutTime > 0)
            {
                skillOutTime -= Time.deltaTime;
                //タイムとＵＩの関係
                skillimaje.GetComponent<Image>().fillAmount = 1 - skillOutTime / skillOutTimeMax;
                //タイムオーバー後の処理
                if (skillOutTime < 0)
                {
                    isSkillStart = true;
                }
            }
        }

        //スキル加速できるか
        //スキルの切り替え処理

    }
    public class ATKSkill : SkillStart
    {
        public GameObject grenade;
        public void SkillMove()
        {
            if (isSkillStart)
            {
               GameObject bullet = Instantiate(grenade, my.GetComponent<GunnerShootingMoveController>().gunPos.transform.position, my.GetComponent<GunnerShootingMoveController>().gunPos.transform.rotation);
          
            }
            else
            {
            }
        }

    }
    public class RecoverySkill : SkillStart
    {
        //回復

/*
      new public void SkillMoveStart()
        {
            //もし　使える
            if (isSkillStart && my.GetComponent<GunnaerHealth>().MyHp < my.GetComponent<GunnaerHealth>().myHpMax)
            {
                isSkillStart = false;
                //スキルを放出　
                Debug.Log("スキル" + this.skillName + "を使+いました");
                // タイムに入る
                skillOutTime = skillOutTimeMax;
                Debug.Log("スキルのクールは" + skillOutTimeMax + "クールの処理に入る");
            }
        }*/
        public void SkillMove()
        {

            if (isSkillStart)
            {
                Debug.Log(my.GetComponent<GunnaerHealth>().MyHp +" and"+ my.GetComponent<GunnaerHealth>().myHpMax);

                if (my.GetComponent<GunnaerHealth>() != null && my.GetComponent<GunnaerHealth>().MyHp <(int)my.GetComponent<GunnaerHealth>().myHpMax)
                {
                    my.GetComponent<GunnaerHealth>().MyHp += my.GetComponent<GunnaerHealth>().myHpMax * 0.6f;
                    if (my.GetComponent<GunnaerHealth>().MyHp > my.GetComponent<GunnaerHealth>().myHpMax) {
                        my.GetComponent<GunnaerHealth>().MyHp =(int) my.GetComponent<GunnaerHealth>().myHpMax;
                    }
                }

            }
            else
            {
               
            }
        }

    }

    static List<SkillStart> GunnerSkill = new List<SkillStart>();

    //  new [3]class{ SkillStart,SkillStart,SkillStart };



    public ATKSkill rifleGrenade = new ATKSkill();
    public RecoverySkill firstAidSprayBox = new RecoverySkill();
    [SerializeField]
    private GameObject
        rifleGrenadeImeje,
        firstAidSprayBoxImeji,
        rocketGameObject;
    [SerializeField]
    private GameObject[] ImejeBottom;
  
    public void Start()
    {

        GunnerSkill.Add((SkillStart)(new ATKSkill()));
        //    rifleGrenade.skillimaje = rifleGrenadeImeje;
        rifleGrenade.skillName = "ATKrifleGrenade";
        rifleGrenade.skillOutTimeMax = 5;
        rifleGrenade.skillimaje = rifleGrenadeImeje;
        rifleGrenade.my = this.gameObject;
        rifleGrenade.grenade = rocketGameObject;
        firstAidSprayBox.skillName = "RecoverySkill";
        firstAidSprayBox.skillOutTimeMax = 10;
        firstAidSprayBox.skillimaje = firstAidSprayBoxImeji;
        firstAidSprayBox.my = this.gameObject;

        //   GunnerSkills[0] = new ATKSkill();
        // GunnerSkills[1] = new RecoverySkill();

        //   GunnerSkills = ATKSkill();
    }
    public void Update()

    {
        
        SkillCoolTimeMove();
    }
    private void SkillCoolTimeMove() {
        //ロゲート？
        rifleGrenade.SkillCollTimeMove();
        //回復
        firstAidSprayBox.SkillCollTimeMove();
    }
    //スキル使い
    public void SkillMoveStart() {

        if (skillNum < 1)
        {
            rifleGrenade.SkillMove();
            rifleGrenade.SkillMoveStart();
        }
        else if (skillNum < 2&& GetComponent<GunnaerHealth>().MyHp < (int)GetComponent<GunnaerHealth>().myHpMax)
        {
            firstAidSprayBox.SkillMove();
            firstAidSprayBox.SkillMoveStart();
        }
    }
    //スキル変わる
    public void SkillChangeMove() {
        ImejeBottom[skillNum].GetComponent<Image>().color = new Vector4(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 0.0f / 255.0f);
        skillNum++;
        skillNum = skillNum % skillChangeNumMax;
        ImejeBottom[skillNum].GetComponent<Image>().color = new Vector4(255.0f / 255.0f,0.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f);
        //Debug.Log(skillNum);
    }
}

 


