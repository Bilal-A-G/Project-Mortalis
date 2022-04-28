using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookInput : MonoBehaviour
{
    public EventObject playerLookEvent;

    public GenericReference<Vector2> mouseDelta;
    public Transform finiteStateMachines;

    InputActions inputActions;
    FiniteStateMachine currentStateMachine;

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

        currentStateMachine = finiteStateMachines.GetComponentInChildren<FiniteStateMachine>();

        inputActions.PcMap.Look.performed += ctx =>
        {
            mouseDelta.SetValue(ctx.ReadValue<Vector2>());
            currentStateMachine.UpdateState(playerLookEvent);
        };
    }
}
