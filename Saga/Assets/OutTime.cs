using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class OutTime : MonoBehaviour
{
    [SerializeField]
    private float GameTime;
    [SerializeField]
    private float gameTimeMax = 180;
    [SerializeField]
    private Text GameTimeUi;
    [SerializeField]
    private Image gameTimeImage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CastleHPGaugeMove();
        if (GameTime <= 0) {
            GameEnd();
        }


        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("Main");
        }
    }
    public void GameEnd() {
        if (GameTime >= 0) {
            SceneManager.LoadScene("WitchOver");
        }
        else {
            SceneManager.LoadScene("GunnerOver");
        }

    }
    private float fillAmountSpeed = 5;
    private float[]color0 =  new float[] { 13, 255, 1 };
    private float[] colorEnd = new float[] { 255, 1, 9 };

    void CastleHPGaugeMove()
    {
        GameTime -= Time.deltaTime;
        GameTimeUi.text = "REMAINING TINME" + (int)GameTime;
        gameTimeImage.GetComponent<Image>().color = new Vector4(color0[0] / 255.0f, color0[1] / 255.0f, color0[2] / 255.0f, 255 / 255);
        if (gameTimeImage.fillAmount != GameTime / gameTimeMax)
        {
            //  Debug.Log(GannerMagicStoneGauge.fillAmount + "       " + MyMagicStone / MyMagicStoneMax);
            float gameTimeImageSpeed = gameTimeImage.fillAmount - GameTime / gameTimeMax;
            gameTimeImage.fillAmount = gameTimeImage.fillAmount - gameTimeImageSpeed * fillAmountSpeed * Time.deltaTime;
            for (int i = 0; i < 2; i++) {
                if (color0[i] != colorEnd[i])
                {
                    float color0fillAmountSpeed = color0[i]/255.0f - color0[i] / colorEnd[i];
                    color0[i] = color0[i] - color0fillAmountSpeed *5 * Time.deltaTime;
                }


            }
           
          
            //13 255 0) 
            //255 0 9

        }
    }
}
