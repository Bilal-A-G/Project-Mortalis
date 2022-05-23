using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Modded Variables/Functions/Multiply Float By Float")]
public class MultiplyFloatByFloat : GenericValue<float>
{
    public GenericReference<float> baseValue;
    public GenericReference<float> modifier;

    public override float GetValue()
    {
        return baseValue * modifier;
    }

    public override void SetValue(float value)
    {
        return;
    }

}
