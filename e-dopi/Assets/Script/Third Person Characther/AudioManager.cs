using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager>
{
    [HideInInspector]
    public AudioSource audioSource;

    [Header("SFX")]
    public AudioClip success;
    public AudioClip fail;
    public AudioClip footStepShort;
    public AudioClip footStepLong;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioClip audioClip, float volume = 1, float pitch = 1, float spatialBlend = 0)
    {
        audioSource.spatialBlend = spatialBlend;
        audioSource.pitch = pitch;
        audioSource.PlayOneShot(audioClip, volume);
    }
}
