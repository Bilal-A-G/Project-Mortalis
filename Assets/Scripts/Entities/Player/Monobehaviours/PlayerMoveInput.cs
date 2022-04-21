using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveInput : MonoBehaviour
{
    public EventObject movingEvent;
    public EventObject stopMovingEvent;

    public float moveSpeed;

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

        FiniteStateMachine currentFiniteStateMachine = finiteStateMachines.GetComponentInChildren<FiniteStateMachine>();

        inputActions.PcMap.Movement.performed += ctx =>
        {
            if(ctx.ReadValue<Vector2>() == Vector2.zero)
            {
                currentFiniteStateMachine.UpdateState(stopMovingEvent, new List<ResultArguments>() { new ResultArguments(0, 0, null, Vector2.zero, null) });
            }
            else
            {
                currentFiniteStateMachine.UpdateState(movingEvent, new List<ResultArguments>() { new ResultArguments(moveSpeed, 0, null, ctx.ReadValue<Vector2>(), null) });
            }
        };
    }
}
