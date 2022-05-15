using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Lerp Rotation", menuName = "FSM/Actions/Lerp Rotation")]
public class LerpRotation : LerpPosition
{
    protected override void LerpProperty(Vector3 startRotation, Vector3 endRotation)
    {
        if(endRotation.x < 0) endRotation.x += 360;
        else if(endRotation.x > 360) endRotation.x -= 360;

        if (endRotation.y < 0) endRotation.y += 360;
        else if (endRotation.y > 360) endRotation.y -= 360;

        if (endRotation.z < 0) endRotation.z += 360;
        else if (endRotation.z > 360) endRotation.z -= 360;

        float lerpedX = Mathf.LerpUnclamped(startRotation.x, endRotation.x, thisFrameEvaluation);
        float lerpedY = Mathf.LerpUnclamped(startRotation.y, endRotation.y, thisFrameEvaluation);
        float lerpedZ = Mathf.LerpUnclamped(startRotation.z, endRotation.z, thisFrameEvaluation);

        lerpTarget.transform.localEulerAngles = new Vector3(lerpedX, lerpedY, lerpedZ);
    }

    protected override void SetUpStartVector()
    {
        startVector = lerpTarget.transform.localRotation.eulerAngles;
    }
}
