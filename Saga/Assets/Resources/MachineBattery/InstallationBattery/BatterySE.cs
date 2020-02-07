using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterySE : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip[] SE = new AudioClip[2];
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    //GUNSE
    public void GunSE()
    {
      
        audioSource.PlayOneShot(SE[0]);
    }

    public void DieSE()
    {
       
        audioSource.PlayOneShot(SE[1]);
    }

}
