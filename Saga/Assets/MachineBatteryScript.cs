using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBatteryScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float MyHP;
    public float MyLifespan;
    public float MyDamage;
    public float MyShootingSpeed;
    public GameObject Bullet;
    public GameObject Bullets;
    public bool IsShooting = true;
    //--------------------
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

    private void Update()
    {
        ShootingSupport(); }
    void ShootingSupport()
    {//IsShootingSupport 射撃サポート
     //経過時間を取得

        searchTime += Time.deltaTime;

        if (searchTime >= 1.0f)
        {
            //最も近かったオブジェクトを取得
            nearObj = serchTag(gameObject, "Monster");

            //経過時間を初期化
            searchTime = 0;
        }

        //対象の位置の方向を向く
        if(nearObj!=null)
        if (nearObj.transform.position.x > this.transform.position.x - 30.0f && nearObj.transform.position.x < this.transform.position.x + 30.0f) {
            transform.LookAt(nearObj.transform);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            Shooting();
        }

        //自分自身の位置から相対的に移動する
        //transform.Translate(Vector3.forward * 0.01f);
    }

    void Shooting() {
        if (IsShooting) {
            IsShooting = false;
            GunsMOVE();
            Invoke("ShootingON",0.33f);
        }

    }
    void ShootingON(){

        IsShooting = true;
    }

    void GunsMOVE()
    {
      
        //　いまＰＬＡＹＥＲが持っている銃

        //銃弾あるか

        //銃が撃つときの火花

        //銃が撃つときの音

        //銃によっての弾
        // string BulletName = Bullets[0].name;
        Bullet = Instantiate(Bullets, this.transform.position, this.transform.rotation);//弾丸を作り　位置と向きを与える
        Bullet.transform.parent = GameObject.Find("BulleBOX").transform;//BulleBOXの子ともGameObjectであり
        Bullet.GetComponent<BulletMove>().MySeppt = 150;
        Bullet.GetComponent<BulletMove>().MyLifespan = 2;
        Bullet.GetComponent<BulletMove>().MyDamage = 1;
        
        //残弾量計算
    }
}
