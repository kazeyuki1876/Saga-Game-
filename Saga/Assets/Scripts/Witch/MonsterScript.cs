using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public float MyHP;//HP
                      // public GameObject Player;
    public Transform Target;//モンスターの目標
    public float MySeppt = 10;//モンスターの速度
    public float MyDamage = 10;
    // Start is called before the first frame update
    void Start()
    {// Target = GameObject.Find("Player").transform.LookAt(Target);
      
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target);//目標をみる
        transform.Translate(Vector3.forward * Time.deltaTime * MySeppt, Space.Self);//見ている方向に進む
                                                                                    // transform.rotation(0，0，0);//見ている方向に進む
    }
    public void Isdie() {
        if (MyHP <= 0) {

         
            Destroy(this.gameObject);
        }

    }
    void OnCollisionEnter(Collision collisionInfo) //当进入碰撞器
    {
      //  Debug.Log("collisionInfo");
      //  Debug.Log(collisionInfo.gameObject.name);
        if (collisionInfo.gameObject.tag == "Player")
        {
          //  Debug.Log("碰撞_Enter_碰撞到的物体的名字是：" + collisionInfo.gameObject.name);
            collisionInfo.gameObject.GetComponent<PlayerScript>().MyHp = collisionInfo.gameObject.GetComponent<PlayerScript>().MyHp - MyDamage;


        }

        if (collisionInfo.gameObject.name == "Castle")
        {
            //  Debug.Log("碰撞_Enter_碰撞到的物体的名字是：" + collisionInfo.gameObject.name);
            collisionInfo.gameObject.GetComponent<CastleScript>().MyHp = collisionInfo.gameObject.GetComponent<CastleScript>().MyHp - (int)MyDamage;
            collisionInfo.gameObject.GetComponent<CastleScript>().IsOVER();
        }

    }
}
