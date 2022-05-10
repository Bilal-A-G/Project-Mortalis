using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Set Float", menuName = "FSM/Actions/Set Float Value")]

public class SetFloatValue : ActionBase
{
    public GenericReference<float> floatToSetTo;
    public GenericReference<float> floatToSet;

    public override void Execute(GameObject callingObject)
    {
        floatToSet.SetValue(floatToSetTo.GetValue());
    }
}
