using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(fileName = "New Play VFX", menuName = "FSM/Actions/Play VFX")]
public class PlayVFX : ActionBase
{
    public GenericReference<Path> pathToVFXPlayer;
    public GenericReference<VisualEffectAsset> VFX;

    [System.NonSerialized]
    VisualEffect effectPlayer;

    public override void Execute(GameObject callingObject)
    {
        if (effectPlayer == null) effectPlayer = pathToVFXPlayer.GetValue().GetObjectAtPath(callingObject).GetComponent<VisualEffect>();
        effectPlayer.visualEffectAsset = VFX.GetValue();
        effectPlayer.Play();
    }
}
