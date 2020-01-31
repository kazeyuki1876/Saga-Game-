using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingTarget : MonoBehaviour
{//ターゲットを表すイメージ
    public GameObject ShouTingTargerUI;

    public GameObject shootingTargetImaje;
    
    private void Update()
    {
        if (GetComponent<GunnerMoveController>().shouTingTarger != null && ShouTingTargerUI == null)
        {
            ShootingTargetStart();
        }
        else if (GetComponent<GunnerMoveController>().shouTingTarger != null && ShouTingTargerUI != null)
        {

            ShootingTargetMove();
        }
        else if (GetComponent<GunnerMoveController>().shouTingTarger == null) {
            ShootingTargetEnded();
        }
    }
    private void ShootingTargetStart() {
       
            
            Debug.Log("ShootingTargetStart");
            ShouTingTargerUI = Instantiate(shootingTargetImaje, 
              GetComponent<GunnerMoveController>().shouTingTarger.transform.position,
              Quaternion.identity);
    }

    private void ShootingTargetMove() {

        ShouTingTargerUI.transform.position = new Vector3(GetComponent<GunnerMoveController>().shouTingTarger.transform.position.x, GetComponent<GunnerMoveController>().shouTingTarger.transform.position.y, GetComponent<GunnerMoveController>().shouTingTarger.transform.position.z-1);
        
    }
    private void ShootingTargetEnded() {

        Destroy(ShouTingTargerUI);
    }

}
