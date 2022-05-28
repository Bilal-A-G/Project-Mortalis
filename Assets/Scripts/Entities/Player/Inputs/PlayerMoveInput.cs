using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveInput : BasePlayerInput
{
    public EventObject movingEvent;
    public EventObject startMoveEvent;
    public EventObject stoppedMovingEvent;

    public GenericReference<Vector2> moveDirection;
    public FiniteStateMachine finiteStateMachines;

    bool moving;

    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.PcMap.Movement.performed += ctx =>
        {
            moveDirection.SetValue(ctx.ReadValue<Vector2>(), cachedObjects);

            if (ctx.ReadValue<Vector2>() != Vector2.zero)
            {
                finiteStateMachines.UpdateState(startMoveEvent, callingObject);
                moving = true;
            }
            else
            {
                finiteStateMachines.UpdateState(stoppedMovingEvent, callingObject);
                moving = false;
            }
        };
    }

    private void Update()
    {
        if (!moving) return;

        finiteStateMachines.UpdateState(movingEvent, callingObject);
    }
}
