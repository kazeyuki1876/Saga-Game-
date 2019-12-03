using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerShootingMoveController : MonoBehaviour
{

    [SerializeField]
    private GameObject
        Data, //データの
        bullet;//弾
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
            for (int Moves = 0; Moves < Data.GetComponent<GunnerData>().bulletNums[gunNumber]; Moves++)
            {
                GunsMove();
                Invoke("GunTriggerMove", Data.GetComponent<GunnerData>().bulletLimit[gunNumber]);
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

        //銃によっての弾
        // string BulletName = Bullets[0].name;

        bullet = Instantiate(Data.GetComponent<GunnerData>().bullets[gunNumber], this.transform.position, this.transform.rotation);//弾丸を作り　位置と向きを与える
        bullet.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + Random.Range(-Data.GetComponent<GunnerData>().gunRecoils[gunNumber], Data.GetComponent<GunnerData>().gunRecoils[gunNumber]), 0);
        bullet.transform.parent = GameObject.Find("BulleBOX").transform;//BulleBOXの子ともGameObjectであり
                                                                        //  bullet. bullet = BulletSeppts[GunsNum];
        bullet.GetComponent<BulletMove>().MyLifespan = Data.GetComponent<GunnerData>().bulletLifespans[gunNumber];
        bullet.GetComponent<BulletMove>().MyDamage = Data.GetComponent<GunnerData>().bulletDamages[gunNumber];
        // bullet[GunsNum]++;//この銃弾いくらを打ちましたか；
        bullet.name = Data.GetComponent<GunnerData>().bullets[gunNumber].name + Data.GetComponent<GunnerData>().bulletNumer[gunNumber];//名前を付ける　何銃の何発

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
