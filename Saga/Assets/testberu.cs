using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testberu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider Mo)
    {
        Debug.Log("testberu");
        if (Input.GetKeyDown(KeyCode.G)&& Mo.gameObject.tag=="Monster") {
            Debug.Log("testberu");
            Mo.GetComponent<MonsterScript>().Target = this.GetComponent<Transform>();
        }
    }

}
