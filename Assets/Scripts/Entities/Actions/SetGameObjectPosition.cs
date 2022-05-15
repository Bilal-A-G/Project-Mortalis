using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Set Position", menuName = "FSM/Actions/Set Position")]
public class SetGameObjectPosition : ActionBase
{
    public GenericReference<Vector3> position;
    public GenericReference<Path> objectPath;

    public override void Execute(GameObject callingObject)
    {
        objectPath.GetValue().GetObjectAtPath(callingObject).transform.localPosition = position.GetValue();
    }
}
