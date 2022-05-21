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
            Debug.Log("Reloaded");
            stateMachine.UpdateState(gunReloadEvent, callingObject);
        };
    }
}
