using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchInput : BasePlayerInput
{
    public EventObject startedCrouchingEvent;
    public EventObject stoppedCrouchingEvent;

    public FiniteStateMachine currentFiniteStateMachine;

    void Awake()
    {
        inputActions = new InputActions();

        inputActions.PcMap.Crouch.started += ctx => 
        {
            currentFiniteStateMachine.UpdateState(startedCrouchingEvent, callingObject);
        };

        inputActions.PcMap.Crouch.canceled += ctx =>
        {
            currentFiniteStateMachine.UpdateState(stoppedCrouchingEvent, callingObject);
        };
    }
}
