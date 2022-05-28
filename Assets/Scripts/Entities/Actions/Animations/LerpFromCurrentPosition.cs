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

    public override void Execute(CachedObjectWrapper cachedObjects)
    {
        lerpTarget = cachedObjects.GetGameObjectFromCache(targetKey.GetValue(cachedObjects));

        lerpPosition = Vector3.Lerp(lerpPosition, lerpAlongVector.GetValue(cachedObjects), Time.smoothDeltaTime * speed.GetValue(cachedObjects));
        lerpTarget.transform.localPosition = lerpPosition + startPosition.GetValue(cachedObjects);
    }
}
