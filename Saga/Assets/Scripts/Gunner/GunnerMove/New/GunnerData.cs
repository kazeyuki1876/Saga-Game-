﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerData : MonoBehaviour
{
    public static int arrayMax=2;
  //----------
    public GameObject[] bullets = new GameObject[arrayMax];//銃弾の速度
    public float[] bulletSeppts = new float[arrayMax];//銃弾の速度
    public float[] bulletLifespans = new float[arrayMax];//銃弾の存在時間
    public float[] bulletDamages = new float[arrayMax];//銃弾のダメージ
    public float[] bulletLimit = new float[arrayMax];//銃弾の射撃速度
    public int[] bulletNums = new int[arrayMax];//一回の射撃につき何発を撃つか
    public float[] gunRecoils = new float[arrayMax];//反発
    public int[] bulletNumer = new int[arrayMax];//一つの銃に置いてなん発を打ちましたか。

    //GunnerBatteryInstallationMove



    //public GameObject[] instantiateBatteryGameObject;//設置しようGameObjectの
    public GameObject[] instantiateInstallationBattery = new GameObject[arrayMax];//設置しようGameObject
    public GameObject[] InstallationBattery = new GameObject[arrayMax];//設置しするGameObject
    public int[] InstallationBatteryNumer = new int[arrayMax];//設置しするGameObject
    private void Start()
    {
        
    }


}