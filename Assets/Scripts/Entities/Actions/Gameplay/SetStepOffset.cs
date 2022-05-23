using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Actions/Set Step Offset")]
public class SetStepOffset : ActionBase
{
    public GenericReference<float> desiredStepOffset;
    public GenericReference<Path> pathToCharacterController;

    CharacterController characterController;

    public override void Execute(GameObject callingObject)
    {
        characterController = pathToCharacterController.GetValue().GetObjectAtPath(callingObject).GetComponent<CharacterController>();
        
        characterController.stepOffset = desiredStepOffset;
    }
}
