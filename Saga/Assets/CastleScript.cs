using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CastleScript : MonoBehaviour
{
    public int MyHp;
    public Text CastleHP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CastleHP.text = "CastleHP" + MyHp;
    }
    public void IsOVER() {
        if (MyHp <= 0) { SceneManager.LoadScene("OVER"); }
       
    }
}
