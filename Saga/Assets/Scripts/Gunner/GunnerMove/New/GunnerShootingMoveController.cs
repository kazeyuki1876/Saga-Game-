using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerShootingMoveController : MonoBehaviour
{
    [SerializeField]
    private GameObject
        data, //データの
        bullet,//弾
        gunPos;
    [SerializeField]
    private bool
        isTrigger = true;//射撃できるか
    [SerializeField]
    private int
        gunNumberMax = 2;//銃の種類
    public int
        gunNumber = 0;//今何銃を使ってる
    private void Start()
    {
        isTrigger = true;
    }
    public void GunsMoveStart()
    {
        if (isTrigger)
        {
            isTrigger = false;
            //一回に置いてなん発を打ちましたか。
            for (int Moves = 0; Moves < data.GetComponent<GunnerData>().bulletNums[gunNumber]; Moves++)
            {
                GunsMove();
                Invoke("GunTriggerMove", data.GetComponent<GunnerData>().bulletLimit[gunNumber]);
            }
        }
    }
    private void GunTriggerMove()
    {
        if (isTrigger == false)
        {
            isTrigger = true;
        }

    }

    private void GunsMove()
    {
        //　いまＰＬＡＹＥＲが持っている銃

        //銃弾あるか

        //銃が撃つときの火花

        //銃が撃つときの音


        // string BulletName = Bullets[0].name;

        //弾丸を作り　位置と向きを与える 
        bullet = Instantiate(data.GetComponent<GunnerData>().bullets[gunNumber], gunPos.transform.position, gunPos.transform.rotation);
        ////反発
        bullet.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + Random.Range(-data.GetComponent<GunnerData>().gunRecoils[gunNumber], data.GetComponent<GunnerData>().gunRecoils[gunNumber]), 0);
        //BulleBOXの子ともGameObjectであり
        bullet.transform.parent = GameObject.Find("BulleBOX").transform;//BulleBOXの子ともGameObjectであり
        //銃弾の速度
        bullet.GetComponent<BulletMove>().MySeppt= data.GetComponent<GunnerData>().bulletSeppts[gunNumber];
       // 銃弾の存在時間
        bullet.GetComponent<BulletMove>().MyLifespan = data.GetComponent<GunnerData>().bulletLifespans[gunNumber];
        //銃弾のダメージ
        bullet.GetComponent<BulletMove>().MyDamage = data.GetComponent<GunnerData>().bulletDamages[gunNumber];
        // bullet[GunsNum]++;//この銃弾いくらを打ちましたか；
        bullet.name = data.GetComponent<GunnerData>().bullets[gunNumber].name + data.GetComponent<GunnerData>().bulletNumer[gunNumber];//名前を付ける　何銃の何発

        //残弾量計算*/
    }

    public void GunsChange()
    {
        Debug.Log("GunsChange");
        gunNumber++;
        gunNumber = gunNumber % gunNumberMax;
        Debug.Log(gunNumber + "=" + gunNumber + "/" + gunNumberMax);
    }

}
