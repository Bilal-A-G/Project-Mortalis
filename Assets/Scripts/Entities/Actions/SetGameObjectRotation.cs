using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Set Rotation", menuName = "FSM/Actions/Set Rotation")]
public class SetGameObjectRotation : ActionBase
{
    public GenericReference<Vector3> rotation;
    public GenericReference<Path> objectPath;
    public override void Execute(GameObject callingObject)
    {
        objectPath.GetValue().GetObjectAtPath(callingObject).transform.localEulerAngles = rotation.GetValue();

    }
}
