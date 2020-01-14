using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerBatteryInstallationMove : MonoBehaviour
{

    //設置できる数
    //クルータイム
    //高い場から落ちる
    //ぶつかるものにダメージ
    //撃退
    TakeDamage takeDamage;//
    [SerializeField]
    private GameObject
         data, //データの


        instantiateInstallationBattery,//設置しようGameObject
        installationBattery;//設置しするGameObject
    [SerializeField]
    private int
        machineBatteryX = 0,
        machineBatteryZ = 0,
    machineBatteryXplusplus = 3,
   machineBatteryMaxX = -3,
        machineBatteryNumMax = 2;
    public float
        y;
    public int
         machineBatteryNum = 0;


    private void Update()
    {
        instantiateBatteryInstallationPosMove();
        if (instantiateInstallationBattery != null)
        {
            instantiateBatteryInstallationMove();


        }
    }


    public void instantiateBatteryInstallationMoveStart()
    {
        if (instantiateInstallationBattery == null)
        {
            instantiateInstallationBattery = Instantiate(data.GetComponent<GunnerData>().instantiateInstallationBattery[machineBatteryNum], new Vector3((float)machineBatteryX + machineBatteryXplusplus, 1.1f, (float)machineBatteryZ), new Quaternion(0, 0, 0, 0));
        }
        else if (instantiateInstallationBattery != null && instantiateInstallationBattery.GetComponent<IsGameObject>().isGoj == true && this.GetComponent<GunnaerHealth>().MyMagicStone >= data.GetComponent<GunnerData>().BatterybulletCost[machineBatteryNum])
        {
            this.GetComponent<GunnaerHealth>().MyMagicStone -= data.GetComponent<GunnerData>().BatterybulletCost[machineBatteryNum];
            //BatterybulletCost
            installationBattery = Instantiate(data.GetComponent<GunnerData>().InstallationBattery[machineBatteryNum], new Vector3((float)machineBatteryX + machineBatteryXplusplus, y, (float)machineBatteryZ), new Quaternion(0, 0, 0, 0));
            MachineBatteryCancel();
            installationBattery.transform.parent = GameObject.Find("InstallationBatteryBox").transform;//InstallationBatteryBoxの子ともGameObjectであり

            data.GetComponent<GunnerData>().InstallationBatteryNumer[machineBatteryNum] += 1;
            installationBattery.name = data.GetComponent<GunnerData>().InstallationBattery[machineBatteryNum].name + data.GetComponent<GunnerData>().InstallationBatteryNumer[machineBatteryNum];
        }
        else if (instantiateInstallationBattery != null && instantiateInstallationBattery.GetComponent<IsGameObject>().isGoj == true && this.GetComponent<GunnaerHealth>().MyMagicStone < data.GetComponent<GunnerData>().BatterybulletCost[machineBatteryNum])
        {
            MachineBatteryCancel();
            BatterybulletCostLack(transform);

        }


    }
    private void instantiateBatteryInstallationPosMove() {
        // Debug.Log("instantiateBatteryInstallationMove");
        //---------------kikai
        if (machineBatteryX > machineBatteryMaxX&& instantiateInstallationBattery != null)
        {
            MachineBatteryCancel();
            BatterybulletPosLack(transform);
        }
        if ((int)transform.position.x % 3 == 0)
        {
            machineBatteryX = (int)transform.position.x;
        }
        else
        {
            for (int MachineX = (int)transform.position.x; MachineX % 2 != 0; MachineX++)
            {
                //  Debug.Log(MachineX);
                if (MachineX % 3 == 0)
                {
                    machineBatteryX = MachineX;
                }

            }
        }
        if ((int)transform.position.z % 3 == 0)
        {
            machineBatteryZ = (int)transform.position.z;
        }
        else
        {
            for (int MachineZ = (int)transform.position.z; MachineZ % 2 != 0; MachineZ++)
            {
                if (MachineZ % 3 == 0)
                {
                    machineBatteryZ = MachineZ;
                    //    Debug.Log(MachineZ);

                }
            }
        }

    }
    private void instantiateBatteryInstallationMove()
    {
       
        Debug.Log("X"+machineBatteryX + "Z"+ machineBatteryZ);
        instantiateInstallationBattery.transform.position = new Vector3((float)machineBatteryX + machineBatteryXplusplus, 5, (float)machineBatteryZ);

    }
    public void MachineBatteryNumChange()
    {
        if (instantiateInstallationBattery == null) {

            machineBatteryNum++;
            machineBatteryNum = machineBatteryNum % machineBatteryNumMax;

        }
    }
    public void MachineBatteryCancel() {
        Destroy(instantiateInstallationBattery.gameObject);  // instantiateInstallationBatteryを崩壊
    }
    public void BatterybulletCostLack(Transform transform)
    {
        //  void OnTriggerEnter(Collider col)
        Debug.Log("魔石不足");

    //  gameObject = this.gameObject;
        gameObject.GetComponent<TakeDamage>().comment = "魔石不足";
     gameObject.transform.gameObject.GetComponent<TakeDamage>().Damage(transform);//ダメージ文字UI
    }
    public void BatterybulletPosLack(Transform transform)
    {
        //  void OnTriggerEnter(Collider col)
        Debug.Log("設置不可のエリアです");

        //  gameObject = this.gameObject;
        gameObject.GetComponent<TakeDamage>().comment = "設置不可のエリアです";
        gameObject.transform.gameObject.GetComponent<TakeDamage>().Damage(transform);//ダメージ文字UI
    }
    //machineBatteryMaxX
}
