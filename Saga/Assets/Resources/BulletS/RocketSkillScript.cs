using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSkillScript : MonoBehaviour
{   //
    /*
    public class RocketProjectileBody {
        public GameObject rocketProjectileBodyGameObject;
        public GameObject newRocketProjectileBodyGameObject;
        public void RocketProjectileBodyStatr(){
            newRocketProjectileBodyGameObject = Instantiate(rocketProjectileBodyGameObject, this.transform.position, gunPos.transform.rotation);


        }

    }*/
    //
 //   public class RocketWarhead { }
    //この弾の速度
    public float MySeppt = 30.0f;
    //存在時間lifespan
    public float MyLifespan = 2;
    //ダメージ
    public float MyDamage = 30;
    public float RigidTime = 0.5f;
    public GameObject bommGameObject;
    TakeDamage takeDamage;//

    void Start()
    {
        //廃棄修理
        //Destroy(this.gameObject, MyLifespan);

    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * MySeppt, Space.Self);//弾の動き
    }


    //当たり判定OnCollisionEnter
    void OnCollisionEnter(Collision collisionInfo) //当进入碰撞器
    {
        Debug.Log("collisionInfo");
        Debug.Log(collisionInfo.gameObject.name);
    }
    //OnTriggerEnter
    void OnTriggerEnter(Collider col)
    {
        // Debug.Log(other.gameObject.name);
        if (col.gameObject.tag == "Monster")
        {


            if (col.GetComponent<MonsterInstinct>().rigidTime < RigidTime)
            {
                col.GetComponent<MonsterInstinct>().rigidTime = RigidTime;
            }
            //RigidTime
            col.GetComponent<MonsterInstinct>().myHp = col.GetComponent<MonsterInstinct>().myHp - MyDamage; //着弾されたもののHP判定
            col.gameObject.GetComponent<TakeDamage>().DamageNum = (int)MyDamage;
            col.transform.gameObject.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            col.GetComponent<MonsterInstinct>().Isdie();//
           BoomStart();
            // takeDamage.Damage(other);
            // Debug.Log(col.gameObject.tag);
        }
    }
    private void BoomStart()
    {
        GameObject instantiateBommGameObject = Instantiate(bommGameObject, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);  // 銃弾を崩壊
    }
    

}
