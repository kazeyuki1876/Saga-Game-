using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GunnerData : MonoBehaviour
{
    public static int arrayMax = 2;
    //----------
    public GameObject[] bullets = new GameObject[arrayMax];//銃によっての弾
    public float[] bulletSeppts = new float[arrayMax];//銃弾の速度
    public float[] bulletLifespans = new float[arrayMax];//銃弾の存在時間
    public float[] bulletDamages = new float[arrayMax];//銃弾のダメージ
    public float[] bulletLimit = new float[arrayMax];//銃弾の射撃速度
    public int[] bulletNums = new int[arrayMax];//一回の射撃につき何発を撃つか
    public float[] gunRecoils = new float[arrayMax];//反発
    public int[] bulletNumer = new int[arrayMax];//一つの銃に置いてなん発を打ちましたか。
    public int[] cartridgeClipMax = new int[arrayMax];//弾倉
    public float[] ReloadLimit = new float[arrayMax];///装填時間

    //GunnerBatteryInstallationMove



    //public GameObject[] instantiateBatteryGameObject;//設置しようGameObjectの
    public GameObject[] instantiateInstallationBattery = new GameObject[arrayMax];//設置しようGameObject
    public GameObject[] InstallationBattery = new GameObject[arrayMax];//設置しするGameObject
    public int[] InstallationBatteryNumer = new int[arrayMax];//設置しするGameObject
    public int[] BatteryHP = new int[arrayMax];//設置しするGameObject
    public int[] BatterybulletLimit = new int[arrayMax];//設置しするGameObject

    int GunnerDataStartNum;
    private void Start()
    {

    }
    /*
    void GunnerDataStart()
    {
        TextAsset csv = Resources.Load("CsvFolder/TextCsvData") as TextAsset;
        StringReader reader = new StringReader(csv.text);
        while (reader.Peek() > -1)
        {

            string line = reader.ReadLine();
            string[] values = line.Split(',');
            GunnerDataStartNum++;
            Debug.Log(values[0] + values[1] + values[2] + values[3]);
            if (GunnerDataStartNum > 1)
            {
                Name[GunnerDataStartNum - 2] = values[0];

                HP[GunnerDataStartNum - 2] = int.Parse(values[1]);
                ATK[GunnerDataStartNum - 2] = int.Parse(values[2]);
                DEF[GunnerDataStartNum - 2] = int.Parse(values[3]);
                Debug.Log(Name[GunnerDataStartNum - 1] + HP[GunnerDataStartNum - 1] + ATK[GunnerDataStartNum - 1] + DEF[GunnerDataStartNum - 1]);
            }


            //  Debug.Log(csv.name);



        }
    }
    */
}