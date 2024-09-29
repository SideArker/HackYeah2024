using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class GlobalSound : MonoBehaviour
{
    public static GlobalSound Instance;
    [SerializeField] static Transform audioSourcesParent;

    public static Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();
    [SerializeField] private AudioClip[] sounds;

    private static List<AudioSource> _audioSources = new List<AudioSource>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        audioSourcesParent = gameObject.GetComponentInChildren<Transform>();
        SoundsToDictionary();
    }

    private void SoundsToDictionary()
    {
        foreach (var sound in sounds)
        {
            clips.Add(sound.name, sound);
        }
    }

    public static void PlayMusic(string clipName, bool loop = false, float volume = 1f)
    {
        Transform audio = audioSourcesParent.Find(clipName);
        AudioSource audioSource;
        
        if (audio == null)
        { 
            GameObject newAudioSource = new GameObject(clipName);
            newAudioSource.gameObject.AddComponent<AudioSource>();
            newAudioSource.transform.parent = audioSourcesParent;
            audio = newAudioSource.transform;
            audioSource = audio.GetComponent<AudioSource>();
            _audioSources.Add(audioSource);
        }
        else
        {
            audioSource = audio.GetComponent<AudioSource>();
        }
        audioSource.clip = clips[clipName];
        audioSource.loop = loop;
        audioSource.volume = volume;
        audioSource.Play();

    }

    public static AudioSource GetMusicAudioSource(string clipName)
    {
        return _audioSources.Find(x => x.clip.name == clipName);
    }
    
    public static void StopAllMusic()
    {
        foreach (var audio in _audioSources)
        {
            audio.Stop();
        }
    }
    
    public static void StopMusic(string clipName)
    {
        GetMusicAudioSource(clipName).Stop();
    }

    public static void PauseAllMusic(bool state)
    {
        foreach (var source in _audioSources)
        {
            if (state)
            {
                source.Pause();
            }
            else
            {
                source.UnPause();
            }
        }
    }

    public static void PauseMusic(string clipName, bool state)
    {
        if (state)
        {
            GetMusicAudioSource(clipName).Pause();
        }
        else
        {
            GetMusicAudioSource(clipName).UnPause();
        }
    }
}
