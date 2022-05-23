using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomAudioOnAwake : MonoBehaviour
{
    public GenericReference<List<AudioClip>> audioOptions;
    public GenericReference<bool> condition;
    public AudioSource source;

    AudioClip currentAudioClip;

    void Awake()
    {
        if (condition.GetValue())
        {
            currentAudioClip = audioOptions.GetValue()[Random.Range(0, audioOptions.GetValue().Count)];
            source.PlayOneShot(currentAudioClip);
        }
    }
}
