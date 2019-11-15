using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{
    public Text[] CardText = new Text[3];

    //このカードは何カード
    public string MyName;//カードの名前
    //コスト
    public int MyCost;//カードのコスト
                      //能力
                      // public int MyFunction;//今いらない
                      //何かできる。
                      //コメント
    public string MyComment;//カードの説明
    // pos
    public float MyX=700;
    public float MyY;
    float Speed;
    
    //カードが発動したら使うもの
    public GameObject  Monsu;
   


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.name = MyName;
        CardText[0].text = MyName;
        CardText[1].text = "Cost"+MyCost;
        CardText[2].text = MyComment;
    }

    // Update is called once per frame
    void Update()
    {
        CardMove();
    }

    public void CardStart() {
       // Debug.Log(this.name);

        Monsu = Instantiate(Monsu, new Vector3(70,8, 5), transform.rotation);
    }
    public float SpeedTime =2;
    public void CardMove() {

        SpeedTime -= Time.deltaTime;
        if (SpeedTime <= 0) { SpeedTime = 0.0f;
            transform.position = new Vector3(MyX, MyY);
        }
        Speed = (MyY - transform.position.y)/SpeedTime;
        if (transform.position.y < MyY)
        {

            transform.position = new Vector3(MyX, transform.position.y + Speed * Time.deltaTime);

        }


        // transform.position = new Vector3(MyX, MyY);
    }
}
