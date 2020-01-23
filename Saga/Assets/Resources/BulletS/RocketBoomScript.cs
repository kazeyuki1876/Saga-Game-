using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBoomScript : MonoBehaviour
{
    public float MyLifespan = 2;
    //ダメージ
    public float MyDamage = 20;

    public float RigidTime = 0.1f;

    public float BoomMoveTimeMax = 2.0f;

    public float BoomMoveTime = 0;

    public float BoomMoveTiming = 0;

    public float BoomMoveSpeed = 0.2f;

    public bool isBoomMoveTiming = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 5.0f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (BoomMoveTime < BoomMoveTimeMax)
        {


            BoomMoveTime += Time.deltaTime;
            if (BoomMoveTime > BoomMoveTiming)
            {
                isBoomMoveTiming = true;
                BoomMoveTiming += BoomMoveSpeed;
               
                if (MyDamage > 10) {
                    MyDamage -= 5;
                }
            }
            else
            {
                isBoomMoveTiming = false;
            }

        }
        else {
            Destroy(this.gameObject);  // 銃弾を崩壊
        }
    }
    void OnTriggerStay(Collider col)
    {
        // Debug.Log(other.gameObject.name);
        if (col.gameObject.tag == "Monster"&& isBoomMoveTiming)
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
         
            // takeDamage.Damage(other);
            // Debug.Log(col.gameObject.tag);
        }
    }
}
