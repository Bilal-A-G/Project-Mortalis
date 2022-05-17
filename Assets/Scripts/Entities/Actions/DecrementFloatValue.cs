using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Decrement Float", menuName = "FSM/Actions/Decrement Float")]
public class DecrementFloatValue : ActionBase
{
    public GenericReference<float> floatToDecrement;
    public GenericReference<float> decrementer;

    public GenericReference<float> min;
    public GenericReference<float> max;

    public GenericReference<bool> resetValue;

    public EventObject onReachMin;
    public EventObject onReachMax;

    [System.NonSerialized]
    FiniteStateMachine stateMachine;

    public override void Execute(GameObject callingObject)
    {
        floatToDecrement.SetValue(floatToDecrement.GetValue() + decrementer.GetValue());

        if (stateMachine == null) stateMachine = callingObject.GetComponentInChildren<FiniteStateMachine>();
        if (max == null && min == null) return;

        if (max != null && floatToDecrement.GetValue() >= max.GetValue())
        {
            floatToDecrement.SetValue(max.GetValue());

            if (onReachMax == null) return;

            stateMachine.UpdateState(onReachMax, callingObject);
        }
        else if (min != null && floatToDecrement.GetValue() <= min.GetValue())
        {
            floatToDecrement.SetValue(min.GetValue());

            if (onReachMin == null) return;

            stateMachine.UpdateState(onReachMin, callingObject);
        }
    }

    private void OnDisable()
    {
        if(resetValue.GetValue()) floatToDecrement.SetValue(min.GetValue());
    }
}
