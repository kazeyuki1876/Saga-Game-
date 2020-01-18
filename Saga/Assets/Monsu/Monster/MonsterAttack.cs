using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{

    // //接近攻撃できるか
    [SerializeField]
    private bool isApproachAttack = true;
    // //遠距離攻撃できるか
    [SerializeField]
    private bool isProcessAttack = true;

    //遠距離攻撃の弾
    [SerializeField]
    private GameObject flyingTools;
    //弾の数
    [SerializeField]
    private int flyingToolsNum = 0;
    //弾の数MAX
    [SerializeField]
    private int flyingToolsNumMax = 5;
    //再攻撃の待つ時間
    [SerializeField]
    private float flyingToolsAttackTime = 1;
    private void Start()
    {//初期化準備もし必要でしたら
    }
    /// <summary>
    //接近攻撃
    /// <param name="col"></param>
    void OnCollisionStay(Collision col) //当进入碰撞器
    {
        if (col.gameObject.tag == "Player" && isApproachAttack)
        {
            AttackMove(col);
            col.gameObject.GetComponent<GunnaerHealth>().MyHp = col.gameObject.GetComponent<GunnaerHealth>().MyHp - (int)GetComponent<MonsterInstinct>().myDamage;
            col.gameObject.GetComponent<GunnaerHealth>().Isdie();
        }
        else if (col.gameObject.name == "Castle" && isApproachAttack)
        {
            AttackMove(col);
            col.gameObject.GetComponent<CastleScript>().MyHp = col.gameObject.GetComponent<CastleScript>().MyHp - (int)GetComponent<MonsterInstinct>().myDamage;
            col.gameObject.GetComponent<CastleScript>().IsOVER();

        }
        else if (col.gameObject.tag == "Machine" && isApproachAttack)
        {
            AttackMove(col);
            col.gameObject.GetComponent<MachineBatteryHealth>().MyHp -= (int)GetComponent<MonsterInstinct>().myDamage;
            col.gameObject.GetComponent<MachineBatteryHealth>().IsDIe();

        }
    }
    void AttackMove(Collision collision)
    {
        isApproachAttack = false;
        GetComponent<MonsterInstinct>().isMove = false;
        collision.transform.gameObject.GetComponent<TakeDamage>().Damage(collision);//ダメージ文字UI
        collision.transform.gameObject.GetComponent<TakeDamage>().DamageNum = (int)GetComponent<MonsterInstinct>().myDamage;
        Invoke("AttackPreparation", 1.0f);
    }
    void AttackPreparation()
    {
        isApproachAttack = true;
        GetComponent<MonsterInstinct>().isMove = true;
    }
    /// 
    /// </summary>

    private void Update()
    {
        ProcessAttackConControl();
    }
    //遠距離攻撃
    void ProcessAttackConControl()
    {
        if (GetComponent<MonsterInstinct>().target != null && GetComponent<MonsterInstinct>().isMove)
        {
            if (isProcessAttack && (transform.position.x - GetComponent<MonsterInstinct>().target.transform.position.x) * (transform.position.x - GetComponent<MonsterInstinct>().target.transform.position.x) + (transform.position.z - GetComponent<MonsterInstinct>().target.transform.position.z) * (transform.position.z - GetComponent<MonsterInstinct>().target.transform.position.z) < GetComponent<MonsterInstinct>().r0 * GetComponent<MonsterInstinct>().r0 * 1.5)
            {
                if (flyingToolsNum < flyingToolsNumMax)
                {
                    flyingToolsNum++;
                }
                else
                {
                    isProcessAttack = false;
                    Invoke("ProcessAttackPreparation", flyingToolsAttackTime);
                }
                GameObject newFlyingTools = Instantiate(flyingTools, transform.position, transform.rotation);
                newFlyingTools.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + Random.Range(-10, 10), 0);
                newFlyingTools.transform.parent = GameObject.Find("BulleBOX").transform;//BulleBOXの子ともGameObjectであり
            }
            //抑圧されたの処理
        }
        else if (!GetComponent<MonsterInstinct>().isMove)
        {
            isProcessAttack = false;
            Invoke("ProcessAttackPreparation", flyingToolsNum / flyingToolsNumMax * flyingToolsAttackTime);
        }
    }
    void ProcessAttackPreparation()
    {
        isProcessAttack = true;
        flyingToolsNum = 0;
        //GetComponent<MonsterInstinct>().isMove = true;
    }
    //--------スキル？技？
}