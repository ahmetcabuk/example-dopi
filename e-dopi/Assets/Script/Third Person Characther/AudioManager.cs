using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    [HideInInspector]
    public AudioSource audioSource;
    [HideInInspector]
    public AudioSource musicSource;
    public AudioMixer mainMixer;
    public AudioMixerGroups sFXMixer;
    public AudioMixerGroups musicMixer;

    [Header("Mute")]
    public bool mainMute;
    public bool sFXMute;
    public bool musicMute;

    private Dictionary<AudioKeys, AudioClip> audioClips = new Dictionary<AudioKeys, AudioClip>();

    private void Awake()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        musicSource = transform.GetChild(0).GetComponent<AudioSource>();
        GetAudioData();
    }

    private void Start()
    {
        PlayMusic(AudioKeys.SynapseMusic,.05f);
    }

    private void Update()
    {
        if (mainMute)
        {
            mainMixer.SetFloat("Master", -80);
        }
        else
        {
            mainMixer.SetFloat("Master", 0);
        }

        if (sFXMute)
        {
            mainMixer.SetFloat("SFX", -80);
        }
        else
        {
            mainMixer.SetFloat("SFX", 0);
        }

        if (musicMute)
        {
            mainMixer.SetFloat("Music", -80);
        }
        else
        {
            mainMixer.SetFloat("Music", 0);
        }
    }

    private void GetAudioData()
    {
        AudioData data = Resources.LoadAll<AudioData>(string.Empty)[0];
        
        foreach (var item in data.sounds)
        {
            audioClips.Add(item.key, item.value);
        }
    }

    public void PlaySFX2D(AudioKeys key, float volume = 1, float pitch = 1)
    {
        audioSource.spatialBlend = 0;
        audioSource.pitch = pitch;
        audioSource.PlayOneShot(audioClips[key], volume);
    }

    //public void PlaySFX3D(AudioClip audioClip, Vector3 soundPosition, float volume = 1, float pitch = 1, float spatialBlend = 1)
    //{
    //    GameObject temp3DAudioGameObject = new GameObject();
    //    temp3DAudioGameObject.name = audioClip.name + "_Audio";
    //    AudioSource tempAudioSource = temp3DAudioGameObject.AddComponent<AudioSource>();
    //    tempAudioSource.transform.position = soundPosition;
    //    //set Audio source settings MixerGroup SFX

    //    audioSource.spatialBlend = spatialBlend;
    //    audioSource.pitch = pitch;
    //    audioSource.PlayOneShot(audioClip, volume);
    //}

    public void PlayMusic(AudioKeys key, float volume = 1)
    {
        musicSource.PlayOneShot(audioClips[key], volume);
    }

    public void MuteSFXMixer()
    {
        mainMixer.SetFloat("SFX", -80);
    }

    public void UnMuteSFXMixer()
    {
        mainMixer.SetFloat("SFX", 0);
    }

    public void MuteMusicMixer()
    {
        mainMixer.SetFloat("Music", -80);
    }

    public void UnMuteMusicMixer()
    {
        mainMixer.SetFloat("Music", 0);
    }
}
