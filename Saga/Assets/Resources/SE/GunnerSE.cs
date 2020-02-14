using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerSE : MonoBehaviour
{
    AudioSource GunnerSEaudioSource;
    public AudioClip []GunSE;
    void Start()
    {
        //Componentを取得
        GunnerSEaudioSource = GetComponent<AudioSource>();
    }

    //GUNSE
    public void GunSE1() {
        GunnerSEaudioSource.volume = 0.2f;
        GunnerSEaudioSource.pitch = 1f;
        GunnerSEaudioSource.PlayOneShot(GunSE[Random.Range(0,4)]);
    }
    public void GunSE2()
    {
        GunnerSEaudioSource.volume = 0.2f;
        GunnerSEaudioSource.pitch = 0.8f;
        GunnerSEaudioSource.PlayOneShot(GunSE[Random.Range(5, 8)]);
    }

    //装填
    public void ReloadStart() {
        GunnerSEaudioSource.volume = 0.3f;
        GunnerSEaudioSource.pitch = 1f;
        GunnerSEaudioSource.PlayOneShot(GunSE[9]);
    }
    public void ReloadEnd() {
        GunnerSEaudioSource.volume = 0.5f;
        GunnerSEaudioSource.pitch = 1f;
        GunnerSEaudioSource.PlayOneShot(GunSE[8]);
    }
    //ロケット
    public void Down()
    {
        GunnerSEaudioSource.volume = 0.5f;
        GunnerSEaudioSource.pitch = 1f;
        GunnerSEaudioSource.PlayOneShot(GunSE[10]);
    }
}


//スキル

//回復スキル

