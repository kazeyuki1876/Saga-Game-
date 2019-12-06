using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUI : MonoBehaviour
{
    private Text damageText;
    //　フェードアウトするスピード
    private float fadeOutSpeed = 1f;
    //　移動値
    [SerializeField]
    private float moveSpeed = 0.1f;
    public  int DamageNum;
    void Start()
    {
        
           damageText = GetComponentInChildren<Text>();

        damageText.text = ""+ DamageNum;
        transform.rotation = Camera.main.transform.rotation;
        transform.position = new Vector3(transform.position.x+Random.Range(-1,1), transform.position.y, transform.position.z);
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
