﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerMoveController : MonoBehaviour
{
    /// <summary>
    /// このスクリプトはキー入力だけと動きだけ
    /// </summary>
 
    [SerializeField] private float speed = 5;
    [SerializeField] private float shootingSupportSpeed = 1,shootingSupportSpeed0=0.7f;
    

   public float moveX = 0f;
  public  float moveZ = 0f;
    Rigidbody rb;
    public bool isGround;
    //周り速度
    [SerializeField] private float aroundSeppt = 5;
    [SerializeField]
    private float RotateSpeed = 0.2f;
    //----------狙えサポート aim
    public GameObject shouTingTarger;
    public bool isShootingSupport;　//今の狙えてるか
    private GameObject nearObj;         //最も近いオブジェクト
    private float searchTime = 0;    //経過時間       
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
    }//-----------//----------狙えサポート


    private void Start()
    {
        // 力を加える
        rb = GetComponent<Rigidbody>();


    }
   
    private void Update()
    {
        GunnerMOVE();//キー入力  //  FoundationMove();
    }
    void FixedUpdate()
    {//照準しょうじゅんサポート中　移動速度が下がり
        if (isShootingSupport)
        {
            shootingSupportSpeed = shootingSupportSpeed0;
        }
        else { shootingSupportSpeed = 1.0f; }

        if (isGround)
        {
            rb.velocity = new Vector3(moveX* shootingSupportSpeed, 0, moveZ* shootingSupportSpeed);

        }
        else {
            rb.velocity = new Vector3(moveX* shootingSupportSpeed, -5, moveZ* shootingSupportSpeed);
        }
    }
    void FoundationMove()
    {
        //ちゃんと押しているかどうか
        float x = Input.GetAxis("HorizontaPlayer_1");
        if (x < 0.5 && x > -0.5)
        {
            x = 0;
        }
        float y = Input.GetAxis("VerticalPlayer_1");
        if (y < 0.5 && y > -0.5)
        {
            y = 0;
        }
            moveX = x * speed;
            moveZ = y * -speed;
         Vector3 direction = new Vector3(moveX, 0, moveZ);
        //---顔むき　L2押し
        if (Input.GetKey("joystick 1 button 6"))
        {
            float KeyVertical = Input.GetAxis("Vertical2Player_1");
            float KeyHorizontal = Input.GetAxis("Horizontal2Player_1");
            Vector3 newDir = new Vector3(KeyHorizontal, 0, -KeyVertical).normalized;
            transform.forward = Vector3.Lerp(transform.forward, newDir, RotateSpeed);
            if (Input.GetKeyDown("joystick 1 button 11"))
            {
                Debug.Log("joystick");
                gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
            }
        }//---顔むき　isShootingSupport 射撃サポート
        else if (isShootingSupport)
        {
            //isShootingSupport 射撃サポート
            //経過時間を取得
            searchTime += Time.deltaTime;
            if (searchTime >= 0.3f)
            {
                //最も近かったオブジェクトを取得
                nearObj = serchTag(gameObject, "Monster");
                //経過時間を初期化
                searchTime = 0;
            }
            //もし　 射撃サポート　狙える　対象の位置の方向を向く
            if (nearObj != null)
            {
                transform.LookAt(nearObj.transform);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                shouTingTarger = nearObj;
            }
            else//　L2 推してない　　狙えるやつがない
            {
                Vector3 newDir = new Vector3(x, 0, y).normalized;
                transform.forward = Vector3.Lerp(transform.forward, newDir, RotateSpeed);
            }
        }
        else
        {
            Vector3 newDir = new Vector3(x, 0, -y).normalized;
            transform.forward = Vector3.Lerp(transform.forward, newDir, RotateSpeed);
        }
    }
    private void GunnerMOVE()
    {
        FoundationMove();
        //射撃R２
        if (Input.GetKey(KeyCode.Z) || Input.GetKey("joystick 1 button 7"))//
        {
            // Debug.Log("  if (Input.GetKey(KeyCode.Z))");
            this.GetComponent<GunnerShootingMoveController>().GunsMoveStart();
        }
        //建物の切り替え
        if (Input.GetKey("joystick 1 button 4") && Input.GetKeyDown("joystick 1 button 3"))
        {
            this.GetComponent<GunnerBatteryInstallationMove>().MachineBatteryNumChange();
        }
        //機械の設置　三角
        else if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown("joystick 1 button 3"))
        {
            this.GetComponent<GunnerBatteryInstallationMove>().instantiateBatteryInstallationMoveStart();
        }
        if (Input.GetKeyDown("joystick 1 button 1"))
        {
            this.GetComponent<GunnerBatteryInstallationMove>().MachineBatteryCancel();
        }
        //狙えるR3
        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown("joystick 1 button 11"))
        {
            if (isShootingSupport)
            {
                isShootingSupport = false;
            }
            else
            {
                isShootingSupport = true;
            }
        }
        //武器の切り替え R1+□（■しかく）
        if (Input.GetKey("joystick 1 button 4") && Input.GetKeyDown("joystick 1 button 0"))
        {
            this.GetComponent<GunnerShootingMoveController>().GunsChange();
        } //リロード　□
        else if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown("joystick 1 button 0"))
        {
            //   Debug.Log("V");
            this.GetComponent<GunnerShootingMoveController>().ReloadMoveStart();
        }
        //スキル変更　とスキル使用
        if (Input.GetKey("joystick 1 button 4") && Input.GetKeyDown("joystick 1 button 2"))
        {
            this.GetComponent<SkillScriot>().SkillChangeMove();
        } //リロード　□
        else if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown("joystick 1 button 2"))
        {
            //   Debug.Log("V");
            this.GetComponent<SkillScriot>().SkillMoveStart();
        }
        Spot();
    }
    void Spot()
    {
        if (transform.position.z > 8)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 7.9f);
        }
        if (transform.position.z < -28)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -27.9f);
        }
        if (transform.position.x < -24)
        {
            transform.position = new Vector3(-24, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 19)
        {
            transform.position = new Vector3(18.90f, transform.position.y, transform.position.z);
        }
       
       
    }
    void OnCollisionStay(Collision col) //当进入碰撞器
    {
        if (col.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }
    /*


    //--転移
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            transform.position += new Vector3(x * seppt, 0, y * seppt);
            if (Input.GetKeyDown("joystick button 10"))
            {
                gameObject.transform.position += Vector3.up * seppt;
            }

            //--向き
            float KeyVertical = Input.GetAxis("Vertical2");
            float KeyHorizontal = Input.GetAxis("Horizontal2");
            Vector3 newDir = new Vector3(KeyHorizontal, 0, KeyVertical).normalized;
            transform.forward = Vector3.Lerp(transform.forward, newDir, RotateSpeed);
            
            if (Input.GetKeyDown("joystick button 11"))
            {
                Debug.Log("joystick");
                gameObject.transform.Translate(Vector3.forward * Time.deltaTime * seppt, Space.Self);
            }
            */
    //------


}
