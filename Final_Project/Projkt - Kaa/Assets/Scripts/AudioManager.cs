using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System;
using UnityEngine;


// video time 10:15

public class AudioManager : MonoBehaviour
{
    public SoundManager[] sounds;
    public static AudioManager instance;

    private bool isGameScene;

    // Start is called before the first frame update
    void Awake()
    {
        isGameScene = false;

        if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

        foreach (SoundManager s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.soundClip;
            s.source.outputAudioMixerGroup = s.mixerOutput;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        PlaySound("IntroMusic");  
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameSceneDay" && !isGameScene)
        {
            isGameScene = true;
            StopSound("IntroMusic");
            PlaySound("Main");
        }
        if (    (       SceneManager.GetActiveScene().name == "StartScene" 
                    ||  SceneManager.GetActiveScene().name == "Player1Win"
                    ||  SceneManager.GetActiveScene().name == "Player2Win"
                    ||  SceneManager.GetActiveScene().name == "GameSceneGalaxy"
                )
                    && isGameScene)
        {
            isGameScene = false;
            StopSound("Main");
            PlaySound("IntroMusic");
        }
    }

    public void PlaySound(string sound)
	{
		SoundManager s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}
		s.source.Play();
	}

    public void StopSound(string sound)
    {
        SoundManager s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}
		s.source.Stop();
    }
}
