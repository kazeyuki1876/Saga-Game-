using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerShootingMoveController : MonoBehaviour
{
    
    [SerializeField] private GameObject Data;
    [SerializeField] private GameObject bullet;


    void GunsMOVE()
    {
        //　いまＰＬＡＹＥＲが持っている銃

        //銃弾あるか

        //銃が撃つときの火花

        //銃が撃つときの音

        //銃によっての弾
        // string BulletName = Bullets[0].name;

        bullet = Instantiate(Data.GetComponent<GunnerData>().bullets[0], this.transform.position, this.transform.rotation);//弾丸を作り　位置と向きを与える
        /*bullet.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + Random.Range(-GunRecoils[GunsNum], GunRecoils[GunsNum]), 0);
        bullet.transform.parent = GameObject.Find("BulleBOX").transform;//BulleBOXの子ともGameObjectであり
        bullet. bullet = BulletSeppts[GunsNum];
        bullet.GetComponent<BulletMove>().MyLifespan = BulletLifespans[GunsNum];
        bullet.GetComponent<BulletMove>().MyDamage = BulletDamages[GunsNum];
        bullet[GunsNum]++;//この銃弾いくらを打ちましたか；
        bullet.name = Bullets[GunsNum].name + BulletNumer[GunsNum];//名前を付ける　何銃の何発
                                                                   //残弾量計算*/
    }

}
