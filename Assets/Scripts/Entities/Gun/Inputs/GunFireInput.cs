using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFireInput : BasePlayerInput
{
    public EventObject gunFireEvent;
    public FiniteStateMachine stateMachine;

    void Awake()
    {
        inputActions = new InputActions();

        inputActions.PcMap.FireGun.performed += ctx =>
        {
            stateMachine.UpdateState(gunFireEvent, callingObject);
        };
    }

}
