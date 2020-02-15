using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSkillBoom : MonoBehaviour
{
    public float MyLifespan = 2;
    //ダメージ
    public float MyDamage = 20;

    public float BoomMoveTimeMax = 2.0f;
    public float BoomMoveTime = 0;

    public float BoomMoveTiming = 0;
    public float BoomMoveSpeed = 0.1f;

    public bool isBoomMoveTiming = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
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

                if (MyDamage > 10)
                {
                    MyDamage =(int) MyDamage*0.7f;
                }
            }
            else
            {
                isBoomMoveTiming = false;
            }

        }
        else
        {
            Destroy(this.gameObject);  // 銃弾を崩壊
        }
    }
    void OnTriggerStay(Collider col)
    {
        // Debug.Log(other.gameObject.name);
        if (col.gameObject.tag == "Machine" && isBoomMoveTiming)
        {
            col.gameObject.GetComponent<MachineBatteryHealth>().MyHp -= (int)MyDamage;
            col.gameObject.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            col.gameObject.GetComponent<TakeDamage>().DamageNum = (int)MyDamage;
            col.gameObject.GetComponent<MachineBatteryHealth>().IsDIe();

        }
        else if (col.gameObject.tag == "Player" && isBoomMoveTiming)
        {

            col.gameObject.GetComponent<GunnaerHealth>().MyHp -= (int)MyDamage;
            col.gameObject.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            col.gameObject.GetComponent<TakeDamage>().DamageNum = (int)MyDamage;
            col.gameObject.GetComponent<GunnaerHealth>().Isdie();

        }
    }
}
