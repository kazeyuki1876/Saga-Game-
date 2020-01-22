using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUI : MonoBehaviour
{
    private Text damageText;
    //　フェードアウトするスピード
    private float fadeOutSpeed = 2f;
    //　移動値
    [SerializeField]
    private float moveSpeed = 0.1f;
    public  int DamageNum;
    public string comment;

    void Start()
    {
        
           damageText = GetComponentInChildren<Text>();
        if (DamageNum != 0) {
            if (DamageNum < 20.0f) {
                damageText.fontSize = 8;
                damageText.resizeTextMinSize = damageText.fontSize-2;
                damageText.resizeTextMaxSize = damageText.fontSize+2;
                fadeOutSpeed = 4f;
            }
            else if (DamageNum < 101.0f)
            {
                damageText.fontSize = (int)(8+ DamageNum/10);
                damageText.resizeTextMinSize = damageText.fontSize - 3;
                damageText.resizeTextMaxSize = damageText.fontSize + 3;
                fadeOutSpeed = 3f;
            }
            else if (DamageNum < 1000)
            {
                damageText.fontSize = (int)(12 + DamageNum / 50);
                damageText.resizeTextMinSize = damageText.fontSize - 5;
                damageText.resizeTextMaxSize = damageText.fontSize + 5;
                fadeOutSpeed = 2f;
            }
            
                damageText.text = "" + DamageNum;
            

        } else {
            damageText.text = "" + comment;
            fadeOutSpeed = 0.5f;
            moveSpeed = 1.0f;
        }
      
     
        transform.rotation = Camera.main.transform.rotation;
      
        transform.position = new Vector3(transform.position.x + Random.Range(-1.0f, 1.0f), transform.position.y +Random.Range(0.5f, 1.0f), transform.position.z- Random.Range(2.0f,3.0f));
        transform.SetParent(GameObject.Find("DamageBOX").transform);//Handの子ともGameObjectであり
    }

    void LateUpdate()
    {
        
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        damageText.color = Color.Lerp(damageText.color, new Color(1f, 0f, 0f, 0f), fadeOutSpeed * Time.deltaTime);


        if (damageText.color.a <= 0.1f)
        {
            Destroy(gameObject);
        }

    }
}
