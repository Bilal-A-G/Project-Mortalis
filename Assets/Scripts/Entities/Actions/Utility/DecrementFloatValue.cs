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

    public EventObject onReachMin;
    public EventObject onReachMax;

    public GenericReference<string> agentKey;

    [System.NonSerialized]
    FiniteStateMachine stateMachine;

    [System.NonSerialized]
    GameObject callingObject;

    public override void Execute(CachedObjectWrapper cachedObjects)
    {
        floatToDecrement.SetValue(floatToDecrement.GetValue(cachedObjects) + decrementer.GetValue(cachedObjects), cachedObjects);

        callingObject = cachedObjects.GetGameObjectFromCache(agentKey.GetValue(cachedObjects)); 
        stateMachine = callingObject.GetComponentInChildren<FiniteStateMachine>();

        if (max == null && min == null) return;

        if (max != null && floatToDecrement.GetValue(cachedObjects) >= max.GetValue(cachedObjects))
        {
            floatToDecrement.SetValue(max.GetValue(cachedObjects), cachedObjects);

            if (onReachMax == null) return;

            stateMachine.UpdateState(onReachMax, callingObject);
        }
        else if (min != null && floatToDecrement.GetValue(cachedObjects) <= min.GetValue(cachedObjects))
        {
            floatToDecrement.SetValue(min.GetValue(cachedObjects), cachedObjects);

            if (onReachMin == null) return;

            stateMachine.UpdateState(onReachMin, callingObject);
        }
    }
}
