using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{//プレイヤー
    public float MyHp=100;
    public float Seppt = 5;//ＰＬＡＹＥＲ速度
    public float AroundSeppt = 5;//周り速度
    public GameObject Player;//ＰＬＡＹＥＲ
    //射撃関係
    public GameObject[] Guns;//銃
    public GameObject[] Bullets;//銃弾
    public float[] BulletSeppts;//銃弾の速度
    public float[] BulletLifespans;//銃弾の存在時間
    public float[] BulletDamages;//銃弾のダメージ
    public GameObject Bullet;//いま射撃する銃弾
    public int[]BulletNumer;//一つの銃に置いてなん発を打ちましたか。
    //UI
    public Text PlayerHp;
    // Start is called before the first frame update
    void Start()
    {

      

    }

    // Update is called once per frame
    void Update()
    {
        PlayerHp.text = "PlayerHP" + MyHp;
        PlayerMOVE();
    }
    void PlayerMOVE() {
        //移動
        if (Input.GetKey("up"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * Seppt, Space.Self);

        }else if (Input.GetKey("down"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * (-Seppt * 0.75f), Space.Self);

        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(0, AroundSeppt, 0, Space.World);


        }else if (Input.GetKey("left"))
        {
            transform.Rotate(0, -AroundSeppt, 0, Space.World);
        }
        //射撃
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GunsMOVE();
        }
    }
    void GunsMOVE() {
        //　いまＰＬＡＹＥＲが持っている銃

        //銃弾あるか

        //銃が撃つときの火花

        //銃が撃つときの音

        //銃によっての弾
       // string BulletName = Bullets[0].name;
        Bullet = Instantiate(Bullets[0], this.transform.position, this.transform.rotation);//弾丸を作り　位置と向きを与える
        Bullet.transform.parent = GameObject.Find("BulleBOX").transform;//BulleBOXの子ともGameObjectであり
        Bullet.GetComponent<BulletMove>().MySeppt = BulletSeppts[0];
        Bullet.GetComponent<BulletMove>().MyLifespan = BulletLifespans[0];
        Bullet.GetComponent<BulletMove>().MyDamage = BulletDamages[0];


       
    BulletNumer[0]++;//この銃弾いくらを打ちましたか；
        Bullet.name = Bullets[0].name + BulletNumer[0];//名前を付ける　何銃の何発
        
        //残弾量計算
    }

}
