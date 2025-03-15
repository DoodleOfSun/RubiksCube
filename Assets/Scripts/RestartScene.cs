using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{

    public void Restart()
    {
        StartCoroutine(SceneLoading());
    }

    private IEnumerator SceneLoading()
    {

        AsyncOperation ao = SceneManager.LoadSceneAsync("SampleScene");

        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            if (ao.progress >= 0.9f)
            {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }
    }

}
