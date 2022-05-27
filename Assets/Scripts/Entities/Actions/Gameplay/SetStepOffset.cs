using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Actions/Set Step Offset")]
public class SetStepOffset : ActionBase
{
    public GenericReference<float> desiredStepOffset;
    public GenericReference<string> agentKey;

    CharacterController characterController;

    public override void Execute(CachedObjectWrapper callingObjects)
    {
        characterController = callingObjects.GetGameObjectFromCache(agentKey).GetComponent<CharacterController>();
        
        characterController.stepOffset = desiredStepOffset;
    }
}
