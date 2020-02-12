using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
   
    private float MyDamage = 500.0f;
    TakeDamage takeDamage;//
    void OnTriggerEnter(Collider col)
    {
        // Debug.Log(other.gameObject.name);
        if (col.gameObject.tag == "Monster")
        {
            Debug.Log("repulsionCol");
                col.GetComponent<MonsterInstinct>().rigidTime = 1.0f;
            //撃退
            //RigidTime
            col.GetComponent<MonsterInstinct>().myHp -= - MyDamage; //着弾されたもののHP判定
            col.gameObject.GetComponent<TakeDamage>().DamageNum = (int)MyDamage;
            col.transform.gameObject.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            //---------
            col.GetComponent<MonsterInstinct>().Isdie();//
            Repulsion repulsionCol = new Repulsion();
            repulsionCol.targetGameObject = col.gameObject;//撃退されるGameObject
            repulsionCol.formGameObject = this.gameObject;//撃退するGameObject
            repulsionCol.repulsionSpeed = 800;//撃退速度
            repulsionCol.repulsionMagnification = 10.0f;//撃退倍率
            repulsionCol.RepulsionMove(col);
        }
        if (col.gameObject.tag == "Gaound")
        {
            Destroy(this.gameObject);  // 銃弾を崩壊
        }
    }
}
