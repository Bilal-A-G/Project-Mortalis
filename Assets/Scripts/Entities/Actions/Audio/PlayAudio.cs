using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Actions/Play Audio")]
public class PlayAudio : ActionBase
{
    public GenericReference<string> audioSourceKey;
    public GenericReference<AudioClip> clipToPlay;

    [System.NonSerialized]
    AudioSource source;

    public override void Execute(CachedObjectWrapper callingObjects)
    {
        source = callingObjects.GetGameObjectFromCache(audioSourceKey).GetComponent<AudioSource>();

        source.PlayOneShot(clipToPlay.GetValue());
    }
}
