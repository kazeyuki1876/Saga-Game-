using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuctionMove : MonoBehaviour
{
    private float speed=5;
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" && col.GetComponent<GunnaerHealth>().MyMagicStone< col.GetComponent<GunnaerHealth>(). MyMagicStoneMax)
        {
            transform.LookAt(col.transform);
            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
            transform.position = new Vector3(transform.position.x, 6.0f,transform.position.z);
        }
    }
}
