using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunReloadInput : BasePlayerInput
{
    public EventObject gunReloadEvent;
    public FiniteStateMachine stateMachine;

    void Awake()
    {
        inputActions = new InputActions();

        inputActions.PcMap.Reload.started += ctx =>
        {
            stateMachine.UpdateState(gunReloadEvent, callingObject, cachedObjects);
        };
    }
}
