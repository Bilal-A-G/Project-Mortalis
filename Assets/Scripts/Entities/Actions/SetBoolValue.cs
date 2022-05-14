using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Set Bool Value", menuName = "FSM/Actions/Set Bool Value")]
public class SetBoolValue : ActionBase
{
    public GenericReference<bool> boolToSetTo;
    public GenericReference<bool> boolToSet;

    public override void Execute(GameObject callingObject)
    {
        boolToSet.SetValue(boolToSetTo.GetValue());
    }
}
