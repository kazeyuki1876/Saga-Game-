
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSence : MonoBehaviour
{


    public int currentProgress; //当前
    public int targetProgress;  //目标



    private void Start()
    {
        currentProgress = 0;
        targetProgress = 0;
     
        StartCoroutine(LoadingScene());
    }

    
    private IEnumerator LoadingScene()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Main");
        asyncOperation.allowSceneActivation = false;                        
        while (asyncOperation.progress < 0.9f)                               
        {
            targetProgress = (int)(asyncOperation.progress * 100);
        }
        targetProgress = 100; 
        yield return LoadProgress();
        asyncOperation.allowSceneActivation = true; 
    }
 
    private IEnumerator<WaitForEndOfFrame> LoadProgress()
    {
        while (currentProgress < targetProgress) //进度 < 目标
        {
            yield return new WaitForEndOfFrame();    
        }
    }
}