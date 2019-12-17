using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainEquipmentScript : MonoBehaviour
{
    // 武器２のイラストは使えない　新しくの欲しい

    [SerializeField]
    private Sprite
        [] mainEquipmentImejiSprite = new Sprite[2];


    [SerializeField]
    private GameObject

         [] mainEquipmentImeji;
    [SerializeField]
    private Text
       mainEquipmentText;
    [SerializeField]
    private float Reloadtime;

    private void Update()
    {

       // mainEquipmentImeji[0].GetComponent<Image>().fillAmount = (float)GetComponent<GunnerShootingMoveController>().cartridgeClip[GetComponent<GunnerShootingMoveController>().gunNumber] / (float)GetComponent<GunnerShootingMoveController>().data.GetComponent<GunnerData>().cartridgeClipMax[GetComponent<GunnerShootingMoveController>().gunNumber];
        MainEquipmentFillAmount();
        RemainingBullet();
    }
    private void RemainingBullet()
    {
        //使てる武器
        if (mainEquipmentImeji[0].GetComponent<Image>().sprite != mainEquipmentImejiSprite[GetComponent<GunnerShootingMoveController>().gunNumber])
        {
            mainEquipmentImeji[0].GetComponent<Image>().sprite = mainEquipmentImejiSprite[GetComponent<GunnerShootingMoveController>().gunNumber];
            mainEquipmentImeji[1].GetComponent<Image>().sprite = mainEquipmentImejiSprite[GetComponent<GunnerShootingMoveController>().gunNumber];

        }
        //残弾（読み）ざんだん
        if (mainEquipmentText.text != GetComponent<GunnerShootingMoveController>().cartridgeClip[GetComponent<GunnerShootingMoveController>().gunNumber] + "  /  " + GetComponent<GunnerShootingMoveController>().data.GetComponent<GunnerData>().cartridgeClipMax[GetComponent<GunnerShootingMoveController>().gunNumber])
        {
            mainEquipmentText.text = GetComponent<GunnerShootingMoveController>().cartridgeClip[GetComponent<GunnerShootingMoveController>().gunNumber] + "  /  " + GetComponent<GunnerShootingMoveController>().data.GetComponent<GunnerData>().cartridgeClipMax[GetComponent<GunnerShootingMoveController>().gunNumber];
        }
    }
    private void MainEquipmentFillAmount()
    {
       
        if (!GetComponent<GunnerShootingMoveController>().isReload)
        {
            mainEquipmentImeji[0].GetComponent<Image>().fillAmount = (float)GetComponent<GunnerShootingMoveController>().cartridgeClip[GetComponent<GunnerShootingMoveController>().gunNumber] / (float)GetComponent<GunnerShootingMoveController>().data.GetComponent<GunnerData>().cartridgeClipMax[GetComponent<GunnerShootingMoveController>().gunNumber];
            Reloadtime = 0;
        }
        else {

            Reloadtime +=  (1.0f / (float)GetComponent<GunnerShootingMoveController>().data.GetComponent<GunnerData>().ReloadLimit[GetComponent<GunnerShootingMoveController>().gunNumber]) * Time.deltaTime;
            Debug.Log(Reloadtime);
            mainEquipmentImeji[0].GetComponent<Image>().fillAmount = Reloadtime;

        }
    }
}
