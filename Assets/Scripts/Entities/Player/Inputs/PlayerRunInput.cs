using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunInput : BasePlayerInput
{
    public EventObject runStartEvent;
    public EventObject runStoppedEvent;

    public FiniteStateMachine finiteStateMachines;

    void Awake()
    {
        inputActions = new InputActions();

        inputActions.PcMap.Run.started += ctx =>
        {
            finiteStateMachines.UpdateState(runStartEvent, callingObject, cachedObjects);
        };

        inputActions.PcMap.Run.canceled += ctx =>
        {
            finiteStateMachines.UpdateState(runStoppedEvent, callingObject, cachedObjects);
        };
    }
}
