using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Modded Variables/Functions/Multiply Float By Vector Magnitude")]
public class MultiplyFloatByVectorMagnitude : GenericValue<float>
{
    public GenericReference<Vector2> vectorInput;
    public GenericReference<float> floatInput;

    public override float GetValue(CachedObjectWrapper cachedObjects)
    {
        return vectorInput.GetValue(cachedObjects).magnitude * floatInput.GetValue(cachedObjects);
    }

    public override void SetValue(float value, CachedObjectWrapper cachedObjects)
    {
        return;
    }
}
