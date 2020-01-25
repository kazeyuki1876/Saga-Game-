using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicStoneScript : MonoBehaviour
{
    [SerializeField]
    private GameObject fatherGameObject;
    /// <summary>
    ///魔石が回るスクリプト
    [SerializeField]
    private float MySpeed=20.0f;
    private void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + MySpeed * Time.deltaTime, 0);
    }
    private void SuctionGameObjectOnTriggerStay(Collider col) {
    }
    public void DestroyFather() {
    Destroy(fatherGameObject);  
    } 
}   /// </summary>
