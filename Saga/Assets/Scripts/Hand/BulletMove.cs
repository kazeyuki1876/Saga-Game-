using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BulletMove : MonoBehaviour
{
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


    //当たり判定OnCollisionEnter
    void OnCollisionEnter(Collision collisionInfo) //当进入碰撞器
    {
        Debug.Log("collisionInfo" );
        Debug.Log(collisionInfo.gameObject.name);
    }
    //OnTriggerEnter
    void OnTriggerEnter(Collider col)
    {
      
       // Debug.Log(other.gameObject.name);
        if (col.gameObject.tag == "Monster")
        {

            Destroy(this.gameObject);  // 銃弾を崩壊
            col.GetComponent<MonsterScript>().MyHP= col.GetComponent<MonsterScript>().MyHP - MyDamage; //着弾されたもののHP判定
         
            col.transform.root.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            col.transform.root.GetComponent<TakeDamage>().DamageNum = (int)MyDamage;
           
            col.GetComponent<MonsterScript>().Isdie();//
            //

            // takeDamage.Damage(other);


            // Debug.Log(col.gameObject.tag);


        }
    }
}
