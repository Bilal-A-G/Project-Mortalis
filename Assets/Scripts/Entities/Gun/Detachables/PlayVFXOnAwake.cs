using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayVFXOnAwake : MonoBehaviour
{
    public VisualEffect vfxSource;
    public VisualEffectAsset vfx;
    public GameObject callingObject;

    public EventObject onAwakeEvent;
    public GenericReference<bool> playVFX;
    public CachedObjectWrapper cachedObjects;

    void Awake()
    {
        if (playVFX.GetValue(cachedObjects))
        {
            vfxSource.Stop();
            vfxSource.visualEffectAsset = vfx;
            vfxSource.Play();

            onAwakeEvent.Invoke(callingObject);
        }
    }
}
