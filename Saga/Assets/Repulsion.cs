using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repulsion : MonoBehaviour
{

    public GameObject targetGameObject;//撃退されるGameObject
    public GameObject formGameObject;//撃退するGameObject
    public float repulsionSpeed;//撃退速度
    public float repulsionMagnification = 1.0f;//撃退倍率

    public void RepulsionMove(Collider col)
    {
        Transform Target = targetGameObject.transform;//当たったもののPOｓ
        Rigidbody rb = targetGameObject.GetComponent<Rigidbody>(); ;//当たったもののRigidbody
                                                                   
        formGameObject.transform.LookAt(Target);//撃退方向
        formGameObject.transform.eulerAngles = new Vector3(0, formGameObject.transform.eulerAngles.y, 0);//水平方向に撃退する
        rb.AddForce(formGameObject.transform.position + formGameObject.transform.forward * repulsionMagnification * repulsionSpeed);//弾の方向に撃退する


    }
    /*
    public class RepulsionVoid
    {
        public GameObject targetGameObject;//撃退されるGameObject
        public GameObject formGameObject;//撃退するGameObject
        public float repulsionSpeed;//撃退速度
        public float repulsionMagnification = 1.0f;//撃退倍率
        public void RepulsionMove()
        {
            Transform Target = targetGameObject.transform;//当たったもののPOｓ
            Rigidbody rb = targetGameObject.GetComponent<Rigidbody>(); ;//当たったもののRigidbody
            //  GetComponent<Rigidbody>().velocity = transform.up * MySeppt;
            //transform.LookAt(Target);//撃退方向
            formGameObject.transform.eulerAngles = new Vector3(0, formGameObject.transform.eulerAngles.y, 0);//水平方向に撃退する
            rb.AddForce(formGameObject.transform.position + formGameObject.transform.forward * repulsionMagnification * repulsionSpeed);//弾の方向に撃退する
        }
        /*
             targetGameObject;//撃退されるGameObject
             formGameObject;//撃退するGameObject
             repulsionSpeed;//撃退速度
             repulsionMagnification=10.0f;//撃退倍率
         */
}


