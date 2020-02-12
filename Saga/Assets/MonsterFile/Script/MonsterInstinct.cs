using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInstinct : MonoBehaviour
{
    //HP
    public float myHp;
    //転移速度
    public float mySpeed;
    //攻撃力
    public float myDamage;
    //
    public float myDefense;
    private GameObject player;

    private GameObject castle;
    public float r0 = 5.0f;//半径  r0*r0 //索敵範囲
    //最終目標
    public Transform startTarget;
    //もし何か会ったらそのもの目標にする
    public Transform target;
    //遠距離攻撃target
    public Transform processAttackTarget;
    public GameObject processAttackTargetGameObject;
    public float processAttackTargetGameObjectPos;
    //落ちる魔石
    public GameObject magicStoneGameObject;
    //落ちる魔石no数
    public int myMagicStoneNum;
    //スタンタイム
    public float rigidTime = 0;
    ////(1-7);スタン恢復速度　8は免疫
    public float rigidResistance = 1;
    //動けるか
    public bool isMove = true;

    //モンスターのRigidbody
    Rigidbody rb;
    //ダメージUI
    TakeDamage takeDamage;//

    //地面にいるか
    private bool isGround;

    //----------狙えサポート aim
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
    public void Start()
    {
        target = startTarget;
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Gunner");
        castle = GameObject.Find("Castle");
    }
    //以下の記述では一定速度と顔向き方向に進む
    void FixedUpdate()
    {//進む
        if (rigidTime <= 0 && isMove && isGround)
        {
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * mySpeed);
        }
        else if (!isGround)
        {

            rb.velocity = new Vector3(0, -5, 0);
        }


    }
    void Update()
    {    //スタン 免疫
        if (rigidResistance >= 8)
        {
            rigidTime = 0;

        }
        //もしスタン
        if (rigidTime > 0)
        {
            Debug.Log("//もしスタン");
            if (rigidResistance <= 0) { rigidResistance = 1; }
            rigidTime -= Time.deltaTime * rigidResistance;

            isMove = false;
            if (rigidTime <= 0)
            {
                rigidTime = 0;
                isMove = true;
            }
        }
        // スタンではない
        else if (isMove && isGround)
        {
            ProcessAttackTargetControl();
            TargetControl();
            //ターゲットがないの処理
            if (target != null && isMove)
            {
                //目標をみる
                transform.LookAt(target);
                //水平で動く
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            }
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
    //死ぬ
    public void Isdie()
    {
        if (myHp <= 0)
        {
            for (int i = 0; i < myMagicStoneNum; i++)
            {
                magicStoneGameObject = Instantiate(magicStoneGameObject, new Vector3(transform.position.x + Random.Range(-2.0f, 2.0f), transform.position.y, transform.position.z + Random.Range(-1.0f, 1.0f)), transform.rotation);
                magicStoneGameObject.transform.parent = GameObject.Find("MagicStoneBOX").transform;//MagicStoneBOXの子ともGameObjectであり
            }

            Destroy(this.gameObject, 0.1f);
        }
    }
    void TargetControl()
    {



        //城に辿り付けない
        //  if (target != castle.transform)
        if (target == null)
        {
            if ((gameObject.transform.position.x - player.transform.position.x) * (gameObject.transform.position.x - player.transform.position.x) + (gameObject.transform.position.z - player.transform.position.z) * (gameObject.transform.position.z - player.transform.position.z) <= (r0 + 1) * (r0 + 1))
            {
                target = player.transform;

                //城に近き
            }
            else if ((gameObject.transform.position.x - castle.transform.position.x) * (gameObject.transform.position.x - castle.transform.position.x) + (gameObject.transform.position.z - castle.transform.position.z) * (gameObject.transform.position.z - castle.transform.position.z) / 20 <= r0 * r0)
            {
                target = castle.transform;
            }
            else if (transform.position.x < -25.0f)
            {
                target = castle.transform;
            }
            //もしPlayer が離れよう

        }
        if (target != null && (gameObject.transform.position.x - target.transform.position.x) * (gameObject.transform.position.x - target.transform.position.x) + (gameObject.transform.position.z - target.transform.position.z) * (gameObject.transform.position.z - target.transform.position.z) >= (r0 * 5) * (r0 * 5))
        {
            // Debug.Log(target.name + "が離れ");
            target = null;
        }
        else if (target == null)//誰でも近きない
        {
            transform.eulerAngles = new Vector3(0, -90, 0);
        }
    }

    void ProcessAttackTargetControl()
    {
        if (target != null)
        {
            processAttackTarget = target;
        }
        else if (processAttackTargetGameObject != null && (gameObject.transform.position.x - processAttackTargetGameObject.transform.position.x) * (gameObject.transform.position.x - processAttackTargetGameObject.transform.position.x) + (gameObject.transform.position.z - processAttackTargetGameObject.transform.position.z) * (gameObject.transform.position.z - processAttackTargetGameObject.transform.position.z) >= (r0 * 4) * (r0 * 4))
        {
            processAttackTargetGameObjectPos = (gameObject.transform.position.x - processAttackTargetGameObject.transform.position.x) * (gameObject.transform.position.x - processAttackTargetGameObject.transform.position.x) + (gameObject.transform.position.z - processAttackTargetGameObject.transform.position.z) * (gameObject.transform.position.z - processAttackTargetGameObject.transform.position.z);
            processAttackTarget = processAttackTargetGameObject.transform;
        }
        else if (target == null & processAttackTarget == null)
        {
            //  Debug.Log("ProcessAttackConControl");
            //経過時間を取得
            searchTime += Time.deltaTime;
            if (searchTime >= 0.3f)
            {
                //最も近かったオブジェクトを取得
                nearObj = serchTag(gameObject, "Machine");
                //経過時間を初期化
               processAttackTargetGameObject = nearObj;
                if (processAttackTargetGameObject != null &&
                    nearObj.transform.position.x > this.transform.position.x - r0 && nearObj.transform.position.x < this.transform.position.x + r0&&
                    nearObj.transform.position.y > this.transform.position.y - r0 && nearObj.transform.position.y < this.transform.position.y + r0


                    )
                {
                    target = processAttackTargetGameObject.transform;
                }
              
                searchTime = 0;
            }
            //もし　 射撃サポート　狙える　対象の位置の方向を向く

        }
    }
}
