using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AudioData")]
public class AudioData : ScriptableObject
{
    public List<AudioBase> sounds = new List<AudioBase>();
    public List<MusicBase> musics = new List<MusicBase>();
}

[System.Serializable]
public class AudioBase
{
    public AudioKeys key;
    public AudioClip value;
}

[System.Serializable]
public class MusicBase
{
    public MusicKeys key;
    public AudioClip value;
}

public enum AudioKeys
{
    FootStepShort,
    FootStepLong,
    Error,
    Success
}

public enum MusicKeys
{
    Synapse
}

public enum AudioMixerGroups
{
    SFX,
    Music
}


