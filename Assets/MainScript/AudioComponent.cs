using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioComponent : MonoBehaviour
{
    public AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Play(AudioClip clip)
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
    }
    void Update()
    {
        if(audioSource.isPlaying == false)
        {
            AudioManager.instance.RetrunPool(gameObject);
        }
    }
}
