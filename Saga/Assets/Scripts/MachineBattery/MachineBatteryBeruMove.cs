using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBatteryBeruMove : MonoBehaviour
{
    [SerializeField]
    private bool isMove;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Move", 3, 12);
    }

    // Update is called once per frame
    void Move()
    {
            isMove = true;
        Invoke("MoveOFF", 1.0f);
    }
    void MoveOFF()
    {
            isMove = false;
    }

    void OnTriggerStay(Collider Monster)
    {
      
        if (isMove && Monster.gameObject.tag=="Monster") {
            //Debug.Log("testberu");
          //  Monster.GetComponent<MonsterScript>().Target = this.GetComponent<Transform>();
        }
    }

}
