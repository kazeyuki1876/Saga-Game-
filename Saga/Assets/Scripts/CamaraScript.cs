using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamaraScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            SceneManager.LoadScene("OVER");
        }
    }
    /*
    // Start is called before the first frame update
    public GameObject objectToFollow;

    public float speed = 2.0f;

    void Update()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 position = this.transform.position;
        //Debug.Log(objectToFollow.transform.position.x);
        //position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y, interpolation);
        if (objectToFollow.transform.position.x > -10.0f&& objectToFollow.transform.position.x < 10.0f) {
            position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);
      

        }
        if (objectToFollow.transform.position.z > -10.0f && objectToFollow.transform.position.z < 10.0f)
        {
            position.z = Mathf.Lerp(this.transform.position.z, objectToFollow.transform.position.z - 50.0f, interpolation);
        }

            this.transform.position = position;

    }*/

}
