using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private const string PLAYER_PREFS_SOUND_VOLUME = "SoundVolume";
    
    public Sound[] sounds;

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_VOLUME, 1);
    }

    private void Start()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_VOLUME);

            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        
        s.source.Play();
    }

    public void SetVolume()
    {
        if (PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_VOLUME) == 1f)
        {
            OffSounds();
            SettingsData.Instance.SetSound();
        }
        else
        {
            OnSounds();
            SettingsData.Instance.SetSound();
        }
    }

    private void OffSounds()
    {
        PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_VOLUME, 0f);

        foreach (Sound s in sounds)
        {
            if (s.name == "Theme")
            {
                continue;
            }
            else
            {
                s.source.volume = s.volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_VOLUME);
            }
        }
    }
    
    private void OnSounds()
    {
        PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_VOLUME, 1f);

        foreach (Sound s in sounds)
        {
            if (s.name == "Theme")
            {
                continue;
            }
            else
            {
                s.source.volume = s.volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_VOLUME);
            }
        }
    }

    public bool GetSound()
    {
        if (PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_VOLUME) == 1f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
