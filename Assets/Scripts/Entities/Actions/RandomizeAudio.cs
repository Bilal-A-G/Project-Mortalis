using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Randomize Audio", menuName = "FSM/Actions/Randomize Audio Action")]
public class RandomizeAudio : ActionBase
{
    public GenericReference<AudioClip> output;
    public GenericReference<List<AudioClip>> possibleClips;

    public override void Execute(GameObject callingObject)
    {
        output.SetValue(possibleClips.GetValue()[Random.Range(0, possibleClips.GetValue().Count)]);
    }
}
