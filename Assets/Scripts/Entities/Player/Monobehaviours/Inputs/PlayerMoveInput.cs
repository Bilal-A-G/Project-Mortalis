using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveInput : MonoBehaviour
{
    [Header("Ground Movement")]
    public EventObject movingEvent;
    public EventObject stopMovingEvent;

    public GenericReference<float> moveSpeed;

    [Header("Jumping")]
    public EventObject jumpedEvent;
    public GenericReference<float> jumpHeight;

    public Transform finiteStateMachines;

    InputActions inputActions;

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

        List<ResultArguments> argumentsToPass = new List<ResultArguments>();
        ResultArguments argument = new ResultArguments();
        argumentsToPass.Add(argument);

        FiniteStateMachine currentFiniteStateMachine = finiteStateMachines.GetComponentInChildren<FiniteStateMachine>();

        inputActions.PcMap.Movement.performed += ctx =>
        {
            if(ctx.ReadValue<Vector2>() == Vector2.zero)
            {
                argument.objectValue = gameObject;
                argument.floatValue = 0f;

                argumentsToPass[0] = argument;

                currentFiniteStateMachine.UpdateState(stopMovingEvent, argumentsToPass);
            }
            else
            {
                argument.floatValue = moveSpeed.GetValue();
                argument.vectorValue = ctx.ReadValue<Vector2>();
                argument.objectValue = gameObject;

                argumentsToPass[0] = argument;

                currentFiniteStateMachine.UpdateState(movingEvent, argumentsToPass);
            }
        };

        inputActions.PcMap.Jump.performed += ctx =>
        {
            argument.floatValue = jumpHeight.GetValue();
            argument.objectValue = gameObject;

            argumentsToPass[0] = argument;

            currentFiniteStateMachine.UpdateState(jumpedEvent, argumentsToPass);
        };
    }
}
