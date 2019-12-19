﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSkill : MonoBehaviour
{
    [SerializeField]
    private float
        fireBallAmount=0,
        fireBallAmountMax=10,
        fireBallSpeed,
        fireBallDamage,
        fireBallScale;
    private bool isFireBallMove = false;
    public GameObject fireBallBoom;

    
    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 90);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFireBallMove) {

            transform.position = new Vector3(transform.position.x - fireBallSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
   public void FireBallSkillChargeMove() {
        fireBallAmount += Time.deltaTime*4.0f;
        if (fireBallAmount > fireBallAmountMax) {
            fireBallAmount = fireBallAmountMax;
        }
        fireBallScale = 1 + fireBallAmount / 4.0f;
        fireBallSpeed = 10 + fireBallAmount * 5.0f;
        fireBallDamage = 20 + fireBallAmount * 5.0f;
        transform.localScale = new Vector3(fireBallScale, fireBallScale, fireBallScale);
    }
    public void FireBallMoveStart() {
       
        isFireBallMove = true;
        Invoke("FireBallBommEnd", 0.5f +fireBallAmount/0.75f);
        Debug.Log("A2");
    }



    void OnTriggerEnter(Collider col) //当进入碰撞器
    {
        //  Debug.Log("collisionInfo");
        //  Debug.Log(collisionInfo.gameObject.name);
        if (col.gameObject.tag == "Machine"&& isFireBallMove)
        {
            col.gameObject.GetComponent<MachineBatteryHealth>().MyHp -= (int)fireBallDamage;
            col.gameObject.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            col.gameObject.GetComponent<TakeDamage>().DamageNum = (int)fireBallDamage;
            col.gameObject.GetComponent<MachineBatteryHealth>().IsDIe();
            FireBallBommEnd();
        }
        else if (col.gameObject.tag == "Player" && isFireBallMove)
        {
            col.gameObject.GetComponent<GunnaerHealth>().MyHp -= (int)fireBallDamage/2;
            col.gameObject.GetComponent<TakeDamage>().Damage(col);//ダメージ文字UI
            col.gameObject.GetComponent<TakeDamage>().DamageNum = (int)fireBallDamage/2;
          //  col.gameObject.GetComponent<GunnaerHealth>().IsDIe();
            FireBallBommEnd();
        }
    }
   public void FireBallBommEnd() {

        GameObject NewfireBallBoom = Instantiate(fireBallBoom, new Vector3(transform.position.x- fireBallAmount/2, transform.position.y+1, transform.position.z), this.transform.rotation);

        NewfireBallBoom.GetComponent<FireBallSkillBoom>().MyDamage= (int)fireBallAmount * 10;
      

        NewfireBallBoom.GetComponent<FireBallSkillBoom>().BoomMoveTimeMax = fireBallAmount * 0.3f;

        NewfireBallBoom.transform.localScale = new Vector3(fireBallScale, fireBallScale, fireBallScale);
        Destroy(this.gameObject);

    }
}
