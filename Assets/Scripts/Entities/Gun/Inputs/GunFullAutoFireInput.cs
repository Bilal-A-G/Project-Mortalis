using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFullAutoFireInput : BasePlayerInput
{
    public EventObject gunFireEvent;
    public FiniteStateMachine fsm;
    public GenericReference<float> fireRate;

    bool isFiring;
    float previousShotTime;

    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.PcMap.FireGun.started += ctx => { isFiring = true; fsm.UpdateState(gunFireEvent, callingObject, cachedObjects); Debug.Log("Hi"); };
        inputActions.PcMap.FireGun.canceled += ctx => isFiring = false;
        previousShotTime = Time.time;
    }

    private void FixedUpdate()
    {
        if (!isFiring) return;

        if(Time.time - previousShotTime >= 1 / fireRate.GetValue(cachedObjects))
        {
            fsm.UpdateState(gunFireEvent, callingObject, cachedObjects);
            previousShotTime = Time.time;
        }
    }

}
