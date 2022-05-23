using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Actions/Play Audio")]
public class PlayAudio : ActionBase
{
    public GenericReference<Path> pathToAudioSource;
    public GenericReference<AudioClip> clipToPlay;

    [System.NonSerialized]
    AudioSource source;

    public override void Execute(GameObject callingObject)
    {
        source = pathToAudioSource.GetValue().GetObjectAtPath(callingObject).GetComponent<AudioSource>();

        source.PlayOneShot(clipToPlay.GetValue());
    }
}
