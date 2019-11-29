using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testberu : MonoBehaviour
{ bool isMove;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Load", 12, 12);
    }

    // Update is called once per frame
    void Move()
    {
        if (!isMove) {
            isMove = true;
        } else if (isMove) {
            isMove = false;
        }
    }
    void OnTriggerStay(Collider Mo)
    {
      
        if (isMove && Mo.gameObject.tag=="Monster") {
            //Debug.Log("testberu");
            Mo.GetComponent<MonsterScript>().Target = this.GetComponent<Transform>();
        }
    }

}
