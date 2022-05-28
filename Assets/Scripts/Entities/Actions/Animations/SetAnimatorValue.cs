using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorValue<T> : ActionBase
{
    public GenericReference<string> animatorKey;
    public GenericReference<T> value;

    [System.NonSerialized]
    protected Animator animator;

    public override void Execute(CachedObjectWrapper cachedObjects)
    {
       animator = cachedObjects.GetGameObjectFromCache(animatorKey.GetValue(cachedObjects)).GetComponent<Animator>();
    }
}
