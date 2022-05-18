using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Play Audio", menuName = "FSM/Actions/Play Audio Action")]
public class PlayAudioAction : ActionBase
{
    public GenericReference<Path> pathToAudioSource;
    public GenericReference<AudioClip> clipToPlay;

    [System.NonSerialized]
    AudioSource source;

    public override void Execute(GameObject callingObject)
    {
        if (source == null) source = pathToAudioSource.GetValue().GetObjectAtPath(callingObject).GetComponent<AudioSource>();

        source.PlayOneShot(clipToPlay.GetValue());
    }
}
