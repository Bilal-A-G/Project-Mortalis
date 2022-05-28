using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Update FSM", menuName = "FSM/Actions/Update FSM")]
public class UpdateFSM : ActionBase
{
    public GenericReference<string> FSMKey;
    public GenericReference<string> callingObjectKey;
    public EventObject eventToInvoke;

    public override void Execute(CachedObjectWrapper cachedObjects)
    {
        FiniteStateMachine fsm = cachedObjects.GetGameObjectFromCache(FSMKey.GetValue(cachedObjects)).GetComponent<FiniteStateMachine>();
        fsm.UpdateState(eventToInvoke, cachedObjects.GetGameObjectFromCache(callingObjectKey.GetValue(cachedObjects)));
    }
}
