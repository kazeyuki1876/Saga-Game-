using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ststberuhontai : MonoBehaviour
{
public int MyHp = 100;

   public void IsDIe()
    {
        if (MyHp <= 0)
        {


            Destroy(this.gameObject, 0.1f);
        }
    }

}
