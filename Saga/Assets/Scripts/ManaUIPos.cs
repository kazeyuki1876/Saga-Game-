using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManaUIPos : MonoBehaviour
{
     private float MagicNum = 5;
    [SerializeField] Text []MagicUI;
    [SerializeField]
    private float StartMagic;
    [SerializeField] GameObject WitchUI;
    // Start is called before the first frame update
    void Start()
    {
        StartMagic = WitchUI.GetComponent<WitchUIScript>().MyMagicMAX;
        for (int i = 0; i <5 ; i++) {
            float MagicNum = StartMagic* (1 - 0.2f * i);
     //       Debug.Log(MagicNum);
            MagicUI[i].text = " "+MagicNum;
           
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
