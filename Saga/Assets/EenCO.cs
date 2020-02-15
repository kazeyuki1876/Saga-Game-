using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EenCO : MonoBehaviour
{
    private float upSpeed = 500;
    public float upPosYMAX = 10000;
    public GameObject thanksImage;//アセット
    public Image endImage;//thanks　you for playing
    private bool isendImageColorAUp;
    void Update()
    {//タイム修正
        if (Time.timeScale != 1.0f) {
            Time.timeScale = 1.0f;
            Debug.Log("タイム速度を修正しました。");
        }
        StartGO();
        ThanksImageMoveSpeedUp();
        ThanksImageMove();
        EndImageColorAUpMove();
    }
    //加速
    void ThanksImageMoveSpeedUp() {
        if (Input.GetKey("joystick 1 button 2") || Input.GetKey("joystick 2 button 2"))
        {
            upSpeed = 1500;
        }
        else {
            upSpeed = 500;
        }
    }//シーン転移
    void StartGO()
    {
        if (Input.GetKeyDown("joystick 1 button 8") || Input.GetKeyDown("joystick 2 button 8"))
        {
            SceneManager.LoadScene("Start");
        }
    }//アセット上げ
    void ThanksImageMove() {
        if (thanksImage.transform.position.y < upPosYMAX)
        {
            thanksImage.transform.position = new Vector3(thanksImage.transform.position.x, thanksImage.transform.position.y + upSpeed * Time.deltaTime, 0);
        }
        else {
            isendImageColorAUp = true;
        }
    }//
    void EndImageColorAUpMove() {
        if (isendImageColorAUp) {
            endImage.color = new Color(endImage.color.r, endImage.color.g, endImage.color.b, endImage.color.a + Time.deltaTime * 0.2f);
        }
       
    }

}
