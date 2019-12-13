using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBatteryHealth : MonoBehaviour
{
public int MyHp;
 //   [SerializeField]
    public int MyNum=0;
    private void Start()
    {

        MyHp = GameObject.Find("DataController").GetComponent<GunnerData>().BatteryHP[MyNum-1];
    }
    public void IsDIe()
    {
        if (MyHp <= 0)
        {
            Destroy(this.gameObject, 0.1f);
        }
    }
}
