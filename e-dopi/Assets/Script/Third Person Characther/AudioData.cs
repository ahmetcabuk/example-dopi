using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AudioData")]
public class AudioData : ScriptableObject
{
    public List<AudioBase> sounds = new List<AudioBase>();
}

[System.Serializable]
public class AudioBase
{
    public AudioKeys key;
    public AudioClip value;
}

public enum AudioKeys
{
    FootStepShort,
    FootStepLong,
    Error,
    Success,
    SynapseMusic
}

public enum AudioMixerGroups
{
    SFX,
    Music
}


