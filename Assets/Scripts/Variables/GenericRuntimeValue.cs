using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericRuntimeValue<T> : GenericValue<T>
{
    public GenericReference<string> valueKey;
    public GenericReference<string> valueName;

    public override T GetValue(CachedObjectWrapper cachedObjects)
    {
        IRuntimeVariable variablesClass = cachedObjects.GetGameObjectFromCache(valueKey.GetValue(cachedObjects)).GetComponent<IRuntimeVariable>();
        return (T)variablesClass.GetValueFromName(valueName.GetValue(cachedObjects));
    }

    public override void SetValue(T value, CachedObjectWrapper cachedObjects)
    {
        IRuntimeVariable variablesClass = cachedObjects.GetGameObjectFromCache(valueKey.GetValue(cachedObjects)).GetComponent<IRuntimeVariable>();
        variablesClass.SetValueFromName(valueName.GetValue(cachedObjects), value);
    }
}
