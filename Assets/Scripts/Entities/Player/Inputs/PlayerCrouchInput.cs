using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchInput : BasePlayerInput
{
    public EventObject crouchingEvent;
    public EventObject playerStopCrouch;
    public EventObject notCrouchingEvent;

    public FiniteStateMachine currentFiniteStateMachine;

    bool crouching;

    void Awake()
    {
        inputActions = new InputActions();

        inputActions.PcMap.Crouch.started += ctx => 
        {
            crouching = true;
            currentFiniteStateMachine.UpdateState(crouchingEvent, callingObject);
        };

        inputActions.PcMap.Crouch.canceled += ctx =>
        {
            crouching = false;
            currentFiniteStateMachine.UpdateState(playerStopCrouch, callingObject);
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
