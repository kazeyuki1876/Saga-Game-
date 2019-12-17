using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainEquipmentScript : MonoBehaviour
{
    [SerializeField]
    private Sprite
        [] mainEquipmentImejiSprite = new Sprite[2];


    [SerializeField]
    private GameObject
         mainEquipmentImeji;
    [SerializeField]
    private Text
       mainEquipmentText;

    private void Update()
    {
        mainEquipmentImeji.GetComponent<Image>().fillAmount =
           GetComponent<GunnerShootingMoveController>().cartridgeClip[GetComponent<GunnerShootingMoveController>().gunNumber] / GetComponent<GunnerShootingMoveController>().data.GetComponent<GunnerData>().cartridgeClipMax[GetComponent<GunnerShootingMoveController>().gunNumber];
          
        //Debug.Log(GetComponent<GunnerShootingMoveController>().cartridgeClip[GetComponent<GunnerShootingMoveController>().gunNumber] / GetComponent<GunnerShootingMoveController>().data.GetComponent<GunnerData>().cartridgeClipMax[GetComponent<GunnerShootingMoveController>().gunNumber]);
        RemainingBullet();

    }
    private void RemainingBullet()
    {
        //使てる武器
        if (mainEquipmentImeji.GetComponent<Image>().sprite != mainEquipmentImejiSprite[GetComponent<GunnerShootingMoveController>().gunNumber])
        {
            mainEquipmentImeji.GetComponent<Image>().sprite = mainEquipmentImejiSprite[GetComponent<GunnerShootingMoveController>().gunNumber];
        }
        //残弾（読み）ざんだん
        if (mainEquipmentText.text != GetComponent<GunnerShootingMoveController>().cartridgeClip[GetComponent<GunnerShootingMoveController>().gunNumber] + "  /  " + GetComponent<GunnerShootingMoveController>().data.GetComponent<GunnerData>().cartridgeClipMax[GetComponent<GunnerShootingMoveController>().gunNumber])
        {
            mainEquipmentText.text = GetComponent<GunnerShootingMoveController>().cartridgeClip[GetComponent<GunnerShootingMoveController>().gunNumber] + "  /  " + GetComponent<GunnerShootingMoveController>().data.GetComponent<GunnerData>().cartridgeClipMax[GetComponent<GunnerShootingMoveController>().gunNumber];
        }
    }

}
