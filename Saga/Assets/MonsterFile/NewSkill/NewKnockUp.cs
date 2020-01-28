using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewKnockUp : NewSkill_AbilityUp
{
    //ノックバック
    /// <summary>
    /// このスクリプトはモンスターの能力をアップする発動タイミング　コントローラー
    /// ノックバック　操作
    /// </summary>
    /// 

    private Rigidbody rb;
    public bool isKnockUp;
    private void Start()
    {
        //アップしたい能力　　突撃速度
        ability0 = GetComponent<MonsterInstinct>().mySpeed;
        //ability0の初期はゼロなので　モンスターの能力をゼロにならないように
        abilityUp = ability0;
        //スキルははじめから使えない
        isSkillStart = false;
        //このモンスターは生成された何秒後からスキルが使える
        Invoke("SkillStart", Random.Range(1, 10));

    }
    void Update()
    {

        ////スキル冷却(れいきゃく)　カウントダウン  
        CountingDown();
 

        //ターゲットあったら　スキル使う
        if (GetComponent<MonsterInstinct>().target != null && isSkillStart)
        {
            //スキル開始
            KnockUpStart();
            //スキルは使ったのでクルーダイム
            Skill_Start();
        }
        
        //スキル維持時間　カウントダウン  
        SkillMovecontrol();
        //スキル
        KnockUpMove();



    }
    private void OnCollisionStay(Collision col) //
    {
        if (col.gameObject.tag == "Player" && skillTime > 0)
        {

            //もし何かを当たったらダメージを与える
            col.gameObject.GetComponent<GunnaerHealth>().MyHp -= (int)GetComponent<MonsterInstinct>().myDamage * 2;
            //このオブジェクトのHP＜0か
            col.gameObject.GetComponent<GunnaerHealth>().Isdie();

            col.transform.gameObject.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            col.transform.gameObject.GetComponent<TakeDamage>().DamageNum = (int)GetComponent<MonsterInstinct>().myDamage * 2;
            KnockUpMoveEnd();
            //ノックアップ
        }
        else if (col.gameObject.name == "Castle"&& skillTime > 0)
        {

            col.gameObject.GetComponent<CastleScript>().MyHp = col.gameObject.GetComponent<CastleScript>().MyHp - (int)GetComponent<MonsterInstinct>().myDamage*3;
            col.gameObject.GetComponent<CastleScript>().IsOVER();
            col.transform.gameObject.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            col.transform.gameObject.GetComponent<TakeDamage>().DamageNum = (int)GetComponent<MonsterInstinct>().myDamage * 3;
            KnockUpMoveEnd();

        }
        else if (col.gameObject.tag == "Machine" && skillTime > 0)
        {

            col.gameObject.GetComponent<MachineBatteryHealth>().MyHp -= (int)(GetComponent<MonsterInstinct>().myDamage * 3f);
            col.gameObject.GetComponent<MachineBatteryHealth>().IsDIe();

            col.transform.gameObject.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            col.transform.gameObject.GetComponent<TakeDamage>().DamageNum = (int)(GetComponent<MonsterInstinct>().myDamage * 2.5f);
            KnockUpMoveEnd();
        }  else  if (col.gameObject.tag == "EliaBox")
        {
            KnockUpMoveEnd();
        }
    }
    //スキル開始
    public void KnockUpStart()
    {
        if (isSkillStart) {
            isKnockUp = true;

            //動きを止める
            GetComponent<MonsterInstinct>().isMove = false;
            GetComponent<MonsterAttack>().isApproachAttack = false;
            GetComponent<MonsterAttack>().isProcessAttack = false;
            //方向獲得
            transform.LookAt(GetComponent<MonsterInstinct>().target);
            rb = gameObject.GetComponent<Rigidbody>();
        }
       

    }

    public void KnockUpMove()
    {
        if (skillTime > 0&& isKnockUp)
        {
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * abilityUp);
        }
        if (skillTime <= 0 && isKnockUp)
        {
            //Spot処理
            KnockUpMoveEnd();
        }

    }
    public void KnockUpMoveEnd()
    {
        if (isKnockUp)
        {
            isKnockUp = false;
            skillTime = 0;
            GetComponent<MonsterInstinct>().isMove = true;
            GetComponent<MonsterAttack>().isApproachAttack = true;
            GetComponent<MonsterAttack>().isProcessAttack = true;
        }
     
    }






















 

    //このモンスターは生成された何秒後からスキルが使える----------------------
    private void SkillStart()
    {
        isSkillStart = true;
    }
}
