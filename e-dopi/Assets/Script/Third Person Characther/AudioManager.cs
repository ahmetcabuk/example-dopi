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
    

    [Header("Mute")]
    public bool mainMute;
    public bool sFXMute;
    public bool musicMute;

    private Dictionary<AudioKeys, AudioClip> audioClips = new Dictionary<AudioKeys, AudioClip>();
    private Dictionary<MusicKeys, AudioClip> musicClips = new Dictionary<MusicKeys, AudioClip>();
    
    private void Awake()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        musicSource = transform.GetChild(0).GetComponent<AudioSource>();
        GetAudioData();
    }

    private void Start()
    {
        PlayMusic(MusicKeys.Synapse,.05f);
    }

    private void Update()
    {
        if (mainMute)
        {
            MuteMasterMixer();
        }
        else
        {
            UnMuteMasterMixer();
        }

        if (sFXMute)
        {
            MuteSFXMixer();
        }
        else
        {
            UnMuteSFXMixer();
        }

        if (musicMute)
        {
            MuteMusicMixer();
        }
        else
        {
            UnMuteMusicMixer();
        }
    }
    
    private void GetAudioData()
    {
        AudioData data = Resources.LoadAll<AudioData>(string.Empty)[0];
        
        foreach (var item in data.sounds)
        {
            audioClips.Add(item.key, item.value);
        }

        foreach (var item in data.musics)
        {
            musicClips.Add(item.key, item.value);
        }
    }

    #region Play Clips
    public void PlaySFX2D(AudioKeys key, float volume = 1, float pitch = 1)
    {
        audioSource.spatialBlend = 0;
        audioSource.pitch = pitch;
        audioSource.PlayOneShot(audioClips[key], volume);
    }

    public void PlaySFX3D(AudioKeys key, Vector3 soundPosition, float volume = 1, float pitch = 1, float spatialBlend = 1)
    {
        GameObject temp3DAudioGameObject = new GameObject();
        temp3DAudioGameObject.name = audioClips[key].name + "_Audio";
        AudioSource tempAudioSource = temp3DAudioGameObject.AddComponent<AudioSource>();
        tempAudioSource.transform.position = soundPosition;
        tempAudioSource.clip = audioClips[key];
        float audioClipLenght = audioClips[key].length;
        audioSource.spatialBlend = spatialBlend;
        audioSource.pitch = pitch;
        audioSource.PlayOneShot(audioClips[key], volume);

        StartCoroutine(DestroySoundGameObject(temp3DAudioGameObject, audioClipLenght + 0.1f));
    }

    private IEnumerator DestroySoundGameObject(GameObject objectToDestroy, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(objectToDestroy);
    }

    public void PlayMusic(MusicKeys key, float volume = 1, bool loop = true)
    {
        musicSource.loop = loop;
        musicSource.PlayOneShot(musicClips[key], volume);
    }
    #endregion

    #region Mute
    public void MuteMasterMixer()
    {
        mainMixer.SetFloat("Master", -80);
    }

    public void UnMuteMasterMixer()
    {
        mainMixer.SetFloat("Master", 0);
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
    #endregion
}
