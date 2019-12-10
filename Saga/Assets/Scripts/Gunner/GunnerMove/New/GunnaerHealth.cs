﻿

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunnaerHealth : MonoBehaviour
{
    public float MyHp = 100;
    //魔石数				
  public int MyMagicStone = 0;

    public Text PlayerHp, PlayerMagicStone;
    // Start is called before the first frame update				
    void Start()
    {
        //HP=MAXHP				
    }

    // Update is called once per frame				
    void Update()
    {
        PlayerHp.text = "生命" + MyHp;
        PlayerMagicStone.text = "魔石" + MyMagicStone;
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
}





