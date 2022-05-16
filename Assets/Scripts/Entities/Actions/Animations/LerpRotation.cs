using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Lerp Rotation", menuName = "FSM/Actions/Lerp Rotation")]
public class LerpRotation : LerpPosition
{
    protected override void LerpProperty(Vector3 startRotation, Vector3 endRotation)
    {
        float thisFrameEvaluation = easingFunction.GetValue().Evaluate(timeSinceExecuted);

        float lerpedX = Mathf.LerpUnclamped(startRotation.x, endRotation.x, thisFrameEvaluation);
        float lerpedY = Mathf.LerpUnclamped(startRotation.y, endRotation.y, thisFrameEvaluation);
        float lerpedZ = Mathf.LerpUnclamped(startRotation.z, endRotation.z, thisFrameEvaluation);

        lerpTarget.transform.localEulerAngles = new Vector3(lerpedX, lerpedY, lerpedZ);
    }

    protected override void SetUpStartVector()
    {
        Vector3 startPosition = lerpTarget.transform.localEulerAngles;

        if(startPosition.x > 180)
        {
            startPosition.x -= 360;
        }
        if(startPosition.y > 180)
        {
            startPosition.y -= 360;
        }
        if(startPosition.z > 180)
        {
            startPosition.z -= 360;
        }

        startVector = startPosition;
    }

    protected override void ResetLerpedProperty()
    {
        lerpTarget.transform.localEulerAngles = startVector;
    }
}
