using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchInput : BasePlayerInput
{
    public EventObject crouchingEvent;
    public EventObject notCrouchingEvent;

    public FiniteStateMachine currentFiniteStateMachine;

    bool crouching;
    bool crouchLastFrame;

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
        };
    }

    private void Update()
    {
        if (!crouching)
        {
            currentFiniteStateMachine.UpdateState(notCrouchingEvent, callingObject);
        }

        crouchLastFrame = crouching;
    }
}
