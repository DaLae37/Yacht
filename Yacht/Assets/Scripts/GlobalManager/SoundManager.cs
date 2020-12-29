using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    private AudioSource audioSource;

    public AudioClip backgroundSound;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundSound;

        audioSource.volume = 1.0f;
        audioSource.loop = true;
        audioSource.mute = false;

        audioSource.Play();
    }

    public float getVolume()
    {
        return audioSource.volume;
    }

    public void setVolume(float volume)
    {
        audioSource.volume = volume;
    }    
}
