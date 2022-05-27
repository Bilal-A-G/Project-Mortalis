using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetValue<T> : ActionBase
{
    public GenericReference<T> valueToSet;
    public GenericReference<T> valueToSetTo;

    public bool resetValueOnAwake;

    public override void Execute(CachedObjectWrapper callingObject)
    {
        valueToSet.SetValue(valueToSetTo.GetValue());
    }

    private void OnEnable()
    {
        if (!resetValueOnAwake) return;
        valueToSet.SetValue(valueToSetTo.GetValue());
    }
}
