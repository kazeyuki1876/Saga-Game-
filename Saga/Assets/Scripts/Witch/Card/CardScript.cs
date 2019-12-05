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
    public int MonsterHP;
    // pos
    public float MyX=700;
    public float MyY;
    float Speed;
    public float MonsterStartX;
    public float MonsterStartY;
    public float MonsterStartZ;
    float []PosX= new float[10] {0,13, 13, 26, 26, 26, 39, 39, 39, 39 };
    float[] PosZ = new float[10]{ 0, -7,7,-14,0,14,-21,-7,7,21};
    public int Moves;
    public int MonsterSpeed;
    public int MonsterMagicStone;
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
        bool Boolean = (Random.value > 0.5f);//randomで
        //Debug.Log(Boolean);
       
        for (int Move = 0; Move < Moves; Move++) {
            GameObject Mons = Instantiate(Monsu, new Vector3(MonsterStartX + PosX[Move], 5.6f, MonsterStartZ + PosZ[Move]), transform.rotation);
            if (Mons.GetComponent<MonsterScript>() != null) { 
            if (Boolean)
            {
                Mons.GetComponent<MonsterScript>().StartTarget = GameObject.Find("Gunner").GetComponent<Transform>();
            }
            else
            {
                Mons.GetComponent<MonsterScript>().StartTarget = GameObject.Find("Castle").GetComponent<Transform>();
            }
            Mons.name = Monsu.name + Move;
            Mons.GetComponent<MonsterScript>().MySeppt = MonsterSpeed;
                Mons.GetComponent<MonsterScript>().MonsterMagicStone = MonsterMagicStone;
                Mons.GetComponent<MonsterScript>().MyHP = MonsterHP;
            }
        }

       
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
