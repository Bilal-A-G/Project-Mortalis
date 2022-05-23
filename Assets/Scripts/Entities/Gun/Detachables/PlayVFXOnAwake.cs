using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayVFXOnAwake : MonoBehaviour
{
    public VisualEffect vfxSource;
    public VisualEffectAsset vfx;
    public GenericReference<bool> condition;
    public GameObject callingObject;

    public EventObject onAwakeEvent;

    void Awake()
    {
        if (condition.GetValue())
        {
            vfxSource.Stop();
            vfxSource.visualEffectAsset = vfx;
            vfxSource.Play();

            onAwakeEvent.Invoke(callingObject);
        }
    }
}
