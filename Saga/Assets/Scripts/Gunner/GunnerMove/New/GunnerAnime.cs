using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerAnime : MonoBehaviour
{
    [SerializeField]
    private GameObject gunner;//GunnerAnimator
    //キャラ動きアニメーション
    // Animator コンポーネント
    [SerializeField]
    private Animator gunnerAnimator;//GunnerAnimator

    public const string key_isRun = "isRun";
    public const string key_isAim = "isAim";
    private float isTriggerTIme;
    // Start is called before the first frame update
    void Start()
    {//gunnerAnimator
        this.gunnerAnimator = GetComponent<Animator>();

        this.gunnerAnimator.SetBool(key_isRun, false);
        this.gunnerAnimator.SetBool(key_isAim, false);
    }
    // Update is called once per frame
    void Update()
    {
        if (!gunner.GetComponent<GunnerShootingMoveController>().isTrigger)
        {
            isTriggerTIme = gunner.GetComponent<GunnerShootingMoveController>().data.GetComponent<GunnerData>().bulletLimit[gunner.GetComponent<GunnerShootingMoveController>().gunNumber]+0.1f;
        }
        isTriggerTIme -= Time.deltaTime;
        AnimatorMove();
    }//

    private void AnimatorMove()
    {//
        if (gunner.GetComponent<GunnerMoveController>().isGround && gunner.GetComponent<GunnerMoveController>().moveX!=0 || gunner.GetComponent<GunnerMoveController>().moveZ != 0)
        {
           // Debug.Log("key_isRun");
            this.gunnerAnimator.SetBool(key_isRun, true);
        }
        else
        {
            this.gunnerAnimator.SetBool(key_isRun, false);
          //  Debug.Log("key_isRunNO");
        }

        //
        if (gunner.GetComponent<GunnerMoveController>().isShootingSupport|| isTriggerTIme >0|| gunner.GetComponent<GunnerShootingMoveController>().isReload)
        {
            //Debug.Log("isAim");
            this.gunnerAnimator.SetBool(key_isAim, true);
        }
        else
        {
           // Debug.Log("isAimNO");
            this.gunnerAnimator.SetBool(key_isAim, false);
        }
    }
}
