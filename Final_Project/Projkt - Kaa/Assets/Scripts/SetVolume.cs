using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
   
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
