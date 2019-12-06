using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerMoveController : MonoBehaviour
{
    /// <summary>
    /// このスクリプトはキー入力だけと動きだけ
    /// </summary>
    [SerializeField] private float seppt = 5;
    //周り速度
    [SerializeField] private float aroundSeppt = 5;
    [SerializeField]
    private float RotateSpeed = 0.2f;

    //----------狙えサポート aim
    public bool isShootingSupport;　//今の狙えてるモンスターあるか
    private GameObject nearObj;         //最も近いオブジェクト
    private float searchTime = 0;    //経過時間       
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト
        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;
    }//-----------//----------狙えサポート

    private void Update()
    {
        GunnerMOVE();//キー入力
    }

    private void ShootingSupport()
    {//isShootingSupport 射撃サポート
     //経過時間を取得
        if (isShootingSupport)
        {
            searchTime += Time.deltaTime;

            if (searchTime >= 0.3f)
            {
                //最も近かったオブジェクトを取得
                nearObj = serchTag(gameObject, "Monster");

                //経過時間を初期化
                searchTime = 0;
            }

            //対象の位置の方向を向く
            if (nearObj != null)
            {

                transform.LookAt(nearObj.transform);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            }

            //自分自身の位置から相対的に移動する
            //transform.Translate(Vector3.forward * 0.01f);
        }
    }

    private void GunnerMOVE()
    {
        //移動

        if (isShootingSupport 
            //&& nearObj != null//これでもっといいがな
            )
        {
            ShootingSupport();
            if (Input.GetKey("up"))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * seppt);
                //transform.Translate(Vector3.forward * Time.deltaTime * Seppt, Space.Self);
            }
            else if (Input.GetKey("down"))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * (-seppt * 0.75f));
                // transform.Translate(Vector3.forward * Time.deltaTime * (-Seppt * 0.75f), Space.Self);
            }
            if (Input.GetKey("right"))
            {
                transform.position = new Vector3(transform.position.x + Time.deltaTime * seppt, transform.position.y, transform.position.z);
                // transform.Translate(Vector3.right * Time.deltaTime * Seppt, Space.Self);
            }
            else if (Input.GetKey("left"))
            {
                transform.position = new Vector3(transform.position.x + Time.deltaTime * -seppt, transform.position.y, transform.position.z);
                //    transform.Translate(Vector3.right * Time.deltaTime * -Seppt, Space.Self);
            }



        }
        else
        {

            
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            
            transform.position += new Vector3(x * seppt, 0, y * seppt);

            if (Input.GetKeyDown("joystick button 10")) {
                gameObject.transform.position += Vector3.up * seppt;
            }


/*

            float KeyVertical = Input.GetAxis("R3X");
            float KeyHorizontal = Input.GetAxis("R3Y");
            Vector3 newDir = new Vector3(KeyHorizontal, 0, KeyVertical).normalized;
            transform.forward = Vector3.Lerp(transform.forward, newDir, RotateSpeed);


            if (Input.GetKeyDown("joystick button 11"))
            {


                transform.Translate(Vector3.forward * Time.deltaTime * seppt, Space.Self);
            }
        /*
        if (Input.GetKey("up"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * seppt, Space.Self);
        }
        else if (Input.GetKey("down"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * (-seppt * 0.75f), Space.Self);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(0, aroundSeppt, 0, Space.World);
        }
        else if (Input.GetKey("left"))
        {
            transform.Rotate(0, -aroundSeppt, 0, Space.World);
        }*/
        }
        //射撃
        if (Input.GetKey(KeyCode.Z))
        {
            this.GetComponent<GunnerShootingMoveController>().GunsMoveStart();           /*
            if (IsTrigger)
            {
                IsTrigger = false;
                for (int Moves = 0; Moves < BulletS[GunsNum]; Moves++)
                {
                    GunsMOVE();

                    Invoke("GunTriggerMove", BulletLimit[GunsNum]);
                }


            }
            */
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
           // Debug.Log("instantiateInstallationBattery");
            this.GetComponent<GunnerBatteryInstallationMove>().instantiateBatteryInstallationMoveStart();
        }
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (isShootingSupport)
            {
                isShootingSupport = false;
            }
            else
            {
                isShootingSupport = true;
            }


        }
        
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("V");
            this.GetComponent<GunnerShootingMoveController>().GunsChange();
        }

    }


    /*
     koko
     https://hakonebox.hatenablog.com/entry/2018/04/15/125152
     https://blog.csdn.net/Architet_Yang/article/details/77938930
     ]https://blog.csdn.net/zqckzqck/article/details/73172479
     https://blog.csdn.net/lengyoumo/article/details/91386404
     https://blog.csdn.net/qq_26074263/article/details/79765082
     
     */
}
