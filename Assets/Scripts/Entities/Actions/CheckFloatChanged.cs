using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Check Float Changed", menuName = "FSM/Actions/Check Float Changed")]
public class CheckFloatChanged : ActionBase
{
    public EventObject onFloatChanged;
    public GenericReference<float> floatToMonitor;

    public GenericReference<float> valueChangeTo;
    public GenericReference<float> valueChangeFrom;

    [System.NonSerialized]
    float valueLastFrame;

    public override void Execute(GameObject callingObject)
    {
        return;
    }

    public override void UpdateLoop(GameObject callingObject)
    {
        if (floatToMonitor.GetValue() == valueLastFrame) return;

        if (floatToMonitor.GetValue() == valueChangeTo.GetValue() && valueLastFrame == valueChangeFrom.GetValue())
        {
            onFloatChanged.Invoke(callingObject);
        }

        valueLastFrame = floatToMonitor.GetValue();
    }
}
