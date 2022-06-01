using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimingInput : BasePlayerInput
{
    public EventObject aimEvent;
    public EventObject stopAimEvent;
    public FiniteStateMachine fsm;

    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.PcMap.Aim.started += ctx => { fsm.UpdateState(aimEvent, callingObject, cachedObjects);};

        inputActions.PcMap.Aim.canceled += ctx => { fsm.UpdateState(stopAimEvent, callingObject, cachedObjects);};
    }
}
