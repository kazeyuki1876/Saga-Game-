using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newmon : MonoBehaviour
{
    //HP
    public float myHp;
    //転移速度
    public float mySpeed;
    //攻撃力
    public float myDamage;
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
    bool isMove = true;
    //攻撃できるか
    public bool isATK = true;
    //モンスターのRigidbody
    Rigidbody rb;
    //ダメージUI
    TakeDamage takeDamage;//
    void Start() {
        target = startTarget;

        rb = GetComponent<Rigidbody>();
    }
    //以下の記述では一定速度と顔向き方向に進む
    void FixedUpdate()
    {
        if (rigidTime > 0 && isMove)
        {
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * mySpeed);
        }
    }
    void Update()
    {
        //もしスタン
        if (rigidTime > 0)
        {
            rigidTime -= Time.deltaTime;
        }
        // スタンではない
        else
        {
            //ターゲットがないの処理
            if (target == null && isMove)
            {
                target = startTarget;
            }
            //目標をみる
            transform.LookAt(target);
        }
        //水平で動く
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    void OnCollisionStay(Collision col) //当进入碰撞器
    {
        if (col.gameObject.tag == "Player" && isATK)
        {
            AttackMove(col);
            col.gameObject.GetComponent<GunnaerHealth>().MyHp = col.gameObject.GetComponent<GunnaerHealth>().MyHp - myDamage;
            col.gameObject.GetComponent<GunnaerHealth>().Isdie();
        }
        else if (col.gameObject.name == "Castle" && isATK)
        {
            AttackMove(col);
            col.gameObject.GetComponent<CastleScript>().MyHp = col.gameObject.GetComponent<CastleScript>().MyHp - (int)myDamage;
            col.gameObject.GetComponent<CastleScript>().IsOVER();
        }
        else if (col.gameObject.tag == "Machine" && isATK)
        {
            AttackMove(col);
            col.gameObject.GetComponent<MachineBatteryHealth>().MyHp -= (int)myDamage;
            col.gameObject.GetComponent<MachineBatteryHealth>().IsDIe();
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
    void AttackMove(Collision collision) {
        isATK = false;
        isMove = false;
        collision.transform.root.GetComponent<TakeDamage>().Damage(collision);//ダメージ文字UI
        collision.transform.root.GetComponent<TakeDamage>().DamageNum = (int)myDamage;
        Invoke("ATKok", 1.0f);
    }
}
