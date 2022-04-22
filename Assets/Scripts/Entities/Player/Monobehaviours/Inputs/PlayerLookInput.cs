using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookInput : MonoBehaviour
{
    public EventObject playerLookEvent;

    public EventObject playerStopLookEvent;
    public EventObject playerStartLookEvent;

    public GenericReference<float> mouseSensitivity;

    public GameObject playerCamera;
    public Transform finiteStateMachines;

    InputActions inputActions;
    FiniteStateMachine currentStateMachine;

    bool isLooking = true;

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
        ResultArguments secondaryArguments = new ResultArguments();

        argumentsToPass.Add(argument);
        argumentsToPass.Add(secondaryArguments);

        currentStateMachine = finiteStateMachines.GetComponentInChildren<FiniteStateMachine>();

        inputActions.PcMap.Look.performed += ctx =>
        {
            argument.floatValue = mouseSensitivity.GetValue();
            argument.vectorValue = ctx.ReadValue<Vector2>();
            argument.objectValue = playerCamera;
            secondaryArguments.objectValue = gameObject;

            argumentsToPass[0] = argument;
            argumentsToPass[1] = secondaryArguments;

            currentStateMachine.UpdateState(playerLookEvent, argumentsToPass);
        };

        inputActions.PcMap.Escape.performed += ctx =>
        {
            isLooking = !isLooking;

            if (!isLooking)
            {
                currentStateMachine.UpdateState(playerStopLookEvent, argumentsToPass);
            }
            else
            {
                currentStateMachine.UpdateState(playerStartLookEvent, argumentsToPass);
            }
        };
    }
}
