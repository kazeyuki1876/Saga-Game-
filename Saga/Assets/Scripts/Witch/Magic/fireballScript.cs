using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballScript : MonoBehaviour
{//カード　
    public float Speed=100;
    public float myDamage = 500;
    TakeDamage TakeDamage;
    public GameObject  Boom;
    // Start is called before the first frame update
    public void Update()
    {
    //    Debug.Log(Random.Range(-1.0f, 2.0f));
        transform.position = new Vector3(transform.position.x- Speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
    void OnTriggerEnter(Collider col) //当进入碰撞器
    {
        //  Debug.Log("collisionInfo");
        //  Debug.Log(collisionInfo.gameObject.name);
        if (col.gameObject.tag == "Machine")
        {
            col.gameObject.GetComponent<TakeDamage>().DamageNum = (int)myDamage;
            col.gameObject.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            col.gameObject.GetComponent<MachineBatteryHealth>().MyHp -= (int)myDamage;
            col.gameObject.GetComponent<MachineBatteryHealth>().IsDIe();
            GameObject NewfireBallBoom = Instantiate(Boom, new Vector3(transform.position.x - Random.Range(-2.0f,4.0f), transform.position.y + Random.Range(-1.5f,3.0f), transform.position.z + Random.Range(-0.5f, 2.0f)), this.transform.rotation);

            Destroy(this.gameObject);  // 銃弾を崩壊
        }

    }
}
