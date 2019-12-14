

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunnaerHealth : MonoBehaviour
{
    public float myHpMax = 100;
    public float MyHp = 100;
    [SerializeField]
    private float fillAmountSpeed = 0.5f;
    //魔石数				
    public int MyMagicStone = 0;

    public Text PlayerHp, PlayerMagicStone;
    [SerializeField]
    private Image
        GannerHpGaugeRed,
        GannerHpGaugeGreen;



    // Start is called before the first frame update				
    void Start()
    {
        MyHp = myHpMax;
        //HP=MAXHP				
    }

    // Update is called once per frame				
    void Update()
    {
        PlayerHp.text = "生命" + MyHp;
        PlayerMagicStone.text = "魔石" + MyMagicStone;
        GannerHpGaugeMove();
    }
    void OnTriggerEnter(Collider MagicStone)
    {

        // 魔石拾い				
        if (MagicStone.gameObject.tag == "MagicStone")
        {
            Debug.Log("MagicStone");
            //  MyMagicStone = MyMagicStone + MagicStone.GetComponent<MagicStoneScript>().MagicStone;				
            Destroy(MagicStone.gameObject);  // MyMagicStoneを崩壊				
            MyMagicStone++;
        }
    }
    void GannerHpGaugeMove(){
      
        //-
        GannerHpGaugeGreen.fillAmount = MyHp / myHpMax;
        if (GannerHpGaugeRed.fillAmount > GannerHpGaugeGreen.fillAmount)
        {
            GannerHpGaugeRed.fillAmount = GannerHpGaugeRed.fillAmount - (GannerHpGaugeRed.fillAmount - GannerHpGaugeGreen.fillAmount) * fillAmountSpeed * Time.deltaTime;
        }
        else
        {
            GannerHpGaugeRed.fillAmount = GannerHpGaugeGreen.fillAmount;
        }


    }
}





