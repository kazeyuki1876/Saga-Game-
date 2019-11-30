using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerData : MonoBehaviour
{   //Length
    //int Array = 3;
    public GameObject[] bullets = new GameObject[3];//銃弾の速度
    public float[] bulletSeppts = new float[3];//銃弾の速度
    public float[] bulletLifespans = new float[3];//銃弾の存在時間
    public float[] bulletDamages = new float[3];//銃弾のダメージ
    public float[] bulletLimit = new float[3];//銃弾の射撃速度
    public int[] bulletNums = new int[3];//一回の射撃につき何発を撃つか
    public float[] gunRecoils = new float[3];//反発
    public int[] bulletNumer = new int[3];//一つの銃に置いてなん発を打ちましたか。
    private void Start()
    {
        
    }


}