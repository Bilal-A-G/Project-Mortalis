using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Modded Variables/Functions/Randomize Audio From List")]
public class RandomizeSoundClipFromList : GenericValue<AudioClip>
{
    public List<GenericReference<AudioClip>> list;

    public override AudioClip GetValue(CachedObjectWrapper cachedObjects)
    {
        return list[Random.Range(0, list.Count)].GetValue(cachedObjects);
    }

    public override void SetValue(AudioClip value, CachedObjectWrapper cachedObjects)
    {
        return;
    }
}
