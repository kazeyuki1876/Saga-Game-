using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerShootingMoveController : MonoBehaviour
{
    public ParticleSystem[] shootingParticleSystem; 
    public GameObject
        gunPos,
        data;   //データの
    [SerializeField]
    private GameObject
                bullet;//弾
    

  public bool isTrigger = true;//射撃できるか
    public bool isReload = false;
    [SerializeField]
    private int
        gunNumberMax = 2;//銃の種類
  
    public int
        gunNumber = 0;
    [SerializeField]//今何銃を使ってる
    public int  [] cartridgeClip;


    private void Start()
    {
        isTrigger = true;
        shootingParticleSystem[0].Stop();
        shootingParticleSystem[1].Stop();
    }
   
    public void GunsMoveStart()
    {
        if (isTrigger && !isReload && cartridgeClip[gunNumber] > 0)//射撃許可　装填中ではない　弾あり
        {
            cartridgeClip[gunNumber] -= 1;
            isTrigger = false;
            //一回に置いてなん発を打ちましたか。
            for (int Moves = 0; Moves < data.GetComponent<GunnerData>().bulletNums[gunNumber]; Moves++)
            {
                GunsMove();
                Invoke("GunTriggerMove", data.GetComponent<GunnerData>().bulletLimit[gunNumber]);
            }
        }//弾がない
        else if (cartridgeClip[gunNumber] >= 0) {
            ReloadMoveStart();
        }
    }
    //射撃出来るか
    private void GunTriggerMove()
    {
        isTrigger = true;
    }
  
    //射撃する
    private void GunsMove()
    {
        //銃が撃つときの火花
        //ParticleSystem 
        shootingParticleSystem[gunNumber].Play();
        //銃が撃つときの音
        if (gunNumber < 1) {
            GetComponent<GunnerSE>().GunSE1();
        } else {
            GetComponent<GunnerSE>().GunSE2();
        }
      

        // string BulletName = Bullets[0].name;

        //弾丸を作り　位置と向きを与える 
        bullet = Instantiate(data.GetComponent<GunnerData>().bullets[gunNumber], gunPos.transform.position, gunPos.transform.rotation);
        ////反発
        bullet.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + Random.Range(-data.GetComponent<GunnerData>().gunRecoils[gunNumber], data.GetComponent<GunnerData>().gunRecoils[gunNumber]), 0);
    
        //BulleBOXの子ともGameObjectであり
        bullet.transform.parent = GameObject.Find("BulleBOX").transform;//BulleBOXの子ともGameObjectであり
        //銃弾の速度
        bullet.GetComponent<BulletMove>().MySeppt = data.GetComponent<GunnerData>().bulletSeppts[gunNumber];
        // 銃弾の存在時間
        bullet.GetComponent<BulletMove>().MyLifespan = data.GetComponent<GunnerData>().bulletLifespans[gunNumber];
        //銃弾のダメージ
        bullet.GetComponent<BulletMove>().MyDamage = data.GetComponent<GunnerData>().bulletDamages[gunNumber];

        //貫通数
        bullet.GetComponent<BulletMove>().myPenetrationVolume = data.GetComponent<GunnerData>().bulletPenetrationvolume[gunNumber];

        // bullet[GunsNum]++;//この銃弾いくらを打ちましたか；
        bullet.name = data.GetComponent<GunnerData>().bullets[gunNumber].name + data.GetComponent<GunnerData>().bulletNumer[gunNumber];//名前を付ける　何銃の何発

        //残弾量計算*/
    }
    //リロード/装填する
    public void ReloadMoveStart()
    {//装填すべきか
        if (cartridgeClip[gunNumber] < data.GetComponent<GunnerData>().cartridgeClipMax[gunNumber] && isTrigger&&!isReload)
        {
            GetComponent<GunnerSE>().ReloadStart();
            isReload = true;//装填中
            Invoke("GunReloadMove", data.GetComponent<GunnerData>().ReloadLimit[gunNumber]);//装填時間
            GunsReloadComment(transform);
        }
        else if (!isTrigger)
        {
           // Debug.Log("射撃反発中");
        }
        else
        {
          //  Debug.Log(data.GetComponent<GunnerData>().bullets[gunNumber].name + "いっぱいです。今のcartridgeClipは" + cartridgeClip[gunNumber] + "発");
        }

    }
     void ReloadStart() {
        cartridgeClip[0] = data.GetComponent<GunnerData>().cartridgeClipMax[0];//装填する
        cartridgeClip[1] = data.GetComponent<GunnerData>().cartridgeClipMax[1];//装填する


    }
    //武器の切り替え
    public void GunsChange()
    {
        if (isTrigger && !isReload) {
          //  Debug.Log("GunsChange");
            gunNumber++;
            gunNumber = gunNumber % gunNumberMax;
          //  Debug.Log(gunNumber + "=" + gunNumber + "/" + gunNumberMax);
        }
       
    }
    public void GunsReloadComment(Transform transform)
    {
        //  void OnTriggerEnter(Collider col)
       // Debug.Log("リロード");

        //  gameObject = this.gameObject;
        gameObject.GetComponent<TakeDamage>().comment = data.GetComponent<GunnerData>().bullets[gunNumber].name+ "リロード中";
        gameObject.transform.gameObject.GetComponent<TakeDamage>().Damage(transform);//ダメージ文字UI

       
      

    }
    void GunReloadMove() {

        isReload = false;
        GetComponent<GunnerSE>().ReloadEnd();
        cartridgeClip[gunNumber] = data.GetComponent<GunnerData>().cartridgeClipMax[gunNumber];//装填する
    }


}
