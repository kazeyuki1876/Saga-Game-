using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGameObject : MonoBehaviour
{
    public bool isGoj;
    private void Start()
    {
        GetComponent<Renderer>().material.color = Color.cyan;
        isGoj = true;
    }

    private void Update()
    {
        if (!isGoj)
        {
          
        }
        else {
          
        }
    }
    private void OnTriggerStay(Collider collisionInfo) //振られてる
    {
        if (collisionInfo.gameObject.tag == "Monster" || collisionInfo.gameObject.tag == "Machine")
        {
            GetComponent<Renderer>().material.color = Color.red;
            Debug.Log(collisionInfo.name);
            isGoj = false;
        }
    }
    private void OnTriggerExit(Collider collisionInfo) //離れる
    {
        if (collisionInfo.gameObject.tag == "Monster" || collisionInfo.gameObject.tag == "Machine")
        {
            isGoj = true;
            GetComponent<Renderer>().material.color = Color.cyan;
        }
    }
}
