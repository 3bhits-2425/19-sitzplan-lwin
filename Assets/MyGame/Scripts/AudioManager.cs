using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make sure the class is serializable so it appears in the Unity Inspector
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume = 1f;
    [Range(0.1f, 3f)]
    public float pitch = 1f;
    [HideInInspector]
    public AudioSource audioSource;
}

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;

    // Singleton instance
    private static AudioManager instance;

    void Awake()
    {
        // Ensure there's only one AudioManager instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        // Initialize audio sources for each sound
        foreach (Sound oneSound in sounds)
        {
            oneSound.audioSource = gameObject.AddComponent<AudioSource>();
            oneSound.audioSource.clip = oneSound.clip;
            oneSound.audioSource.volume = oneSound.volume;
            oneSound.audioSource.pitch = oneSound.pitch;
        }
    }

    public void Play(string soundName)
    {
        Sound sound = FindSound(soundName);
        if (sound != null)
        {
            sound.audioSource.Play();
        }
    }

    public void Pause(string soundName)
    {
        Sound sound = FindSound(soundName);
        if (sound != null)
        {
            sound.audioSource.Pause();
        }
    }

    private Sound FindSound(string soundName)
    {
        foreach (Sound oneSound in sounds)
        {
            if (oneSound.name == soundName)
            {
                return oneSound;
            }
        }
        Debug.LogWarning($"Sound '{soundName}' not found!");
        return null;
    }
}
