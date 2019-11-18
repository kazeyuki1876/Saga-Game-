using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballScript : MonoBehaviour
{
    public float Speed=100;
    // Start is called before the first frame update
    public void Update()
    {
        transform.position = new Vector3(transform.position.x- Speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
    void OnTriggerEnter(Collider col) //当进入碰撞器
    {
        //  Debug.Log("collisionInfo");
        //  Debug.Log(collisionInfo.gameObject.name);
        if (col.gameObject.tag == "Machine")
        {
            Debug.Log(col.gameObject.name+"         " + col.gameObject.tag);
            Destroy(col.gameObject);
            Destroy(this.gameObject);


        }

    }
}
