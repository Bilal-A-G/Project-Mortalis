using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Variables/Functions/Multiply Float By Vector Magnitude")]
public class MultiplyFloatByVectorMagnitude : GenericValue<float>
{
    public GenericReference<Vector2> vectorInput;
    public GenericReference<float> floatInput;

    public override float GetValue()
    {
        return vectorInput.GetValue().magnitude * floatInput;
    }

    public override void SetValue(float value)
    {
        return;
    }
}
