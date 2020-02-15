using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    [SerializeField]
    private Image Player_1P, Player_2P;  //240 165 90
    [SerializeField]
    private bool Player1PStart, Player2PStart;
    [SerializeField]
    private bool Player1POver, Player2POver;
    [SerializeField]
    private bool Player1PList, Player2PList;
    [SerializeField]
    private int SceneNum_MAX = 3, SceneNum_1P = 0, SceneNum_2P = 0;
    private bool Input1P, Input2P;
    // Start is called before the first frame update
    void Start()
    {
        SceneNum_MAX = 3;
        Input1P = true;
        Input2P = true;
    }
    // Update is called once per frame
    void Update()
    {//　1P 7th　 2P Horizontal3Player_2 上下　
     //  float Y = Input.GetAxis("Player_1 7th");
        Player1PMoveCO();
        Player2PMoveCO();
        SceneCO();
    
    }
    private void Player1PMoveCO()
    {//選択 1P 7th　 2P Horizontal3Player_2 上下
        float Y = Input.GetAxis("Player_1 7th");
        if (Input1P && Y != 0 && !Player1PStart && !Player1PList && !Player1POver)
        {
            Input1P = false;
            SceneNum_1P += (int)Y;
            if (SceneNum_1P > 0) { SceneNum_1P = -2; }
            SceneNum_1P = SceneNum_1P % SceneNum_MAX;
            Player_1P.transform.position = new Vector3(Player_1P.transform.position.x, 240 + SceneNum_1P * 75, Player_1P.transform.position.z);
            //複数処理防ぐ
            Invoke("Input1PON", 0.3f);
        }
        //確定
        if (Input.GetKeyDown("joystick 1 button 2")&&!Player1PStart && !Player1PList && !Player1POver)
        {
            if (SceneNum_1P == 0)
            {
                Player1PStart = true;
            }
            else if (SceneNum_1P == -1)
            {
                Player1PList = true;
            }
            else if (SceneNum_1P == -2)
            {
                Player1POver = true;
            }
            Player_1P.GetComponent<Image>().color = new Color(Player_1P.GetComponent<Image>().color.r, Player_1P.GetComponent<Image>().color.g, Player_1P.GetComponent<Image>().color.b, 255.0f / 255.0f);
            GetComponent<StartSE>().YES();
           
        }
        //キャンセル
        if (Input.GetKeyDown("joystick 1 button 1"))
        {
            if (Player1PStart || Player1PList || Player1POver) {
                Player1PStart = false;
                Player1PList = false;
                Player1POver = false;
                Player_1P.GetComponent<Image>().color = new Color(Player_1P.GetComponent<Image>().color.r, Player_1P.GetComponent<Image>().color.g, Player_1P.GetComponent<Image>().color.b, 128.0f / 255.0f);
                GetComponent<StartSE>().NO();
            }
        }
    }
    //選択できるように
    private void Input1PON()
    {
        Input1P = true;
    }
    private void Player2PMoveCO()
    {//選択 1P 7th　 2P Horizontal3Player_2 上下
        float Y = Input.GetAxis("Horizontal3Player_2");
        if (Input2P && Y != 0 && !Player2PStart && !Player2PList && !Player2POver)
        {
            Input2P = false;
            SceneNum_2P += (int)Y;
            if (SceneNum_2P > 0) { SceneNum_2P = -2; }
            SceneNum_2P = SceneNum_2P % SceneNum_MAX;
            Player_2P.transform.position = new Vector3(Player_2P.transform.position.x, 240 + SceneNum_2P * 75, Player_2P.transform.position.z);
            //複数処理防ぐ
            Invoke("Input2PON", 0.3f);
        }
        //確定
        if (Input.GetKeyDown("joystick 2 button 2") && !Player2PStart && !Player2PList && !Player2POver)
        {
            if (SceneNum_2P == 0)
            {
                Player2PStart = true;
            }
            else if (SceneNum_2P == -1)
            {
                Player2PList = true;
            }
            else if (SceneNum_2P == -2)
            {
                Player2POver = true;
            }
            Player_2P.GetComponent<Image>().color = new Color(Player_2P.GetComponent<Image>().color.r, Player_2P.GetComponent<Image>().color.g, Player_2P.GetComponent<Image>().color.b, 255.0f / 255.0f);
            GetComponent<StartSE>().YES(); //         Player_1P.GetComponent<Image>().color = new Color(0,0,0,0);
        }
        //キャンセル
        if (Input.GetKeyDown("joystick 2 button 1"))
        {
            if (Player2PStart || Player2PList || Player2POver) {
                Player2PStart = false;
                Player2PList = false;
                Player2POver = false;
                Player_2P.GetComponent<Image>().color = new Color(Player_2P.GetComponent<Image>().color.r, Player_2P.GetComponent<Image>().color.g, Player_2P.GetComponent<Image>().color.b, 128.0f / 255.0f);
                GetComponent<StartSE>().NO();
            }
        }
    }
    //選択できるように
    private void Input2PON()
    {
        Input2P = true;
    }
    private void SceneCO()
    {
        if (Player1PStart & Player2PStart) {
         //   SceneManager.LoadScene("Main");
        GetComponent<LoadSence>().currentProgress = 100;
        }
        else if (Player1PList && Player2PList) {
            SceneManager.LoadScene("List");
        }
        else if (Player1POver && Player2POver) {
            Application.Quit();
        }
    }
    //-------test
    void TESTInput()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("Main");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("Start");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Application.Quit();

        }
    }
}
