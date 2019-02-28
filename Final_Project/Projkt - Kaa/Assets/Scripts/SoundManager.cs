using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class SoundManager
{
    public string name;
    public AudioClip soundClip;

    public AudioMixerGroup mixerOutput;

    [Range(0f, 1f)] 
    public float volume;

    public float pitch = 1f;

    public bool loop = false;

    [HideInInspector]
    public AudioSource source;


}
