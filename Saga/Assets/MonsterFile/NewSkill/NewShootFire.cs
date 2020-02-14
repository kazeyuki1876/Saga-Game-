using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewShootFire : NewSkill_AbilityUp
{/// <summary>
 /// shoot fire　炎の吹息（いぶき）
 /// このスクリプトはモンスターの能力をアップする発動タイミング　コントローラー
 /// </summary>
    private Transform shootFireTarget;
    public GameObject flyingTools;
    //炎の吹息中
    public bool israteOfFireMove;
    public int rateOfFire;  //1s=250;
    public int rateOfFireMin, rateOfFireMax;
    public int rateOfFireNum;
    public int rateOfFireArcDegree;
    public ParticleSystem energyReserveParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        israteOfFireMove = false;
        isSkillStart = false;
        Invoke("SkillStart", Random.Range(1, 10));

    }
    // Update is called once per frame
    void Update()
    {
        ////スキル冷却(れいきゃく)　カウントダウン  
        CountingDown();
        //スキル維持時間　カウントダウン  
        SkillMovecontrol();
        if (isSkillStart && GetComponent<MonsterInstinct>().target != null && GetComponent<MonsterInstinct>().processAttackTargetGameObjectPos < 36.0F && !israteOfFireMove)
        {
            //スキル開始
            ShootFireStart();
        }
    }
    private void FixedUpdate()
    {//スキル中の処理
        if (skillTime <= 0.0F && israteOfFireMove)
        {
            ShootFireEnd();
        }
        if (skillTime > 0.1F)
        {
            ShootFireMove();
        }
    }
    //スキル開始
    public void ShootFireStart()
    { //スキルは使ったのでクルーダイム
        Skill_Start();
        israteOfFireMove = true;
        Debug.Log("ShootFireStart");
        //target獲得
        shootFireTarget = GetComponent<MonsterInstinct>().target;
        rateOfFireNum = 0;
        energyReserveParticleSystem.Play();
    }
    public void ShootFireMove()
    {
        rateOfFireNum++;
        if (rateOfFireNum % rateOfFire == 0 && rateOfFireNum > rateOfFireMin && rateOfFireNum * skillTime0 < rateOfFireMax * skillTime0)
        {
            //目標の方向獲得して向き
            if (shootFireTarget.transform != null)
            {
                transform.LookAt(shootFireTarget.transform);
            }
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            //弾作り
            GameObject newFlyingTools = Instantiate(flyingTools, transform.position, transform.rotation);
            newFlyingTools.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + Random.Range(-rateOfFireArcDegree, rateOfFireArcDegree), 0);
            newFlyingTools.GetComponent<flyingToolsControl>().MyDamage = GetComponent<MonsterInstinct>().myDamage * abilityMagnification;
            newFlyingTools.transform.parent = GameObject.Find("BulleBOX").transform;//BulleBOXの子ともGameObjectであり
            Spot();
        }
    }//スキル終了
    public void ShootFireEnd()
    {
        israteOfFireMove = false;
        GetComponent<MonsterInstinct>().isMove = true;
        GetComponent<MonsterAttack>().isApproachAttack = true;
        GetComponent<MonsterAttack>().isProcessAttack = true;
        Debug.Log("ShootFireEnd");
    }
    //このモンスターは生成された何秒後からスキルが使える----------------------
    private void SkillStart()
    {
        isSkillStart = true;
    }
    //動きを止める
    private void Spot()
    {
        GetComponent<MonsterInstinct>().isMove = false;
        GetComponent<MonsterAttack>().isApproachAttack = false;
        GetComponent<MonsterAttack>().isProcessAttack = false;
    }
}
