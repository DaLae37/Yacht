using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    public void GameSceneButton()
    {
        LoadingSceneManager.LoadScene("GameScene");
    }

    public void SettingSceneButton()
    {
        LoadingSceneManager.LoadScene("SettingScene");
    }
}
