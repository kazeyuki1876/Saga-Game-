using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class OutTime : MonoBehaviour
{

    public static string score;
    public float GameTime;

    public float gameTimeMax = 180;
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
        Time.timeScale = 0.1f;
        GameObject.Find("Gunner").GetComponent<GunnerMoveController>().enabled = false;
        GameObject.Find("WitchUI").GetComponent<WitchUIScript>().enabled = false;
        
        Invoke("EndMmove", 1.0f);
    }
    public void EndMmove() {

        if (GameTime >= 0)
        {
            SceneManager.LoadScene("WitchOver");
        }
        else
        {
            SceneManager.LoadScene("GunnerOver");
        }
    }






    private float fillAmountSpeed = 5;
    private float[]color0 =  new float[] { 1.0f, 1.0f, 0 };
    private float[] colorEnd = new float[] { 1, 0, 0.1f };
    public float[] testcolor = new float[] { 0, 0, 0, 0, 0, 0 };

    void CastleHPGaugeMove()
    {
        GameTime -= Time.deltaTime;
        GameTimeUi.text = "REMAINING TINME:" + (int)GameTime;
         if (gameTimeImage.fillAmount != GameTime / gameTimeMax)
        {
            //  Debug.Log(GannerMagicStoneGauge.fillAmount + "       " + MyMagicStone / MyMagicStoneMax);
            float gameTimeImageSpeed = gameTimeImage.fillAmount - GameTime / gameTimeMax;
            gameTimeImage.fillAmount = gameTimeImage.fillAmount - gameTimeImageSpeed * fillAmountSpeed * Time.deltaTime;
        }

  
            gameTimeImage.GetComponent<Image>().color = new Vector4(gameTimeImage.color.r, 1 * GameTime / gameTimeMax, gameTimeImage.color.b, 255 / 255);
        


        testcolor[0] = color0[0];
        testcolor[1] = color0[1];
        testcolor[2] = color0[2];
        testcolor[3] = colorEnd[0];
        testcolor[4] = colorEnd[1];
        testcolor[5] = colorEnd[2];

        //13 255 0) 
        //255 0 9

    }
}
