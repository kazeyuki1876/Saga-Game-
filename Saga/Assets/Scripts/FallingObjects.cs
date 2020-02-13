using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
 public  GameObject my;

    TakeDamage takeDamage;//
    private void Start()
    {
        my = this.gameObject;
    }
    private void Update()
    {
       if (my.transform.position.y < 7)
        {
            Destroy(gameObject);  // 銃弾を崩壊
        }
    }
    void OnTriggerStay(Collider col)
    {

        // Debug.Log(other.gameObject.name);
        if (col.gameObject.tag == "Gaound")
        {
            Debug.Log(col.gameObject.tag);
            Destroy(my);  // 銃弾を崩壊
        }
        else if (col.gameObject.tag == "Monster")
        {
            col.GetComponent<MonsterInstinct>().myHp -= 100; //着弾されたもののHP判定
            col.gameObject.GetComponent<TakeDamage>().DamageNum = 100;
            col.transform.gameObject.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            Debug.Log("repulsionCol");
            col.GetComponent<MonsterInstinct>().rigidTime = 1.0f;
            //撃退
            //RigidTime

            //  col.transform.gameObject.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI

            //---------
            col.GetComponent<MonsterInstinct>().Isdie();//
            Repulsion repulsionCol = new Repulsion();
            repulsionCol.targetGameObject = col.gameObject;//撃退されるGameObject
            repulsionCol.formGameObject = this.gameObject;//撃退するGameObject
            repulsionCol.repulsionSpeed = 800;//撃退速度
            repulsionCol.repulsionMagnification = 10.0f;//撃退倍率
            repulsionCol.RepulsionMove(col);
        }


    }


}
