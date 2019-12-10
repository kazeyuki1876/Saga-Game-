using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TakeDamage : MonoBehaviour
{//　DamageUIプレハブ
    [SerializeField]
    private GameObject damageUI;
    public int DamageNum;
    public string comment; 


    public void Damage(Collider col)
    {
       
        //　DamageUIをインスタンス化。登場位置は接触したコライダの中心からカメラの方向に少し寄せた位置
        var obj = Instantiate<GameObject>(damageUI, col.bounds.center - Camera.main.transform.forward * 0.2f, Quaternion.identity);
        obj.GetComponent<DamageUI>().DamageNum = DamageNum;
        DamageNum = 0;
        obj.GetComponent<DamageUI>().comment = comment;
            comment = null;
        // obj.GetComponent<DamageUI>().DamageNum = DamageNum;
        // obj.GetComponent<DamageUI>().DamageNum = DamageNum;
        // DamageText.text
        obj.transform.SetParent(col.transform);
    }
    public void Damage(Collision col2)
    {
        //　DamageUIをインスタンス化。登場位置は接触したコライダの中心からカメラの方向に少し寄せた位置
        var obj = Instantiate<GameObject>(damageUI, col2.collider.bounds.center - Camera.main.transform.forward * 0.2f, Quaternion.identity);
        obj.GetComponent<DamageUI>().DamageNum = DamageNum;
        DamageNum =0;
        obj.GetComponent<DamageUI>().comment = comment;
        comment = null;
        // obj.GetComponent<DamageUI>().DamageNum = DamageNum;
        // DamageText.text
        obj.transform.SetParent(col2.transform);
    }
    public void Damage(GameObject gameObject)
    {
        //　DamageUIをインスタンス化。登場位置は接触したコライダの中心からカメラの方向に少し寄せた位置
        var obj = Instantiate<GameObject>(damageUI, gameObject.gameObject.GetComponent<SpriteRenderer>().bounds.center - Camera.main.transform.forward * 0.2f, Quaternion.identity);
        obj.GetComponent<DamageUI>().DamageNum = DamageNum;
        DamageNum = 0;
        obj.GetComponent<DamageUI>().comment = comment;
        comment = null;
        // obj.GetComponent<DamageUI>().DamageNum = DamageNum;
        // DamageText.text
        obj.transform.SetParent(gameObject.transform);
    }
}
