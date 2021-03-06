using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Set Controller Values", menuName = "FSM/Actions/Set Character Controller Values")]
public class SetColliderValues : ActionBase
{
    public GenericReference<string> agentKey;

    public GenericReference<Vector3> desiredCenter;
    public GenericReference<float> desiredHeight;

    [System.NonSerialized]
    CharacterController controller;

    public override void Execute(CachedObjectWrapper cachedObjects)
    {
        controller = cachedObjects.GetGameObjectFromCache(agentKey.GetValue(cachedObjects)).GetComponent<CharacterController>();
        
        controller.height = desiredHeight.GetValue(cachedObjects);
        controller.center = desiredCenter.GetValue(cachedObjects);
    }
}
