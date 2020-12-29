using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSceneManager : MonoBehaviour
{
    public Slider Volume;

    public GameObject Sound;
    public GameObject WebGL;
    public GameObject Nanum;

    private void Start()
    {
        Volume.value = GameObject.Find("SoundManager").GetComponent<SoundManager>().getVolume();
    }

    public void MainSceneButton()
    {
        LoadingSceneManager.LoadScene("MainScene");
    }

    public void SoundButton()
    {
        Sound.SetActive(true);
        WebGL.SetActive(false);
        Nanum.SetActive(false);
    }

    public void WebGLButton()
    {
        Sound.SetActive(false);
        WebGL.SetActive(true);
        Nanum.SetActive(false);
    }

    public void NanumButton()
    {
        Sound.SetActive(false);
        WebGL.SetActive(false);
        Nanum.SetActive(true);
    }

    public void ChangeVolume()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().setVolume(Volume.value);
    }
}
