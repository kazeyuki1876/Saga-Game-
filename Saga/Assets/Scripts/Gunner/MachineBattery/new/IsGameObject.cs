using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGameObject : MonoBehaviour
{
    public bool isGoj;

    private void Update()
    {
        if (!isGoj)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else {
            GetComponent<Renderer>().material.color = Color.cyan;
        }
    }
    void OnTriggerExit(Collider collisionInfo) //当进入碰撞器
    {
        //  Debug.Log("collisionInfo");
        //  Debug.Log(collisionInfo.gameObject.name);
        if (collisionInfo.gameObject==null)
        {
            Debug.Log(collisionInfo.name);
            isGoj = false;
        }
    }
    void OnTriggerStay(Collider collisionInfo) //当进入碰撞器
    {
        //  Debug.Log("collisionInfo");
        //  Debug.Log(collisionInfo.gameObject.name);
        if (collisionInfo.gameObject!=null)
        {
            Debug.Log(collisionInfo.name);
            isGoj = true;
        }
    }
}
