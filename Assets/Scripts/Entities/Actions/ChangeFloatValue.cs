using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Change Float", menuName = "FSM/Actions/Change Float")]
public class ChangeFloatValue : ActionBase
{
    public GenericReference<float> floatToChange;
    public GenericReference<float> floatToChangeTo;

    public override void Execute(GameObject callingObject)
    {
        floatToChange.SetValue(floatToChangeTo.GetValue());
    }
}
