using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(fileName = "New Play VFX", menuName = "FSM/Actions/Play VFX")]
public class PlayVFX : ActionBase
{
    public GenericReference<string> VFXPlayerKey;
    public GenericReference<VisualEffectAsset> VFX;

    [System.NonSerialized]
    VisualEffect effectPlayer;

    public override void Execute(CachedObjectWrapper callingObjects)
    {
        effectPlayer = callingObjects.GetGameObjectFromCache(VFXPlayerKey).GetComponent<VisualEffect>();
        effectPlayer.visualEffectAsset = VFX.GetValue();
        effectPlayer.Play();
    }
}
