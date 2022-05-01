using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchInput : BasePlayerInput
{
    public EventObject crouchStartedEvent;
    public EventObject crouchStoppedEvent;
    public EventObject notCrouchingEvent;

    public FiniteStateMachine currentFiniteStateMachine;

    bool crouching;

    void Awake()
    {
        inputActions = new InputActions();

        inputActions.PcMap.Crouch.started += ctx => 
        {
            crouching = true;
            currentFiniteStateMachine.UpdateState(crouchStartedEvent, callingObject);
        };

        inputActions.PcMap.Crouch.canceled += ctx =>
        {
            crouching = false;
            currentFiniteStateMachine.UpdateState(crouchStoppedEvent, callingObject);
        };
    }

    private void Update()
    {
        if (!crouching)
        {
            currentFiniteStateMachine.UpdateState(notCrouchingEvent, callingObject);
        }
    }
}
