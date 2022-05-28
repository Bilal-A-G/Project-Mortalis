using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Actions/SLerp")]
public class SLerpPosition : LerpPosition
{
    protected override void LerpProperty(Vector3 startPosition, Vector3 endPosition, CachedObjectWrapper cachedObjects)
    {
        lerpTarget.transform.localPosition = Vector3.SlerpUnclamped(startPosition, endPosition, easingFunction.GetValue(cachedObjects).Evaluate(timeSinceExecuted));
    }
}
