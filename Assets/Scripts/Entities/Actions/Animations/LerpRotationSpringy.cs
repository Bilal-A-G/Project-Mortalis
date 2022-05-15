using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Lerp Rotation Springy", menuName = "FSM/Actions/Lerp Rotation Springy")]
public class LerpRotationSpringy : ActionBase
{
    Vector3 targetRotation;
    Vector3 finalRotation;

    public GenericReference<Vector3> endRotation;
    public GenericReference<float> speed;
    public GenericReference<Path> pathToTarget;

    GameObject lerpTarget;

    public override void Execute(GameObject callingObject)
    {
        if (lerpTarget == null) lerpTarget = pathToTarget.GetValue().GetObjectAtPath(callingObject);
    }

    public override void FixedUpdate()
    {
        if (lerpTarget == null) return;

        targetRotation += endRotation.GetValue();

        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, speed.GetValue());
        finalRotation = Vector3.Lerp(finalRotation, targetRotation, speed.GetValue());

        lerpTarget.transform.localEulerAngles = finalRotation;
    }

    void OnDisable()
    {
        targetRotation = Vector3.zero;
        finalRotation = Vector3.zero;
        lerpTarget = null;
    }
}
