using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Update FSM", menuName = "FSM/Actions/Update FSM")]
public class UpdateFSM : ActionBase
{
    public GenericReference<Path> pathToFSMObject;
    public EventObject eventToInvoke;

    public override void Execute(GameObject callingObject)
    {
        FiniteStateMachine fsm = pathToFSMObject.GetValue().GetObjectAtPath(callingObject).GetComponent<FiniteStateMachine>();
        fsm.UpdateState(eventToInvoke, callingObject);
    }
}
