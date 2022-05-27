using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Lerp From Current Position", menuName = "FSM/Actions/Lerp From Current Position")]
public class LerpFromCurrentPosition : ActionBase
{
    public GenericReference<Vector3> lerpAlongVector;
    public GenericReference<float> speed;
    public GenericReference<string> targetKey;

    public GenericReference<Vector3> startPosition;

    [System.NonSerialized]
    Vector3 lerpPosition;
    [System.NonSerialized]
    GameObject lerpTarget;

    public override void Execute(CachedObjectWrapper callingObject)
    {
        lerpTarget = callingObject.GetGameObjectFromCache(targetKey);

        lerpPosition = Vector3.Lerp(lerpPosition, lerpAlongVector.GetValue(), Time.smoothDeltaTime * speed.GetValue());
        lerpTarget.transform.localPosition = lerpPosition + startPosition.GetValue();
    }
}
