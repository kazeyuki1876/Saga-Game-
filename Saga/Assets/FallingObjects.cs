using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
   
    private float MyDamage = 500.0f;
    TakeDamage takeDamage;//
    private void Start()
    {
      
    }

    void OnTriggerEnter(Collider col)
    {
        // Debug.Log(other.gameObject.name);
        if (col.gameObject.tag == "Monster")
        {
            Debug.Log("repulsionCol");
                col.GetComponent<MonsterScript>().rigidTime = 1.0f;
            //撃退
            //RigidTime
            col.GetComponent<MonsterScript>().MyHP = col.GetComponent<MonsterScript>().MyHP - MyDamage; //着弾されたもののHP判定
            col.gameObject.GetComponent<TakeDamage>().DamageNum = (int)MyDamage;
            col.transform.gameObject.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            //---------
            col.GetComponent<MonsterScript>().Isdie();//
            Repulsion repulsionCol = new Repulsion();


            repulsionCol.targetGameObject = col.gameObject;//撃退されるGameObject
            repulsionCol.formGameObject = this.gameObject;//撃退するGameObject
            repulsionCol.repulsionSpeed = 500;//撃退速度
            repulsionCol.repulsionMagnification = 2.0f;//撃退倍率
            repulsionCol.RepulsionMove(col);
           
            /*
            Transform Target = col.gameObject.transform;//当たったもののPOｓ
            Rigidbody rb = col.GetComponent<Rigidbody>(); ;//当たったもののRigidbody
            //  GetComponent<Rigidbody>().velocity = transform.up * MySeppt;
            //transform.LookAt(Target);//撃退方向
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);//水平方向に撃退する
            rb.AddForce(transform.position + transform.forward * 10*MySeppt);//弾の方向に撃退する
            */
            Destroy(this.gameObject);  // 銃弾を崩壊

            // takeDamage.Damage(other);


            // Debug.Log(col.gameObject.tag);


        }
    }

    // Repulsion Repulsion;
}
