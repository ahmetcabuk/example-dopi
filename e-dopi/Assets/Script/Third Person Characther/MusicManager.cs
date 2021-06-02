using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    [HideInInspector]
    public AudioSource audioSource;

    [Header("Musics")]
    public List<AudioClip> musicsList;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        //audioSource.loop = true;
        //audioSource.Play()
    }

    //private void Start()
    //{
    //    var randomIndex = Random.Range(0, musicsList.Count - 1);

    //    audioSource.clip = musicsList[randomIndex];

    //}

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayMusic();
        }
    }

    private void PlayMusic()
    {
        var randomIndex = Random.Range(0, musicsList.Count - 1);

        audioSource.clip = musicsList[randomIndex];
        audioSource.Play();
    }

    //public void PlayAudio(AudioClip audioClip, float volume = 1, float pitch = 1, float spatialBlend = 1)
    //{
    //    audioSource.spatialBlend = spatialBlend;
    //    audioSource.pitch = pitch;
    //    audioSource.PlayOneShot(audioClip, volume);
    //}
}