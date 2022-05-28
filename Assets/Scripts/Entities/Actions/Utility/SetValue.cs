using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetValue<T> : ActionBase
{
    public GenericReference<T> valueToSet;
    public GenericReference<T> valueToSetTo;

    public override void Execute(CachedObjectWrapper cachedObjects)
    {
        valueToSet.SetValue(valueToSetTo.GetValue(cachedObjects), cachedObjects);
    }
}
