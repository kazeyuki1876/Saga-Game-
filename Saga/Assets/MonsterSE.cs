using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSE : MonoBehaviour
{
    AudioSource AudioSource;
    public AudioClip[] Source;
    // Start is called before the first frame update
    void Start()
    {
       // Componentを取得
        AudioSource = GetComponent<AudioSource>();
    }
    public void MonsterSE1()
    {
        AudioSource.volume = 0.2f;
        AudioSource.pitch = 1f;
        AudioSource.PlayOneShot(Source[0]);
    }
    public void MonsterSE2()
    {
        AudioSource.volume = 0.2f;
        AudioSource.pitch = 1f;
        AudioSource.PlayOneShot(Source[1]);
    }

}
