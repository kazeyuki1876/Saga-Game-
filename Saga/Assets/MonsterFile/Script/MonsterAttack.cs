﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    //      
    
      // //接近攻撃できるか
    public bool isApproachAttack = true;
    // //遠距離攻撃できるか
    public bool isProcessAttack = true;
    [SerializeField]

    private float processAttack=1;
    [SerializeField]
    private float processAttackSpeed = 15;
    //遠距離攻撃の弾
    [SerializeField]
    private GameObject flyingTools;
    //弾の数
    [SerializeField]
    private int flyingToolsNum = 0;
    //弾の数MAX
    [SerializeField]
    private int flyingToolsNumMax = 5;
    //再攻撃の待つ時間
    [SerializeField]
    private float flyingToolsAttackTime = 1;
    //一発当たりの時間
    [SerializeField]
    private int flyingTimeMax = 5, flyingTime = 0;

    private void Start()
    {//初期化準備もし必要でしたら
    }
    /// <summary>
    //接近攻撃
    /// <param name="col"></param>
    private void OnCollisionStay(Collision col) //
    {
        if (col.gameObject.tag == "Player" && isApproachAttack)
        {
            GetComponent<MonsterSE>().MonsterSE1();   
            AttackMove(col);
            //もし何かを当たったらダメージを与える
            col.gameObject.GetComponent<GunnaerHealth>().MyHp = col.gameObject.GetComponent<GunnaerHealth>().MyHp - (int)GetComponent<MonsterInstinct>().myDamage;
            //このオブジェクトのHP＜0か
            col.gameObject.GetComponent<GunnaerHealth>().Isdie();
        }
        else if (col.gameObject.name == "Castle" && isApproachAttack)
        {
            AttackMove(col);
            col.gameObject.GetComponent<CastleScript>().MyHp = col.gameObject.GetComponent<CastleScript>().MyHp - (int)GetComponent<MonsterInstinct>().myDamage;
            col.gameObject.GetComponent<CastleScript>().IsOVER();

        }
        else if (col.gameObject.tag == "Machine" && isApproachAttack)
        {
            AttackMove(col);
            col.gameObject.GetComponent<MachineBatteryHealth>().MyHp -= (int)GetComponent<MonsterInstinct>().myDamage;
            col.gameObject.GetComponent<MachineBatteryHealth>().IsDIe();

        }
    }
    private void AttackMove(Collision collision)
    {
        //攻撃不可
        isApproachAttack = false;
        //転移不可
        GetComponent<MonsterInstinct>().isMove = false;
        ///ダメージ文字関係
        collision.transform.gameObject.GetComponent<TakeDamage>().Damage(collision);//ダメージ文字UI
        collision.transform.gameObject.GetComponent<TakeDamage>().DamageNum = (int)GetComponent<MonsterInstinct>().myDamage;
        //攻撃可になる、転移可
        Invoke("AttackPreparation", 1.0f);
    }
    //攻撃可になる、転移可
    private void AttackPreparation()
    {
        isApproachAttack = true;
        GetComponent<MonsterInstinct>().isMove = true;
    }
    /// 
    /// </summary>
    //遠距離攻撃------------------
    private void Update()
    {//
        ProcessAttackConControl();
    }
    

  
    //遠距離攻撃のターゲット
    private void ProcessAttackConControl()
    {//接近攻撃できる　ターゲットある　動ける　　遠距離攻撃できる　攻撃範囲内
        if (isApproachAttack&& GetComponent<MonsterInstinct>().processAttackTarget != null && GetComponent<MonsterInstinct>().isMove && isProcessAttack && (transform.position.x - GetComponent<MonsterInstinct>().processAttackTarget.transform.position.x) * (transform.position.x - GetComponent<MonsterInstinct>().processAttackTarget.transform.position.x) + (transform.position.z - GetComponent<MonsterInstinct>().processAttackTarget.transform.position.z) * (transform.position.z - GetComponent<MonsterInstinct>().processAttackTarget.transform.position.z) < GetComponent<MonsterInstinct>().r0 * GetComponent<MonsterInstinct>().r0 * 6)
        {
            if (flyingToolsNum < flyingToolsNumMax)
            {
                flyingTime++;
                if(flyingTime % flyingTimeMax == 0){
                    flyingToolsNum++;
                    transform.LookAt(GetComponent<MonsterInstinct>().processAttackTarget.transform);
                    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                    //ProcessAttack
                    GameObject newFlyingTools = Instantiate(flyingTools, transform.position, transform.rotation);
                    newFlyingTools.GetComponent<flyingToolsControl>().MyDamage = GetComponent<MonsterInstinct>().myDamage * processAttack;
                    newFlyingTools.GetComponent<flyingToolsControl>().MySeppt = processAttackSpeed;
                    newFlyingTools.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + Random.Range(-10, 10), 0);

                    newFlyingTools.transform.parent = GameObject.Find("BulleBOX").transform;//BulleBOXの子ともGameObjectであり


                    // Debug.Log("ProcessAttackConControl");
                }


            }
            else
            {
                GetComponent<MonsterInstinct>().processAttackTarget = null;
                isProcessAttack = false;
                Invoke("ProcessAttackPreparation", flyingToolsAttackTime);
              
            }
            //遠距離ターゲットに向き
               }
        //抑圧されたの処理
        else if (!GetComponent<MonsterInstinct>().isMove)
        {
           
        }
    }
    private void ProcessAttackPreparation()
    {
        isProcessAttack = true;
        flyingToolsNum = 0;
        //GetComponent<MonsterInstinct>().isMove = true;
    }
    //--------スキル？技？
    //加速

    //突撃

    //散形弾
    
    //ジャブ特性

    //
}