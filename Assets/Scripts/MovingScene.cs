using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovingNextScene()
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
