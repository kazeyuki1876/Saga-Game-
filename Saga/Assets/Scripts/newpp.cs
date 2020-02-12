using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class newpp : MonoBehaviour
{

    public bool Botantest;
    private void Update()
    {

        if (Botantest)
        {
            if (Input.GetKeyDown("joystick 2 button 0"))
            {
                Debug.Log("button0");
            }
            if (Input.GetKeyDown("joystick 2 button 1"))
            {
                Debug.Log("button1");
            }
            if (Input.GetKeyDown("joystick 2 button 2"))
            {
                Debug.Log("button2");
            }
            if (Input.GetKeyDown("joystick 2 button 3"))
            {
                Debug.Log("button3");
            }
            if (Input.GetKeyDown("joystick 2 button 4"))
            {
                Debug.Log("button4");
            }
            if (Input.GetKeyDown("joystick 2 button 5"))
            {
                Debug.Log("button5");
            }
            if (Input.GetKeyDown("joystick 2 button 6"))
            {
                Debug.Log("button6");
            }
            if (Input.GetKeyDown("joystick 2 button 7"))
            {
                Debug.Log("button7");
            }
            if (Input.GetKeyDown("joystick 2 button 8"))
            {
                Debug.Log("button8");
            }
            if (Input.GetKeyDown("joystick 2 button 9"))
            {
                Debug.Log("button9");
            }
            if (Input.GetKeyDown("joystick 2 button 10"))
            {
                Debug.Log("button10");
            }
            if (Input.GetKeyDown("joystick 2 button 11"))
            {
                Debug.Log("button11");
            }
            if (Input.GetKeyDown("joystick 1 button 0"))
            {
                Debug.Log("button0");
            }
            if (Input.GetKeyDown("joystick 1 button 1"))
            {
                Debug.Log("button1");
            }
            if (Input.GetKeyDown("joystick 1 button 2"))
            {
                Debug.Log("button2");
            }
            if (Input.GetKeyDown("joystick 1 button 3"))
            {
                Debug.Log("button3");
            }
            if (Input.GetKeyDown("joystick 1 button 4"))
            {
                Debug.Log("button4");
            }
            if (Input.GetKeyDown("joystick 1 button 5"))
            {
                Debug.Log("button5");
            }
            if (Input.GetKeyDown("joystick 1 button 6"))
            {
                Debug.Log("button6");
            }
            if (Input.GetKeyDown("joystick 1 button 7"))
            {
                Debug.Log("button7");
            }
            if (Input.GetKeyDown("joystick 1 button 8"))
            {
                Debug.Log("button8");
            }
            if (Input.GetKeyDown("joystick 1 button 9"))
            {
                Debug.Log("button9");
            }
            if (Input.GetKeyDown("joystick 1 button 10"))
            {
                Debug.Log("button10");
            }
            if (Input.GetKeyDown("joystick 1 button 11"))
            {
                Debug.Log("button11");
            }
            float hori = Input.GetAxis("Horizontal");
            float vert = Input.GetAxis("Vertical");
            if ((hori != 0) || (vert != 0))
            {
                //      Debug.Log("stick:" + hori + "," + vert);
            }
        }
    }


}




