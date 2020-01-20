

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
        MyMagicStoneMax = 50;
  
    [SerializeField]
    private float fillAmountSpeed = 0.5f;
    //魔石数				
  

    public Text PlayerHp, PlayerMagicStone;
    [SerializeField]
    private Image
        GannerHpGaugeRed,
        GannerHpGaugeGreen,
        GannerMagicStoneGauge;




    // Start is called before the first frame update				
    void Start()
    {
        MyHp = myHpMax;
        //HP=MAXHP				
    }

    // Update is called once per frame				
    void Update()
    {
        PlayerHp.text = "HP" + MyHp + "/" + myHpMax;
        PlayerMagicStone.text = "MP" + MyMagicStone+ "/"+ MyMagicStoneMax;
        GannerHpGaugeMove();
        GannerMagicStoneGaugeMove();
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
}





