using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Set Controller Values", menuName = "FSM/Actions/Set Character Controller Values")]
public class SetColliderValues : ActionBase
{
    public GenericReference<Path> pathToController;

    public GenericReference<Vector3> desiredCenter;
    public GenericReference<float> desiredHeight;

    [System.NonSerialized]
    CharacterController controller;

    public override void Execute(GameObject callingObject)
    {
        if (controller == null) controller = pathToController.GetValue().GetObjectAtPath(callingObject).GetComponent<CharacterController>();
        
        controller.height = desiredHeight.GetValue();
        controller.center = desiredCenter.GetValue();
    }
}
