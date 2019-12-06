using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerBatteryInstallationMove : MonoBehaviour
{
    [SerializeField]
    private GameObject
         data, //データの
        

        instantiateInstallationBattery,//設置しようGameObject
        installationBattery;//設置しするGameObject
    [SerializeField]
    private int
        machineBatteryX = 0,
        machineBatteryZ = 0,
    machineBatteryXplusplus=3;
    public float y;

    private void Update()
    {
        if (instantiateInstallationBattery != null)
        {
            instantiateBatteryInstallationMove();
        }
    }
    public void instantiateBatteryInstallationMoveStart()
    {
        if (instantiateInstallationBattery == null)
        {
            instantiateInstallationBattery = Instantiate(data.GetComponent<GunnerData>().instantiateInstallationBattery[0], new Vector3((float)machineBatteryX + machineBatteryXplusplus, 1.1f, (float)machineBatteryZ), new Quaternion(0, 0, 0, 0));
        }
        else if (instantiateInstallationBattery != null&& instantiateInstallationBattery.GetComponent<IsGameObject>().isGoj==true) {

            installationBattery = Instantiate(data.GetComponent<GunnerData>().InstallationBattery[0], new Vector3((float)machineBatteryX + machineBatteryXplusplus, y, (float)machineBatteryZ), new Quaternion(0, 0, 0, 0));
            Destroy(instantiateInstallationBattery.gameObject);  // instantiateInstallationBatteryを崩壊
            installationBattery.transform.parent = GameObject.Find("InstallationBatteryBox").transform;//InstallationBatteryBoxの子ともGameObjectであり

            data.GetComponent<GunnerData>().InstallationBatteryNumer[0] = data.GetComponent<GunnerData>().InstallationBatteryNumer[0] + 1;
            installationBattery.name = data.GetComponent<GunnerData>().InstallationBattery[0].name + data.GetComponent<GunnerData>().InstallationBatteryNumer[0];
        }
    }

    private void instantiateBatteryInstallationMove()
    {
       // Debug.Log("instantiateBatteryInstallationMove");
        //---------------kikai

        if ((int)transform.position.x % 3 == 0)
        {
            machineBatteryX = (int)transform.position.x;
        }
        else
        {
            for (int MachineX = (int)transform.position.x; MachineX % 3 != 0; MachineX++)
            {
              //  Debug.Log(MachineX);
                machineBatteryX = MachineX;
            }
        }
        if ((int)transform.position.z % 3 == 0)
        {
            machineBatteryZ = (int)transform.position.z;
        }
        else
        {
            for (int MachineZ = (int)transform.position.z; MachineZ % 3 != 0; MachineZ++)
            {
            //    Debug.Log(MachineZ);
                machineBatteryZ = MachineZ;
            }
        }

        instantiateInstallationBattery.transform.position = new Vector3((float)machineBatteryX + machineBatteryXplusplus, y, (float)machineBatteryZ);

    }
}
