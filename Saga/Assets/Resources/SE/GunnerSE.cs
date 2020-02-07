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
        GunnerSEaudioSource.pitch = 1.8f;
        GunnerSEaudioSource.PlayOneShot(GunSE[Random.Range(0,3)]);
    }

    public void GunSE2()
    {
        GunnerSEaudioSource.pitch = 0.8f;
        GunnerSEaudioSource.PlayOneShot(GunSE[Random.Range(3, 5)]);
    }
}
