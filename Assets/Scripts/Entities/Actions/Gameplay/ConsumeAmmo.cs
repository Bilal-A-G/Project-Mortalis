using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consume Ammo", menuName = "FSM/Actions/Consume Ammo")]
public class ConsumeAmmo : ActionBase
{
    public EventObject onReachMin;
    public EventObject onReachMax;

    public GenericReference<string> agentKey;

    [System.NonSerialized]
    FiniteStateMachine stateMachine;

    [System.NonSerialized]
    GameObject callingObject;

    [System.NonSerialized]
    GunRuntimeVariables runtimeVariables;

    public override void Execute(CachedObjectWrapper callingObjects)
    {
        callingObject = callingObjects.GetGameObjectFromCache(agentKey);
        stateMachine = callingObject.GetComponentInChildren<FiniteStateMachine>();
        runtimeVariables = callingObject.GetComponent<GunRuntimeVariables>();

        float ammoConsumption = runtimeVariables.ammoPerShot;

        runtimeVariables.currentAmmo -= ammoConsumption;

        float minAmmo = runtimeVariables.minAmmo;
        float maxAmmo = runtimeVariables.maxAmmo;

        if (runtimeVariables.currentAmmo >= maxAmmo)
        {
            runtimeVariables.currentAmmo = maxAmmo;

            if (onReachMax == null) return;

            stateMachine.UpdateState(onReachMax, callingObject);
        }
        else if (runtimeVariables.currentAmmo <= minAmmo)
        {
            runtimeVariables.currentAmmo = minAmmo;

            if (onReachMin == null) return;

            stateMachine.UpdateState(onReachMin, callingObject);
        }
    }
}
