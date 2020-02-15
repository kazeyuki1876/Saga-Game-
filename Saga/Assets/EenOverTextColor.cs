using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EenOverTextColor : MonoBehaviour
{
    private Text my;
    private float colorA;
    // Start is called before the first frame update
    void Start()
    {
        colorA = 0;
       
        my = this.gameObject.GetComponent<Text>();
        my.text = my.text.Replace("\\n", "\n");
    }

    // Update is called once per frame
    void Update()
    {
        colorA += Time.deltaTime*150;
        if (colorA + 50>255.0f) { colorA = 0; }
        my.color = new Color(my.color.r, my.color.g, my.color.b,(50.0f+ colorA) /255.0f);
    }
}
