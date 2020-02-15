

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunnaerHealth : MonoBehaviour
{
    [SerializeField]
    public float
        myHpMax = 100,
        MyHp = 100,
        MyMagicStone = 20,
        MyMagicStoneMax = 50,
        castleHp=3000,
        castleHpMax=3000;

    [SerializeField]
    private float fillAmountSpeed = 0.5f;
    //魔石数				
  

    public Text PlayerHp, PlayerMagicStone, batteryQuantityText, castleHpText;
    [SerializeField]
    private Image
        GannerHpGaugeRed,
        GannerHpGaugeGreen,
        GannerMagicStoneGauge,
        batteryQuantityGauge,
        castleHpGauge0,
        castleHpGauge;

    [SerializeField]
    private GameObject castle;


   // Start is called before the first frame update				
   void Start()
    {
        MyHp = myHpMax;
        castleHp = castleHpMax;
        castle.GetComponent<CastleScript>().MyHp = (int)castleHp;
       
       
    }

    // Update is called once per frame				
    void Update()
    {
        if(MyMagicStone< MyMagicStoneMax)
        {
            MyMagicStone += 0.2f * Time.deltaTime;

        }

        PlayerHp.text = "PLAYER HP:" + MyHp + "/" + myHpMax;
        PlayerMagicStone.text = "ENERGY:" + MyMagicStone+ "/"+ MyMagicStoneMax;
        castleHpText.text = "CASTLE HP:" + castleHp + "/" + castleHpMax;
        batteryQuantityText.text = GetComponent<GunnerBatteryInstallationMove>().batteryQuantity + "/" + GetComponent<GunnerBatteryInstallationMove>().batteryQuantityMax;
        GannerHpGaugeMove();
        GannerMagicStoneGaugeMove();
        CastleHPGaugeMove();
        batteryQuantityGaugeMove();
        if (MyHp > myHpMax) {
            MyHp = myHpMax;
        }
        if (MyMagicStone > MyMagicStoneMax)
        {
            MyMagicStone = MyMagicStoneMax;
         }
    }
    void OnTriggerEnter(Collider MagicStone)
    {

        // 魔石拾い				
        if (MagicStone.gameObject.tag == "MagicStone" && MyMagicStone<MyMagicStoneMax)
        {
            Debug.Log("MagicStone");
            //  MyMagicStone = MyMagicStone + MagicStone.GetComponent<MagicStoneScript>().MagicStone;				
            MagicStone.GetComponent<MagicStoneScript>().DestroyFather();
              // MyMagicStoneを崩壊				
            MyMagicStone++;
        }
    }
    //HPゲージ
    void GannerHpGaugeMove(){

       // GannerHpGaugeGreen.fillAmount = MyHp / myHpMax;

        float GannerHpGaugeGreenSpeed = GannerHpGaugeGreen.fillAmount - MyHp / myHpMax;
        GannerHpGaugeGreen.fillAmount = GannerHpGaugeGreen.fillAmount - GannerHpGaugeGreenSpeed * fillAmountSpeed * Time.deltaTime;

        if (GannerHpGaugeRed.fillAmount > GannerHpGaugeGreen.fillAmount)
        {
            GannerHpGaugeRed.fillAmount = GannerHpGaugeRed.fillAmount - (GannerHpGaugeRed.fillAmount - GannerHpGaugeGreen.fillAmount) * fillAmountSpeed * Time.deltaTime;
        }
        else
        {
            GannerHpGaugeRed.fillAmount = GannerHpGaugeGreen.fillAmount;
        }
    }
    //魔石ゲージ
    void GannerMagicStoneGaugeMove() {

        if (GannerMagicStoneGauge.fillAmount != MyMagicStone / MyMagicStoneMax) {
          //  Debug.Log(GannerMagicStoneGauge.fillAmount + "       " + MyMagicStone / MyMagicStoneMax);
            float GannerMagicStoneGaugeSpeed = GannerMagicStoneGauge.fillAmount - MyMagicStone / MyMagicStoneMax;
            GannerMagicStoneGauge.fillAmount = GannerMagicStoneGauge.fillAmount - GannerMagicStoneGaugeSpeed * fillAmountSpeed * Time.deltaTime;
        }

    }
    public void Isdie() {
        if (MyHp < 0) {
            Debug.Log("Gunnaer is die");
            GameObject.Find("OverTime").GetComponent<OutTime>().GameEnd();
        }
     
    }
    void CastleHPGaugeMove()
    {
        
        castleHp = castle.GetComponent<CastleScript>().MyHp;

        if (castleHpGauge.fillAmount != castleHp / castleHpMax)
        {
            //  Debug.Log(GannerMagicStoneGauge.fillAmount + "       " + MyMagicStone / MyMagicStoneMax);
            float castleHpGaugeSpeed = castleHpGauge.fillAmount - castleHp / castleHpMax;

            castleHpGauge.fillAmount = castleHpGauge.fillAmount - castleHpGaugeSpeed * fillAmountSpeed * Time.deltaTime;
        }
        // 0 0 0 0.5
        // 1 0 0 1
        castleHpGauge0.GetComponent<Image>().color = new Vector4(1, 1 * castleHp / castleHpMax, 1 * castleHp / castleHpMax, 1 -castleHp/ castleHpMax);

        //  castleHpGauge0.GetComponent<Image>().color = new Vector4(castleHpGauge0.color.r, 1 * GameTime / gameTimeMax, castleHpGauge0.color.b, 255 / 255);


    }
    void batteryQuantityGaugeMove()
    {
        if (batteryQuantityGauge.fillAmount != (float)GetComponent<GunnerBatteryInstallationMove>().batteryQuantity / (float)GetComponent<GunnerBatteryInstallationMove>().batteryQuantityMax)
        {
            //  Debug.Log(GannerMagicStoneGauge.fillAmount + "       " + MyMagicStone / MyMagicStoneMax);
            float batteryQuantityGaugeSpeed = batteryQuantityGauge.fillAmount - (float)GetComponent<GunnerBatteryInstallationMove>().batteryQuantity / (float)GetComponent<GunnerBatteryInstallationMove>().batteryQuantityMax;
            batteryQuantityGauge.fillAmount = batteryQuantityGauge.fillAmount - batteryQuantityGaugeSpeed * fillAmountSpeed * Time.deltaTime;
        }

    }
}





