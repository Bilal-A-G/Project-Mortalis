using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveInput : MonoBehaviour
{
    public EventObject movingEvent;
    public EventObject changeMoveDirectionEvent;
    public EventObject stoppedEvent;
    public GenericReference<float> moveSpeed;

    public EventObject jumpedEvent;
    public GenericReference<float> jumpHeight;
    public GenericReference<float> gravity;

    public EventObject runStartEvent;
    public EventObject runStoppedEvent;

    public Transform finiteStateMachines;

    InputActions inputActions;

    bool moving;
    List<ResultArguments> argumentsToPass;
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

        argumentsToPass = new List<ResultArguments>();
        ResultArguments argument = new ResultArguments();
        ResultArguments argument2 = new ResultArguments();
        argumentsToPass.Add(argument);
        argumentsToPass.Add(argument2);

        currentFiniteStateMachine = finiteStateMachines.GetComponentInChildren<FiniteStateMachine>();

        inputActions.PcMap.Movement.performed += ctx =>
        {
            if(ctx.ReadValue<Vector2>() != Vector2.zero)
            {
                argument.floatValue = moveSpeed.GetValue();
                argument.vectorValue = ctx.ReadValue<Vector2>();
                argument.objectValue = gameObject;

                argumentsToPass[0] = argument;

                moving = true;

                currentFiniteStateMachine.UpdateState(changeMoveDirectionEvent, argumentsToPass);
            }
            else
            {
                moving = false;

                currentFiniteStateMachine.UpdateState(stoppedEvent, argumentsToPass);
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

        inputActions.PcMap.Run.started += ctx =>
        {
            currentFiniteStateMachine.UpdateState(runStartEvent, argumentsToPass);
        };

        inputActions.PcMap.Run.canceled += ctx =>
        {
            currentFiniteStateMachine.UpdateState(runStoppedEvent, argumentsToPass);
        };
    }


    private void Update()
    {
        if (moving)
        {
            currentFiniteStateMachine.UpdateState(movingEvent, argumentsToPass);
        }
    }
}
