using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillScriot : MonoBehaviour
{
    public int skillNum;

    // class `は対象にみる
    public class SkillStart
    {  //skill imaje
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
        public void SkillMove()
        {
            if (isSkillStart)
            {
                Debug.Log("ATK");
            }
            else
            {
                Debug.Log(this.skillName + "クールタイム中");
            }
        }

    }
    public class RecoverySkill : SkillStart
    {
        public void SkillMove()
        {
            if (isSkillStart)
            {
                Debug.Log("ATK");
            }
            else
            {
                Debug.Log(this.skillName + "クールタイム中");
            }
        }

    }

    public SkillStart rifleGrenade = new SkillStart();
    public ATKSkill ATK = new ATKSkill();
    public RecoverySkill firstAidSprayBox = new RecoverySkill();

    public GameObject 
        rifleGrenadeImeje,
        firstAidSprayBoxImeji
        ;
    public void Start()
    {

        rifleGrenade.skillName = "rifleGrenade";
        rifleGrenade.skillOutTimeMax = 10;
        //    rifleGrenade.skillimaje = rifleGrenadeImeje;
        ATK.skillName = "ATKrifleGrenade";
        ATK.skillOutTimeMax = 10;
        ATK.skillimaje = rifleGrenadeImeje;

        firstAidSprayBox.skillName = "RecoverySkill";
        firstAidSprayBox.skillOutTimeMax = 10;
        firstAidSprayBox.skillimaje = firstAidSprayBoxImeji;

      
    }
    public void Update()
    {

        if (Input.GetKeyDown("j"))
        {
            if (skillNum < 1)
            {
                ATK.SkillMove();
                ATK.SkillMoveStart();
            }
            else if (skillNum < 2)
            {
                firstAidSprayBox.SkillMove();
                firstAidSprayBox.SkillMoveStart();
            }
            else if (skillNum < 3)
            {
              //  rifleGrenade.SkillMove();
                rifleGrenade.SkillMoveStart();
            }
                // rifleGrenade.SkillMoveStart();



        }
        rifleGrenade.SkillCollTimeMove();
        ATK.SkillCollTimeMove();
        firstAidSprayBox.SkillCollTimeMove();



    }


    /*


        class Program {

            static void Main(string[] args) {
                //スキル実装
                SkillStart rifleGrenade = new SkillStart();
                rifleGrenade.skillOutTimeMax = 10;

            }

        }
        // Start is called before the first frame update


        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                rifleGrenade.SkillMveStart();

            }


         */

}
