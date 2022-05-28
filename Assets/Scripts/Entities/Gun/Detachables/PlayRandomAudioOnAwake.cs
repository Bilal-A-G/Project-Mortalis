using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomAudioOnAwake : MonoBehaviour
{
    public List<AudioClip> audioOptions;
    public AudioSource source;
    public GenericReference<bool> playAudio;

    public CachedObjectWrapper cachedObjects;

    AudioClip currentAudioClip;

    void Awake()
    {
        if (playAudio.GetValue(cachedObjects))
        {
            currentAudioClip = audioOptions[Random.Range(0, audioOptions.Count)];
            source.PlayOneShot(currentAudioClip);
        }
    }
}
