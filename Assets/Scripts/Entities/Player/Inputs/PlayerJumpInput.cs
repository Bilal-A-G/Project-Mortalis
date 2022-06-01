using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpInput : BasePlayerInput
{
    public EventObject jumpedEvent;
    public FiniteStateMachine finiteStateMachines;

    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.PcMap.Jump.performed += ctx =>
        {
            finiteStateMachines.UpdateState(jumpedEvent, callingObject, cachedObjects);
        };
    }
}
