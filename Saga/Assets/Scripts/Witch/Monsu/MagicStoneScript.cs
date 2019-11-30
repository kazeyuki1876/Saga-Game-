using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicStoneScript : MonoBehaviour
{
    /// <summary>
    ///魔石が回るスクリプト
    /// </summary>
    [SerializeField]
    private float MySpeed=20.0f;
       // Start is called before the first frame update
       void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + MySpeed * Time.deltaTime, 0);
    }
}
