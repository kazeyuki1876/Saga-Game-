using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class OutTime : MonoBehaviour
{
    public float GameTime = 180;
    [SerializeField]
    private Text GameTimeUi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameTime -= Time.deltaTime;
        GameTimeUi.text = "残り" + (int)GameTime;
        if (GameTime <= 0) {
            GameEnd();
        }
    }
  public  void GameEnd() {
        if (GameTime >= 0) {
            SceneManager.LoadScene("WitchOver");
        }
        else {
            SceneManager.LoadScene("GunnerOver");
        }

    }
}
