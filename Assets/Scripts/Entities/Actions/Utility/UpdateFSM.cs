using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Update FSM", menuName = "FSM/Actions/Update FSM")]
public class UpdateFSM : ActionBase
{
    public GenericReference<string> FSMKey;
    public GenericReference<string> callingObjectKey;
    public EventObject eventToInvoke;

    public override void Execute(CachedObjectWrapper callingObjects)
    {
        FiniteStateMachine fsm = callingObjects.GetGameObjectFromCache(FSMKey).GetComponent<FiniteStateMachine>();
        fsm.UpdateState(eventToInvoke, callingObjects.GetGameObjectFromCache(callingObjectKey));
    }
}
