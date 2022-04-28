using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveInput : MonoBehaviour
{
    public EventObject walkingEvent;
    public EventObject stoppedWalkingEvent;

    public EventObject stoppedMovingEvent;

    public EventObject jumpedEvent;

    public EventObject runStartEvent;
    public EventObject runStoppedEvent;

    public GenericReference<Vector2> moveDirection;
    public Transform finiteStateMachines;

    InputActions inputActions;

    bool moving;
    FiniteStateMachine currentFiniteStateMachine;

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Awake()
    {
        inputActions = new InputActions();

        currentFiniteStateMachine = finiteStateMachines.GetComponentInChildren<FiniteStateMachine>();

        inputActions.PcMap.Movement.performed += ctx =>
        {
            if(ctx.ReadValue<Vector2>() != Vector2.zero)
            {
                moveDirection.SetValue(ctx.ReadValue<Vector2>());
                moving = true;
            }
            else
            {
                moving = false;
                currentFiniteStateMachine.UpdateState(stoppedWalkingEvent);
            }
        };

        inputActions.PcMap.Jump.performed += ctx =>
        {
            currentFiniteStateMachine.UpdateState(jumpedEvent);
        };

        inputActions.PcMap.Run.started += ctx =>
        {
            currentFiniteStateMachine.UpdateState(runStartEvent);
        };

        inputActions.PcMap.Run.canceled += ctx =>
        {
            currentFiniteStateMachine.UpdateState(runStoppedEvent);
        };
    }


    private void Update()
    {
        if (moving)
        {
            currentFiniteStateMachine.UpdateState(walkingEvent);
        }
        else
        {
            currentFiniteStateMachine.UpdateState(stoppedMovingEvent);
        }
    }
}
