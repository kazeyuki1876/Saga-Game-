﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingToolsControl : MonoBehaviour
{
  
    public class Repulsion
    {
        public GameObject targetGameObject;//撃退されるGameObject
        public GameObject formGameObject;//撃退するGameObject
        public float repulsionSpeed;//撃退速度
        public float repulsionMagnification = 1.0f;//撃退倍率
        public void RepulsionMove()
        {
            Transform Target = targetGameObject.transform;//当たったもののPOｓ
            Rigidbody rb = targetGameObject.GetComponent<Rigidbody>(); ;//当たったもののRigidbody
            //  GetComponent<Rigidbody>().velocity = transform.up * MySeppt;
            //transform.LookAt(Target);//撃退方向
            formGameObject.transform.eulerAngles = new Vector3(0, formGameObject.transform.eulerAngles.y, 0);//水平方向に撃退する
            rb.AddForce(formGameObject.transform.position + formGameObject.transform.forward * repulsionMagnification * repulsionSpeed);//弾の方向に撃退する
        }
    }



    //この弾の速度
    public float MySeppt = 10.0f;
    //存在時間lifespan
    public float MyLifespan = 1;
    //ダメージ
    public float MyDamage = 1;
    TakeDamage takeDamage;//

    void Start()
    {
        //廃棄修理
        Destroy(this.gameObject, MyLifespan);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * MySeppt, Space.Self);//弾の動き
    }
    //OnTriggerEnter
    void OnTriggerEnter(Collider col)
    {
        // Debug.Log(other.gameObject.name);
        if (col.gameObject.tag == "Player")
        {
            //  Debug.Log("???");
            //撃退
            //RigidTime
            col.GetComponent<GunnaerHealth>().MyHp = col.GetComponent<GunnaerHealth>().MyHp - MyDamage; //着弾されたもののHP判定
            col.gameObject.GetComponent<TakeDamage>().DamageNum = (int)MyDamage;
            col.transform.gameObject.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            col.GetComponent<GunnaerHealth>().Isdie();//

            Repulsion NewRepulsion = new Repulsion();
            NewRepulsion.targetGameObject = col.gameObject;//撃退されるGameObject
            NewRepulsion.formGameObject = this.gameObject;//撃退するGameObject
            NewRepulsion.repulsionSpeed = MySeppt * 5;//撃退速度
            NewRepulsion.repulsionMagnification = 2.0f;//撃退倍率
            NewRepulsion.RepulsionMove();
            Destroy(this.gameObject);  // 銃弾を崩壊
        }
        if (col.gameObject.tag == "Machine")
        {
            col.GetComponent<MachineBatteryHealth>().MyHp -= (int)MyDamage; //着弾されたもののHP判定
            col.gameObject.GetComponent<TakeDamage>().DamageNum = (int)MyDamage;
            col.transform.gameObject.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            col.GetComponent<MachineBatteryHealth>().IsDIe();
            Destroy(this.gameObject);  // 銃弾を崩壊
        }
    }
    
}