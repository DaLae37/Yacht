using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneManager : MonoBehaviour
{
    public Image progressBar;

    public static string nextScene = "MainScene";

    private void Start()
    {
        StartCoroutine("LoadScene");
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(nextScene);
        asyncOperation.allowSceneActivation = false;

        float timer = 0f;

        while (!asyncOperation.isDone)
        {
            yield return null;

            timer += Time.deltaTime;

            if(asyncOperation.progress < 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, asyncOperation.progress, timer);

                if(progressBar.fillAmount >= asyncOperation.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);

                if (progressBar.fillAmount == 1.0f)
                {
                    asyncOperation.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
