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
    public GameObject player;
    public GameObject castle;
    private float r0 = 5.0f;//半径  r0*r0 //索敵範囲

    //最終目標
    public Transform startTarget;
    //もし何か会ったらそのもの目標にする
    public Transform target;
    //落ちる魔石
    public GameObject magicStoneGameObject;
    //落ちる魔石no数
    public int myMagicStoneNum;
    //スタンタイム
    public float rigidTime = 0;
    //動けるか
    public bool isMove = true;
    //攻撃できるか
    public bool isAttack = true;
    //モンスターのRigidbody
    Rigidbody rb;
    //ダメージUI
    TakeDamage takeDamage;//
    //地面にいるか
    private bool isGround;
    public void Start()
    {

        target = startTarget;
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Gunner");
        castle = GameObject.Find("Castle");
       

    }
    //以下の記述では一定速度と顔向き方向に進む
    void FixedUpdate()
    {
        if (rigidTime <= 0 && isMove && isGround)
        {
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * mySpeed);
        }
    }
    void Update()
    {
       TargetControl();

        //もしスタン
        if (rigidTime > 0)
        {
            rigidTime -= Time.deltaTime;
            if (rigidTime < 0) {
                rigidTime = 0;
            }
        }
        // スタンではない
        else
        {
            //ターゲットがないの処理
            if (target != null && isMove)
            {
             
                transform.LookAt(target);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            }
        }
            //目標をみる
         
        //水平で動く
       
    }

    void OnCollisionStay(Collision col) //当进入碰撞器
    {
        if (col.gameObject.tag == "Player" && isAttack)
        {
            AttackMove(col);
            col.gameObject.GetComponent<GunnaerHealth>().MyHp = col.gameObject.GetComponent<GunnaerHealth>().MyHp - myDamage;
            col.gameObject.GetComponent<GunnaerHealth>().Isdie();
        }
        else if (col.gameObject.name == "Castle" && isAttack)
        {

            col.gameObject.GetComponent<CastleScript>().MyHp = col.gameObject.GetComponent<CastleScript>().MyHp - (int)myDamage;
            col.gameObject.GetComponent<CastleScript>().IsOVER();
            AttackMove(col);
        }
        else if (col.gameObject.tag == "Machine" && isAttack)
        {

            col.gameObject.GetComponent<MachineBatteryHealth>().MyHp -= (int)myDamage;
            col.gameObject.GetComponent<MachineBatteryHealth>().IsDIe();
            AttackMove(col);
        }
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
    void AttackMove(Collision collision)
    {
        isAttack = false;
        isMove = false;
        collision.transform.gameObject.GetComponent<TakeDamage>().Damage(collision);//ダメージ文字UI
        collision.transform.gameObject.GetComponent<TakeDamage>().DamageNum = (int)myDamage;
        Invoke("AttackPreparation", 1.0f);
    }
    void AttackPreparation()
    {
        isAttack = true;
        isMove = true;
    }

    void TargetControl()
    {
        //城に辿り付けない
        if (target != castle.transform)
        {  //城に近き
            if ((gameObject.transform.position.x - castle.transform.position.x) * (gameObject.transform.position.x - castle.transform.position.x) + (gameObject.transform.position.z - castle.transform.position.z) * (gameObject.transform.position.z - castle.transform.position.z) / 20 <= r0 * r0)
            {
              
                target = castle.transform;
            }//playerに近き
            else if ((gameObject.transform.position.x - player.transform.position.x) * (gameObject.transform.position.x - player.transform.position.x) + (gameObject.transform.position.z - player.transform.position.z) * (gameObject.transform.position.z - player.transform.position.z) <= r0 * r0)
            {
              
                target = player.transform;
            }//誰でも近きない
            if (target == null)
            {
                transform.eulerAngles = new Vector3(0, -90, 0);
            }
        }
        //
        

    }

}
