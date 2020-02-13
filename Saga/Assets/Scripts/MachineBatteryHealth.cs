using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBatteryHealth : MonoBehaviour
{
public int MyHp;
    public GameObject batteryBox;
 //   [SerializeField]
    public int MyNum=0;
    private bool isHp0;
    public GameObject diePs;
    private void Start()
    {

        MyHp = GameObject.Find("DataController").GetComponent<GunnerData>().BatteryHP[MyNum-1];
    }
    public void IsDIe()
    {
        if (MyHp <= 0&&!isHp0)
        {
            //GetComponent<BatterySE>().DieSE();
            isHp0 = true;
            GameObject Ps   = Instantiate(diePs, transform.position, transform.rotation);
         //   GetComponent<BatterySE>().DieSE();
            GameObject.Find("Gunner").GetComponent<GunnerBatteryInstallationMove>().batteryQuantity--;
            Destroy(batteryBox.gameObject, 0.1f);
        }
    }
}
