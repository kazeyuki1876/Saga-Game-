using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orca_Skill : MonoBehaviour
{
    Skill_KnockUp Orca = new Skill_KnockUp();
    //クルータイム
    private float skillCoolTime=5;
    //スキルタイム
    private float skillMoveTime=0.5f;
    //スキル速度
    public float skillMoveSpeed = 20;
    //ダメージ処理
    public GameObject[] knockUpParticleSystem = new GameObject[2];

    // Start is called before the first frame update
    void Start()
    {//クルータイム

        Orca.my = gameObject;
        Orca.skillCoolTimeMax = skillCoolTime;
        Orca.knockUpSkillTime = 0;
        Orca.knockUpSkillTime0 = skillMoveTime;

        for (int i = 0; i < knockUpParticleSystem.Length; i++) {
            Orca.knockUpParticleSystem[i] = knockUpParticleSystem[i];
            knockUpParticleSystem[i].SetActive(false);
        }



        Orca.knockUpSpeed = skillMoveSpeed;
        Invoke("SkillStart", Random.Range(1,10));
    }
   
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<MonsterInstinct>().target != null) {
            Orca.KnockUpStart();
        }
       
    }
    private void FixedUpdate()
    {
       Orca. KnockUpMove();
    }

    private void OnCollisionStay(Collision col) //
    {
        if (col.gameObject.tag == "Player"&& Orca.knockUpSkillTime>0)
        {
          
            //もし何かを当たったらダメージを与える
            col.gameObject.GetComponent<GunnaerHealth>().MyHp -=  (int)GetComponent<MonsterInstinct>().myDamage*2;
            //このオブジェクトのHP＜0か
            col.transform.gameObject.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            col.transform.gameObject.GetComponent<TakeDamage>().DamageNum = (int)GetComponent<MonsterInstinct>().myDamage * 2;

            col.gameObject.GetComponent<GunnaerHealth>().Isdie();
            Orca.KnockUpMoveEnd();
            //ノックアップ
        }/*
        else if (col.gameObject.name == "Castle")
        {
           
            col.gameObject.GetComponent<CastleScript>().MyHp = col.gameObject.GetComponent<CastleScript>().MyHp - (int)GetComponent<MonsterInstinct>().myDamage;
            col.gameObject.GetComponent<CastleScript>().IsOVER();

        }*/
        else if (col.gameObject.tag == "Machine"&&Orca.knockUpSkillTime > 0 )
        {
        
            col.gameObject.GetComponent<MachineBatteryHealth>().MyHp -= (int)(GetComponent<MonsterInstinct>().myDamage*2.5f);
            col.gameObject.GetComponent<MachineBatteryHealth>().IsDIe();
            col.transform.gameObject.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            col.transform.gameObject.GetComponent<TakeDamage>().DamageNum = (int)(GetComponent<MonsterInstinct>().myDamage * 2.5f);

            Orca.KnockUpMoveEnd();
        }
        if (col.gameObject.tag == "EliaBox") {
            Orca.KnockUpMoveEnd();
        }
    }
    private void  SkillStart() {
        Orca.isSkillStart = true;
    }
}
