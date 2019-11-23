using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public float MyHP;//HP
                      // public GameObject Player;
    public Transform StartTarget;
        
        public Transform Target;//モンスターの目標
    public float MySeppt = 10;//モンスターの速度
    public float MyDamage = 10;
    // Start is called before the first frame update
    public bool IsATK = true;
      TakeDamage takeDamage;//
    void Start()
    {// Target = GameObject.Find("Player").transform.LookAt(Target);
        Target = StartTarget;


    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null) {
            Target = StartTarget;
        }
        transform.LookAt(Target);//目標をみる
        transform.Translate(Vector3.forward * Time.deltaTime * MySeppt, Space.Self);//見ている方向に進む
                                                                                    // transform.rotation(0，0，0);//見ている方向に進む
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        if (transform.position.y > 4.7f) {
           transform.position = new Vector3(transform.position.x, 4.6f, transform.position.z);   }
    }
    public void Isdie() {
        if (MyHP <= 0) {

         
            Destroy(this.gameObject,0.1f);
        }

    }
    void OnCollisionStay(Collision col) //当进入碰撞器
    {
       
      //  Debug.Log("collisionInfo");
      //  Debug.Log(collisionInfo.gameObject.name);
        if (col.gameObject.tag == "Player"&& IsATK)
        {
            IsATK = false;
            //  Debug.Log("碰撞_Enter_碰撞到的物体的名字是：" + collisionInfo.gameObject.name);

            col.gameObject.GetComponent<PlayerScript>().MyHp = col.gameObject.GetComponent<PlayerScript>().MyHp - MyDamage;
            col.transform.root.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            col.transform.root.GetComponent<TakeDamage>().DamageNum = (int)MyDamage;


            Invoke("ATKok", 1.0f);
        }

        if (col.gameObject.name == "Castle"&& IsATK)
        {
            IsATK = false;
            //  Debug.Log("碰撞_Enter_碰撞到的物体的名字是：" + collisionInfo.gameObject.name);
            col.gameObject.GetComponent<CastleScript>().MyHp = col.gameObject.GetComponent<CastleScript>().MyHp - (int)MyDamage;
            col.transform.root.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            col.transform.root.GetComponent<TakeDamage>().DamageNum = (int)MyDamage;
            col.gameObject.GetComponent<CastleScript>().IsOVER();
          
            Invoke("ATKok", 1.0f);
        }

        if (col.gameObject.name== "testbaru" && IsATK) {
            IsATK = false;
            col.gameObject.GetComponent<ststberuhontai>().MyHp = col.gameObject.GetComponent<ststberuhontai>().MyHp - (int)MyDamage;
            col.transform.root.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            col.transform.root.GetComponent<TakeDamage>().DamageNum = (int)MyDamage;
            col.gameObject.GetComponent<ststberuhontai>().IsDIe();

            Invoke("ATKok", 1.0f);
        }

    }
    void ATKok() {
        IsATK = true;
    }
}
