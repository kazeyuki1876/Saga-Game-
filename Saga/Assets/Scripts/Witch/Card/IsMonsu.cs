using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMonsu : MonoBehaviour
{
    public bool isMonster;
    private void Update()
    {
        if (transform.position.z > 8)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 7.9f);
        }
        if (transform.position.z < -28)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -27.9f);
        }
    }
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
