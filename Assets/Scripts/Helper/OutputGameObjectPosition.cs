using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Modded Variables/Functions/Output GameObject Position")]
public class OutputGameObjectPosition : GenericValue<Vector3>
{
    public GenericReference<string> callingObject;
    public GenericReference<Path> pathFromCallingObject;

    [System.NonSerialized]
    GameObject cachedGameObject;

    public override Vector3 GetValue()
    {
        if (cachedGameObject == null) cachedGameObject = pathFromCallingObject.GetValue().GetObjectAtPath(GameObject.Find(callingObject));

        return cachedGameObject.transform.position;
    }

    public override void SetValue(Vector3 value)
    {
        return;
    }
}
