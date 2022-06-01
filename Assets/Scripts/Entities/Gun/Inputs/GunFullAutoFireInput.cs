using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFullAutoFireInput : BasePlayerInput
{
    public EventObject gunFireEvent;
    public FiniteStateMachine fsm;
    public GenericReference<float> fireRate;

    bool isFiring;

    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.PcMap.FireGun.started += ctx => { isFiring = true; fsm.UpdateState(gunFireEvent, callingObject, cachedObjects); };
        inputActions.PcMap.FireGun.canceled += ctx => isFiring = false;

        StartCoroutine("FireLoop");
    }

    IEnumerator FireLoop()
    {
        if (isFiring)
        {
            fsm.UpdateState(gunFireEvent, callingObject, cachedObjects);
        }

        yield return new WaitForSeconds(1/fireRate.GetValue(cachedObjects));

        StartCoroutine("FireLoop");
    }
}
