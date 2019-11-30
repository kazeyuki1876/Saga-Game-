using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TakeDamage : MonoBehaviour
{//　DamageUIプレハブ
    [SerializeField]
    private GameObject damageUI;
    public int DamageNum;
    public void Damage(Collider col)
    {
        //　DamageUIをインスタンス化。登場位置は接触したコライダの中心からカメラの方向に少し寄せた位置
        var obj = Instantiate<GameObject>(damageUI, col.bounds.center - Camera.main.transform.forward * 0.2f, Quaternion.identity);
       // obj.GetComponent<DamageUI>().DamageNum = DamageNum;
       // DamageText.text
        obj.transform.SetParent(col.transform);
    }
    public void Damage(Collision col2)
    {
        //　DamageUIをインスタンス化。登場位置は接触したコライダの中心からカメラの方向に少し寄せた位置
        var obj = Instantiate<GameObject>(damageUI, col2.collider.bounds.center - Camera.main.transform.forward * 0.2f, Quaternion.identity);
        // obj.GetComponent<DamageUI>().DamageNum = DamageNum;
        // DamageText.text
        obj.transform.SetParent(col2.transform);
    }
}
