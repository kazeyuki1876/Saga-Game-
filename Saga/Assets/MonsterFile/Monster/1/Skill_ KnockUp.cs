using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_KnockUp : Skill_FoundationScript
{
    //------------
    //
    //攻撃を止める
    //時間内その方向の突撃
    //もの当ったり
    //時間切
    //処理
    public float knockUpSkillTime0 = 2.0f;
    public float knockUpSkillTime = 0;
    public float knockUpSpeed = 10;
    private  Rigidbody rb;
    public GameObject[] knockUpParticleSystem = new GameObject[2];
    public void KnockUpStart(){
        // ターゲットを獲得
        if (isSkillStart&&my.GetComponent<MonsterInstinct>().target!=null && my.GetComponent<MonsterInstinct>().name != "Castle") {
            Debug.Log("KnockUpStart");
            isSkillStart = false;
            //動きを止める
            my.GetComponent<MonsterInstinct>().isMove = false;
            my.GetComponent<MonsterAttack>().isApproachAttack= false;
            my.GetComponent<MonsterAttack>().isProcessAttack = false;
            //スキルタイム
            knockUpSkillTime = knockUpSkillTime0;
            //クルータイム
            //方向獲得
            my.transform.LookAt(my.GetComponent<MonsterInstinct>().target);
            //水平で動く
            my.transform.eulerAngles = new Vector3(0, my.transform.eulerAngles.y, 0);
            rb=my.gameObject.GetComponent<Rigidbody>();
        }
    }
    //FixedUpdate
  public  void KnockUpMove() {
        if (knockUpSkillTime>0) {
            knockUpParticleSystem[0].SetActive(true);
            knockUpParticleSystem[1].SetActive(true);
            Debug.Log("KnockUpMove");
            rb.MovePosition(my.transform.position + my.transform.forward * Time.deltaTime * knockUpSpeed);
            knockUpSkillTime -= Time.deltaTime;
            if (knockUpSkillTime <= 0) {
             
                KnockUpMoveEnd();
                //Spot処理
            }
        }
        SkillCooling();
    }
    public void KnockUpMoveEnd() {
        knockUpSkillTime = 0;
        knockUpParticleSystem[0].SetActive(false);
        knockUpParticleSystem[1].SetActive(false);
        my.GetComponent<MonsterInstinct>().isMove = true;
        my.GetComponent<MonsterAttack>().isApproachAttack = true;
        my.GetComponent<MonsterAttack>().isProcessAttack = true;
    }









}
