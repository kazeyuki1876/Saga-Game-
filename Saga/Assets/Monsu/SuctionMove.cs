using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuctionMove : MonoBehaviour
{

    private float speed=5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider col)
    {
        // Debug.Log(other.gameObject.name);
        if (col.gameObject.tag == "Player" && col.GetComponent<GunnaerHealth>().MyMagicStone< col.GetComponent<GunnaerHealth>(). MyMagicStoneMax)
        {
            transform.LookAt(col.transform);
          //  transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);//弾の動き
            if (transform.position.y < 7.0f) {
                transform.position = new Vector3(transform.position.x, 6.0f,transform.position.z);
            }
        }
    }
  
}
