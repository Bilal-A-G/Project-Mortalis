using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Lerp Rotation", menuName = "FSM/Actions/Lerp Rotation")]
public class LerpRotation : LerpPosition
{
    protected override bool LerpToEnd(Vector3 endRotation, float speed)
    {
        Vector3 lerpTargetRotation = lerpTarget.transform.localEulerAngles;
        float lerpedX = Mathf.LerpAngle(lerpTargetRotation.x, endRotation.x, speed * Time.deltaTime);
        float lerpedY = Mathf.LerpAngle(lerpTargetRotation.y, endRotation.y, speed * Time.deltaTime);
        float lerpedZ = Mathf.LerpAngle(lerpTargetRotation.z, endRotation.z, speed * Time.deltaTime);

        lerpTarget.transform.localEulerAngles = new Vector3(lerpedX, lerpedY, lerpedZ);

        Vector3 endRotationToEvaluate = endRotation;

        if(endRotation.x < 0)
        {
            endRotationToEvaluate.x += 360;
        }
        if (endRotation.y < 0)
        {
            endRotationToEvaluate.y += 360;
        }
        if(endRotation.z < 0)
        {
            endRotationToEvaluate.z += 360;
        }

        if ((endRotationToEvaluate - lerpTarget.transform.localEulerAngles).magnitude <= tolorence.GetValue())
        {
            return true;
        }

        return false;
    }

    protected override void SetUpStartVector()
    {
        startVector = lerpTarget.transform.localRotation.eulerAngles;
    }
}
