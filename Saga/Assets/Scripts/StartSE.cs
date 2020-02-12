using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSE : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] SE = new AudioClip[2];

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void YES()
    {

        audioSource.PlayOneShot(SE[0]);
    }

    public void NO()
    {

        audioSource.PlayOneShot(SE[1]);
    }
}

