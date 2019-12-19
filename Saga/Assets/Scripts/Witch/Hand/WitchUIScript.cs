using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WitchUIScript : MonoBehaviour
{
    // 　カード　1500
    //　マナメンター1450
    // Start is called before the first frame update


    //手札

    public GameObject[] Hand = new GameObject[5];//手札最大枚数
    public float MyMagic = 100;
    public float MyMagicMAX = 100;
    public float MagicRecoverySpeed;
    public Image MyMagicUI;
    //
    //手札チャージ
    public int HandNumSheet = 0;
    public bool isHandMax;//

    //　カード生成（せいせい）
    public GameObject[] NewCard = new GameObject[2];//魔法とモンスターに分かれ
    public GameObject CardParent;
    public string[] CardName;
    public int[] CardCost;
    public string[] CardComment;
    public int[] MonsterMagicStone;
    public int[] MonsterHP;
    public bool isWitchPlayerMove = true;
    int CardX = 1660;
    int[] CardY = new int[5] { 939, 789, 639, 489, 338 };
    public int[] Monsters = new int[10] { 5, 4, 3, 2, 1, 3, 7, 8, 9, 10 };
    public int[] MonsterSpeeds = new int[10] { 10, 15, 20, 25, 30, 6, 7, 8, 9, 10 };
    public GameObject InAdvanceInstallation;
    public GameObject NewInAdvanceInstallation;
    public float InAdvanceInstallationSpeed = 30;
    public Sprite[] CardImaje;
    public GameObject[] Monsus;
    /*　
     1　　　700
     2
     3
     4
     5
     
         
         */

    //Witchs操作
    public int SelecImeji;
    public Image SelectionCard;//選択中のカード
    //カードの配列
    public bool IsHandsArray;//
    [SerializeField] GameObject Ganner;

    void Start()
    {
        InvokeRepeating("Load", 0, 3f);
    }
    void Load()
    {
        if (Hand[4] == null) {
            HandCharge();
        }

        //  Debug.Log(Time.time + ":呼び出された");
    }

    // Update is called once per frame
    void Update()
    {
        HandsArray();
        if (Input.GetKeyDown(KeyCode.Q)) {
            HandCharge();
        }
        WitchPlayerMove();
        MagicCharge();

    }

    void MagicCharge() {
        if (MyMagic < MyMagicMAX) {
            MyMagic += MagicRecoverySpeed * Time.deltaTime;
            if (MyMagic > MyMagicMAX) {
                MyMagic = MyMagicMAX;
            }

        }
        MyMagicUI.GetComponent<Image>().fillAmount = MyMagic / MyMagicMAX;
    }//魔力回復
    void HandCharge()
    {//(手札Tefuda)をチャージ

        //  Debug.Log(Hand.Length);
        for (int HandNum = 0; HandNum < Hand.Length; HandNum++)
        {
            if (Hand[HandNum] == null)
            {
                // Debug.Log(" HandMax[HandNum]" + HandMax[HandNum]);
                HandNumSheet = HandNum;

                CardInstantiate();//card 実例化
                break;
            }
        }
        //  Debug.Log("俺のターン ドロー 手札から" + HandNumSheet + "枚を引こう");
    }//カードリロード

    void CardInstantiate()
    {//Instantiate
        int CardID = Random.Range(0, 6);

        Hand[HandNumSheet] = Instantiate(NewCard[0], new Vector3(CardX, 0, 0.0f), transform.rotation);//Start Pos
        Hand[HandNumSheet].GetComponent<CardScript>().MyX = CardX;//Card PosX
        Hand[HandNumSheet].GetComponent<CardScript>().MyY = CardY[HandNumSheet];//PosY
        Hand[HandNumSheet].transform.SetParent(CardParent.transform);//Handの子ともGameObjectであり
        //Hand[HandNumSheet].transform.parent = CardParent(this.transform);
        Hand[HandNumSheet].GetComponent<CardScript>().MyName = CardName[CardID];//CardName
        Hand[HandNumSheet].GetComponent<CardScript>().MyCost = CardCost[CardID];//CardCost
        Hand[HandNumSheet].GetComponent<CardScript>().MyComment = CardComment[CardID];//CardComment
        if (CardID < 6) {
            Hand[HandNumSheet].GetComponent<CardScript>().Monsu = Monsus[CardID];
            Hand[HandNumSheet].GetComponent<CardScript>().MonsterHP = MonsterHP[CardID];
            Hand[HandNumSheet].GetComponent<CardScript>().Moves = Monsters[CardID];
            Hand[HandNumSheet].GetComponent<CardScript>().MonsterSpeed = MonsterSpeeds[CardID];
            Hand[HandNumSheet].GetComponent<CardScript>().MonsterMagicStone = MonsterMagicStone[CardID];
        }




        Hand[HandNumSheet].GetComponent<Image>().sprite = CardImaje[CardID];





    }//カード実例


    void WitchPlayerMove() {
        FireBallSkillMove();
        if (NewInAdvanceInstallation == null)
        {
            float Y = Input.GetAxis("Horizontal3Player_2");
            //Debug.Log(Y);


            //---------`上下
            if (Y != 0 && isWitchPlayerMove&& newFireBallGameObject == null)
            {
                isWitchPlayerMove = false;
                SelecImeji = SelecImeji + -(int)Y;

                if (SelecImeji >= 5)
                {
                    SelecImeji = 0;
                }
                else if (SelecImeji < 0)
                {

                    for (int HandNum = 4; HandNum > -1; HandNum--)
                    {
                        if (Hand[HandNum] != null)
                        {
                            Debug.Log(" HandMax[HandNum]" + Hand[HandNum]);

                            SelecImeji = HandNum;
                            Debug.Log(HandNum);
                            break;
                        }
                    }
                }
                if (SelecImeji < 0 || Hand[SelecImeji] == null)
                {
                    SelecImeji = 0;
                }
                /* if (Hand[SelecImeji] == null)
                 {
                     SelecImeji = 0;
                     Debug.Log(Hand[SelecImeji]);
                 }*/
                Invoke("WitchPlayerMoveOFF", 0.1f);
            }//Hand[HandNumSheet]!=null
             //------------------------
             // Input.GetKeyDown("joystick 1 button 10")
            if (Input.GetKeyDown("joystick 2 button 2")&&newFireBallGameObject == null)
            {//カードを使用
             //  Debug.Log("カードを使用" + Hand[HandNumSheet]);
                if (Hand[SelecImeji] != null && MyMagic > Hand[SelecImeji].GetComponent<CardScript>().MyCost)
                {

                    // InAdvanceInstallation = Hand[SelecImeji].GetComponent<CardScript>().Monsu;
                    NewInAdvanceInstallation = Instantiate(InAdvanceInstallation, new Vector3(15, 5, -2), transform.rotation);

                    //  Instantiate(Monsu, new Vector3(70, 8, 5), transform.rotation);
                    /*if()
                       
                         */

                }
            }
        }
        else {
            float Z = Input.GetAxis("Horizontal3Player_2");
            NewInAdvanceInstallation.transform.position = new Vector3(NewInAdvanceInstallation.transform.position.x, NewInAdvanceInstallation.transform.position.y, NewInAdvanceInstallation.transform.position.z + Z * InAdvanceInstallationSpeed * Time.deltaTime);
            /*
            if (Input.GetKey(KeyCode.W))
            {
                NewInAdvanceInstallation.transform.position = new Vector3(NewInAdvanceInstallation.transform.position.x, NewInAdvanceInstallation.transform.position.y, NewInAdvanceInstallation.transform.position.z + InAdvanceInstallationSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                NewInAdvanceInstallation.transform.position = new Vector3(NewInAdvanceInstallation.transform.position.x, NewInAdvanceInstallation.transform.position.y, NewInAdvanceInstallation.transform.position.z - InAdvanceInstallationSpeed * Time.deltaTime);
            }*/
            if (Input.GetKeyDown("joystick 2 button 2") && !NewInAdvanceInstallation.GetComponent<IsMonsu>().isMonster) {//召喚する居場所に他のモンスターがないこと
                MyMagic = MyMagic - Hand[SelecImeji].GetComponent<CardScript>().MyCost;
                Hand[SelecImeji].GetComponent<CardScript>().MonsterStartX = NewInAdvanceInstallation.transform.position.x;
                Hand[SelecImeji].GetComponent<CardScript>().MonsterStartY = NewInAdvanceInstallation.transform.position.y;
                Hand[SelecImeji].GetComponent<CardScript>().MonsterStartZ = NewInAdvanceInstallation.transform.position.z;

                GameObject.Destroy(NewInAdvanceInstallation);
                Hand[SelecImeji].GetComponent<CardScript>().CardStart();//使用このカード

                GameObject.Destroy(Hand[SelecImeji]);//崩壊使ったのカード //CardStart

                IsHandsArray = true;//カード再さい配列
                SelecImeji--;//
                if (SelecImeji < 0) { SelecImeji = 0; }
            }

        }
        if (Hand[SelecImeji] == null)
        {
            SelectionCard.transform.position = new Vector3(CardX, 939, 0.0f);
        }
        else {
            SelectionCard.transform.position = Hand[SelecImeji].transform.position;
        }

    }//PlayerMove
    private void WitchPlayerMoveOFF() {
        isWitchPlayerMove = true;
    }
    void HandsArray()//カード配列のコントロール
    {
        if (IsHandsArray)
        {

            Debug.Log("HandsArray");
            for (int HandNum = 0; HandNum < 4; HandNum++)
            {
                Debug.Log("HandsArray++");
                Debug.Log("Hand[HandNum]" + HandNum + "is" + Hand[HandNum]);
                int HandLoadingNum = HandNum + 1;
                if (Hand[HandNum] == null)
                {
                    if (Hand[HandLoadingNum] == null) {
                        break;
                    }
                    Debug.Log("Hand[HandNum]" + HandNum + "is" + Hand[HandNum]);
                    Hand[HandNum] = Hand[HandLoadingNum];
                    Hand[HandLoadingNum] = null;
                    Hand[HandNum].GetComponent<CardScript>().MyY = CardY[HandNum];
                    if (Hand[HandNum].GetComponent<CardScript>().SpeedTime < 0.0f) { Hand[HandNum].GetComponent<CardScript>().SpeedTime = 0.5f; }
                    // Hand[HandNum].transform.position = new Vector3(CardX, CardY[HandNum]); 
                }
            }
            IsHandsArray = false;
        }

    }
    public GameObject 
        fireBallGameObject,
        newFireBallGameObject;

    private void FireBallSkillMove()
    {
        if (Input.GetKeyDown("joystick 2 button 7")&& newFireBallGameObject == null&& NewInAdvanceInstallation == null&& MyMagic>=2)
        {
            MyMagic -= 2;
            newFireBallGameObject = Instantiate(fireBallGameObject, new Vector3(15, 5, -2), new Quaternion(0, 0, 0, 1));
        }
        if (Input.GetKey("joystick 2 button 7") && newFireBallGameObject != null && NewInAdvanceInstallation == null)
        {
            newFireBallGameObject.GetComponent<FireBallSkill>().FireBallSkillChargeMove();
            float Z = Input.GetAxis("Horizontal3Player_2");
            newFireBallGameObject.transform.position = new Vector3(newFireBallGameObject.transform.position.x, newFireBallGameObject.transform.position.y, newFireBallGameObject.transform.position.z + Z * 20 * Time.deltaTime);
        }
        if (Input.GetKeyUp("joystick 2 button 7")&& newFireBallGameObject != null && NewInAdvanceInstallation == null)
        {
            newFireBallGameObject.GetComponent<FireBallSkill>().FireBallMoveStart();
            Debug.Log("A");
            newFireBallGameObject = null;
        }

    }
}
