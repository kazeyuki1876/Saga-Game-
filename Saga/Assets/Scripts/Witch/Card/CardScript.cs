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
    float []PosX= new float[10] {0,3, 3, 6, 6, 6, 9, 9, 9, 9 };
    float[] PosZ = new float[10]{ 0, -2,2,-4,0,4,-6,-2,2,6};
    public int Moves;
    public int MonsterSpeed;
    public int MonsterMagicStone;
    //カードが発動したら使うもの
    public GameObject  Monsu;
   


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.name = MyName;
      
        CardText[1].text = ""+MyCost;
     
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
            Mons.transform.parent = GameObject.Find("MonstersBOX").transform;//MonstersBOXの子ともGameObjectであり
        }

       
    }
    public float SpeedTime =2;
    public void CardMove() {
        if (transform.position != new Vector3(MyX, MyY,0)) {

            SpeedTime -= Time.deltaTime;
            if (SpeedTime <= 0|| transform.position.y > MyY)
            {
                SpeedTime = 0.0f;
                transform.position = new Vector3(MyX, MyY,0);
            }
            Speed = (MyY - transform.position.y) / SpeedTime;
            if ((int)transform.position.y < MyY&& Speed<10000.0f)
            {

                transform.position = new Vector3(MyX, transform.position.y + Speed * Time.deltaTime, 0);

            }
            else {

                transform.position = new Vector3(MyX, MyY, 0);
                SpeedTime = 0.0f;
            }
        }
       


        // transform.position = new Vector3(MyX, MyY);
    }
}
