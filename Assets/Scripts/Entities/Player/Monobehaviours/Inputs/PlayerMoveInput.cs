using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveInput : MonoBehaviour
{
    public EventObject movingEvent;
    public EventObject stopMovingEvent;
    public GenericReference<float> moveSpeed;

    public EventObject jumpedEvent;
    public GenericReference<float> jumpHeight;
    public GenericReference<float> gravity;

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
        ResultArguments argument2 = new ResultArguments();
        argumentsToPass.Add(argument);
        argumentsToPass.Add(argument2);

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

            argument2.floatValue = gravity.GetValue();

            argumentsToPass[0] = argument;
            argumentsToPass[1] = argument2;

            currentFiniteStateMachine.UpdateState(jumpedEvent, argumentsToPass);
        };
    }
}
