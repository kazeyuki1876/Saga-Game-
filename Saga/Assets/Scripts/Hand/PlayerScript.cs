using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{//プレイヤー
    public float MyHp = 100;
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
    public int[] BulletNumer;//一つの銃に置いてなん発を打ちましたか。
    //UI
    public Text PlayerHp;
    // Start is called before the first frame update

    //----------狙えサポート
    public bool IsShootingSupport;
    private GameObject nearObj;         //最も近いオブジェクト
    private float searchTime = 0;    //経過時間
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト
        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;
    }//-----------

    //------------機械設置
    public GameObject[] Machine;



    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        PlayerHp.text = "PlayerHP" + MyHp;
        PlayerMOVE();
        ShootingSupport();

    }
    void ShootingSupport() {//IsShootingSupport 射撃サポート
                            //経過時間を取得
        if (IsShootingSupport) { 
        searchTime += Time.deltaTime;

        if (searchTime >= 1.0f)
        {
            //最も近かったオブジェクトを取得
            nearObj = serchTag(gameObject, "Monster");

            //経過時間を初期化
            searchTime = 0;
        }

            //対象の位置の方向を向く
            if (nearObj != null) {

                transform.LookAt(nearObj.transform);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            }
       
            //自分自身の位置から相対的に移動する
            //transform.Translate(Vector3.forward * 0.01f);
        }
    }

    void PlayerMOVE() {
        //移動
    
        if (IsShootingSupport && nearObj != null)
        {
          
            if (Input.GetKey("up"))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+ Time.deltaTime * Seppt);
                //transform.Translate(Vector3.forward * Time.deltaTime * Seppt, Space.Self);

            }
            else if (Input.GetKey("down"))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * (-Seppt * 0.75f));
               // transform.Translate(Vector3.forward * Time.deltaTime * (-Seppt * 0.75f), Space.Self);

            }
            if (Input.GetKey("right"))
            {
                transform.position = new Vector3(transform.position.x + Time.deltaTime * Seppt, transform.position.y, transform.position.z);
               // transform.Translate(Vector3.right * Time.deltaTime * Seppt, Space.Self);


            }
            else if (Input.GetKey("left"))
            {
                transform.position = new Vector3(transform.position.x + Time.deltaTime * -Seppt, transform.position.y, transform.position.z);
            //    transform.Translate(Vector3.right * Time.deltaTime * -Seppt, Space.Self);
            }

            } else {

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

        }

        /*
         Machine 機械
         Battery 
         
         */
        if (Input.GetKeyDown(KeyCode.C)) {
            GameObject NewMachineBattery = Instantiate(Machine[0], new Vector3((int)transform.position.x + 10.0f, (int)transform.position.y, (int)transform.position.z), new Quaternion(0, 0, 0,0));
        }
        //射撃
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (IsShootingSupport) {
                IsShootingSupport = false;
            } else {
                IsShootingSupport = true; }
                     
                   
        }
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
