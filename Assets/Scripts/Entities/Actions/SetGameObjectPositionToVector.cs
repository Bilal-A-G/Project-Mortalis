using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Clone Position", menuName = "FSM/Actions/Clone GameObject Position")]
public class SetGameObjectPositionToVector : ActionBase
{
    public GenericReference<Path> pathToGameObject;
    public GenericReference<Vector3> outputVector;
    public GenericReference<Vector3> outputRotationVector;

    public override void Execute(GameObject callingObject)
    {
        outputVector.SetValue(pathToGameObject.GetValue().GetObjectAtPath(callingObject).transform.position);
        outputRotationVector.SetValue(pathToGameObject.GetValue().GetObjectAtPath(callingObject).transform.eulerAngles);
    }
}
