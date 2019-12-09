﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBatteryScript : MonoBehaviour
{
    // Start is called before the first frame update
 
    public float MyLifespan;
    public float MyDamage;
    public float MyShootingSpeed;
    public GameObject Bullet;
    public GameObject Bullets;
    public bool IsShooting = true;
    //--------------------
    private GameObject nearObj;         //最も近いオブジェクト
    private float searchTime = 0;    //経過時間

    //------------- 
    public GameObject Cate; //回ろ
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト
        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;
    }//-----------

     void Update()
    {
        ShootingSupport(); }
    public float A;
    public bool isMOve = true;
    void ShootingSupport()
    {//IsShootingSupport 射撃サポート
     //経過時間を取得

        searchTime += Time.deltaTime;

        if (searchTime >= 1.0f)
        {
            //最も近かったオブジェクトを取得
            nearObj = serchTag(gameObject, "Monster");

            //経過時間を初期化
            searchTime = 0;
        }
       float R = 0;
        float RMAX = 90;
       

        //対象の位置の方向を向く
        if(nearObj!=null&& isMOve)
        if (nearObj.transform.position.x > this.transform.position.x - 30.0f && nearObj.transform.position.x < this.transform.position.x + 30.0f) {
            transform.LookAt(nearObj.transform);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            Shooting();
                //   R = R + 360 * Time.deltaTime;
                //   A = R % RMAX;
                if (A <= 360)
                {
                    A = A + 720 * Time.deltaTime;
                    Cate.transform.eulerAngles = new Vector3(A, transform.eulerAngles.y, 0);
                }
                else { Cate.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0); }
              

             
            }

        //自分自身の位置から相対的に移動する
        //transform.Translate(Vector3.forward * 0.01f);
    }

    void Shooting() {
        if (IsShooting) {
            IsShooting = false;
            isMOve = false;
            A = 0;
            GunsMOVE();
            Invoke("IsMoveON", 0.5f);
            Invoke("ShootingON",1.1f);

        }

    }
    void ShootingON(){

        IsShooting = true;
    }
    void IsMoveON() {
        isMOve = true;
        A = 0;
    }
    void GunsMOVE()
    {
      
        //　いまＰＬＡＹＥＲが持っている銃

        //銃弾あるか

        //銃が撃つときの火花

        //銃が撃つときの音

        //銃によっての弾
        // string BulletName = Bullets[0].name;
        Bullet = Instantiate(Bullets, this.transform.position, this.transform.rotation);//弾丸を作り　位置と向きを与える
        Bullet.transform.parent = GameObject.Find("BulleBOX").transform;//BulleBOXの子ともGameObjectであり
        Bullet.GetComponent<BulletMove>().MySeppt = 150;
        Bullet.GetComponent<BulletMove>().MyLifespan = 2;
        Bullet.GetComponent<BulletMove>().MyDamage = 1;
        
        //残弾量計算
    }


    //atk 
    // HP
    //die

}
