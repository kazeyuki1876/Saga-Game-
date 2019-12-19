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
        private float skillOutTime = 0;
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
                ////反発
             

            }
            else
            {
               
            }
        }

    }
    public class RecoverySkill : SkillStart
    {
        //回復
       
        public void SkillMove()
        {

            if (isSkillStart)
            {
                
               
                if (my.GetComponent<GunnaerHealth>() != null)
                {
                    my.GetComponent<GunnaerHealth>().MyHp += 50;
                }

            }
            else
            {
               
            }
        }

    }
    class Skills
    {//一つの変数でスキルを使う　難しいな　動く変数化のＣＬＡＳＳ命が欲しい


    }
    Skills[] GunnerSkills = new Skills[3];

    //  new [3]class{ SkillStart,SkillStart,SkillStart };


    public ATKSkill rifleGrenade = new ATKSkill();
    public RecoverySkill firstAidSprayBox = new RecoverySkill();
    [SerializeField]
    private GameObject
        rifleGrenadeImeje,
        firstAidSprayBoxImeji,
        rocketGameObject;
        
  
    public void Start()
    {


        //    rifleGrenade.skillimaje = rifleGrenadeImeje;
        rifleGrenade.skillName = "ATKrifleGrenade";
        rifleGrenade.skillOutTimeMax = 10;
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
        else if (skillNum < 2)
        {
            firstAidSprayBox.SkillMove();
            firstAidSprayBox.SkillMoveStart();
        }
    }
 
    //スキル変わる
    public void SkillChangeMove() {
        skillNum++;
        skillNum = skillNum % skillChangeNumMax;
        Debug.Log(skillNum);
    }

}

 


