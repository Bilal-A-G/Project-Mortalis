using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookInput : BasePlayerInput
{
    public EventObject playerLookEvent;

    public GenericReference<Vector2> mouseDelta;
    public FiniteStateMachine finiteStateMachine;

    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.PcMap.Look.performed += ctx =>
        {
            mouseDelta.SetValue(ctx.ReadValue<Vector2>(), cachedObjects);
            finiteStateMachine.UpdateState(playerLookEvent, callingObject);
        };
    }
}
