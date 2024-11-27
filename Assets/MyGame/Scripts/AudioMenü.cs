using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class AudioMenue : MonoBehaviour
{
    // Start is called before the first frame update
 
    [SerializeField] private AudioSource myAudioSource;
 
    void Awake()
    {
        // get the Audio Source Component 
        myAudioSource = GetComponent<AudioSource>();
    }
 
    public void PlayAudio()
    {
        // AudioSource.play
        // Spiele die Audio-Source
        Debug.Log("Audio wird abgespielt");
        myAudioSource.Play();
    }
 
    public void PauseAudio()
    {
        myAudioSource.Pause();
    }

    public void StopAudio()
    {
        myAudioSource.Stop();
    }
 
}