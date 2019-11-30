using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMonsu : MonoBehaviour
{
    public bool isMonster;
    void OnTriggerExit(Collider collisionInfo) //当进入碰撞器
    {
        //  Debug.Log("collisionInfo");
        //  Debug.Log(collisionInfo.gameObject.name);
        if (collisionInfo.gameObject.tag == "Monster")
        {
            isMonster = false;
        }
    }
    void OnTriggerStay(Collider collisionInfo) //当进入碰撞器
    {
        //  Debug.Log("collisionInfo");
        //  Debug.Log(collisionInfo.gameObject.name);
        if (collisionInfo.gameObject.tag == "Monster")
        {
            isMonster = true;
        }
    }
   

}
