using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public float MyHP;//HP
    public Transform StartTarget;
    public int MonsterHP = 0;
    public Transform Target;//モンスターの目標
    public float MySeppt = 10;//モンスターの速度
    public float MyDamage = 10;
    public int MonsterMagicStone = 0;
    // Start is called before the first frame update
    public bool isAttack = true;
    public GameObject MagicStone;

    bool isMove = true;
    TakeDamage takeDamage;//
    public float rigidTime=0;


    //-----
    
    float moveX = 0f;
    float moveZ = 0f;
    Rigidbody rb;

    //---
    void Start()
    {// Target = GameObject.Find("Player").transform.LookAt(Target);
        Target = StartTarget;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //以下の記述では一定速度で前に進む
        rb.MovePosition(transform.position + transform.forward * Time.deltaTime*MySeppt);

        //以下の記述ではteleportPointにワープ
        //rb.MovePosition(teleportPoint);
    }
    void Update()
    {
        if (rigidTime > 0)
        {
            rigidTime -= Time.deltaTime;
        }
        else {
            if (Target == null && isMove)
            {
                Target = StartTarget;
            }
            if (isAttack)
            {
                transform.LookAt(Target);//目標をみる
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
              //  Debug.Log(transform.eulerAngles);
                // transform.Translate(Vector3.forward * Time.deltaTime * MySeppt, Space.Self);//見ている方向に進む
                //GetComponent<Rigidbody>().velocity = transform. * MySeppt;
                //     transform.rotation(0，0，0);//見ている方向に進む

            }
        }
        
          transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
      
    }
    public void Isdie()
    {
        if (MyHP <= 0)
        {
            for (int i = 0; i < MonsterMagicStone; i++)
            { 
                MagicStone = Instantiate(MagicStone, new Vector3(transform.position.x + Random.Range(-2.0f, 2.0f), transform.position.y, transform.position.z + Random.Range(-1.0f, 1.0f)), transform.rotation);
                MagicStone.transform.parent = GameObject.Find("MagicStoneBOX").transform;//MagicStoneBOXの子ともGameObjectであり
            }

            Destroy(this.gameObject, 0.1f);
        }

    }
    void OnCollisionStay(Collision col) //当进入碰撞器
    {

        //  Debug.Log("collisionInfo");
        //  Debug.Log(collisionInfo.gameObject.name);
        if (col.gameObject.tag == "Player" && isAttack)
        {
            isAttack = false;
            isMove = false;
            //  Debug.Log("碰撞_Enter_碰撞到的物体的名字是：" + collisionInfo.gameObject.name);

            col.gameObject.GetComponent<GunnaerHealth>().MyHp = col.gameObject.GetComponent<GunnaerHealth>().MyHp - MyDamage;
            col.transform.root.GetComponent<TakeDamage>().DamageNum = (int)MyDamage;
            col.transform.root.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            col.gameObject.GetComponent<GunnaerHealth>().Isdie();


            Invoke("ATKok", 1.0f);
        }
        else if (col.gameObject.name == "Castle" && isAttack)
        {
            isAttack = false;
            isMove = false;
            //  Debug.Log("碰撞_Enter_碰撞到的物体的名字是：" + collisionInfo.gameObject.name);
            col.gameObject.GetComponent<CastleScript>().MyHp = col.gameObject.GetComponent<CastleScript>().MyHp - (int)MyDamage;
            col.transform.root.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            col.transform.root.GetComponent<TakeDamage>().DamageNum = (int)MyDamage;
            col.gameObject.GetComponent<CastleScript>().IsOVER();

            Invoke("ATKok", 1.0f);
        }else if (col.gameObject.tag == "Machine" && isAttack)
        {
            isAttack = false;
            isMove = false;
            col.gameObject.GetComponent<MachineBatteryHealth>().MyHp -= (int)MyDamage;
            col.gameObject.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            col.gameObject.GetComponent<TakeDamage>().DamageNum = (int)MyDamage;
            col.gameObject.GetComponent<MachineBatteryHealth>().IsDIe();

            Invoke("ATKok", 1.0f);
        }

    }
    void OnCollisionExet(Collision col) //当进入碰撞器
    {

        if (col.gameObject.name == "testbaru" & col.gameObject.name == "Castle" && col.gameObject.name == "testbaru")
        {
            isMove = true;
        }
    }
    void AttackPreparation()
    {
        isAttack = true;
    }
}
