using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SLerp", menuName = "FSM/Actions/SLerp")]
public class SLerp : LerpPosition
{
    protected override void LerpProperty(Vector3 startPosition, Vector3 endPosition)
    {
        lerpTarget.transform.localPosition = Vector3.SlerpUnclamped(startPosition, endPosition, thisFrameEvaluation);
    }
}
