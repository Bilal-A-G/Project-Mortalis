using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Actions/Sway Weapon")]
public class SwayWeapon : ActionBase
{
    [System.NonSerialized]
    Vector3 targetRotation;
    [System.NonSerialized]
    Vector3 finalRotation;

    public GenericReference<Vector2> mouseDelta;
    public GenericReference<Vector2> moveDelta;

    public GenericReference<float> lookSwayAmount;
    public GenericReference<float> moveSwayAmount;

    public GenericReference<float> swayClamp;

    public GenericReference<float> speed;
    public GenericReference<Path> pathToTarget;

    [System.NonSerialized]
    GameObject lerpTarget;

    public override void Execute(GameObject callingObject)
    {
        lerpTarget = pathToTarget.GetValue().GetObjectAtPath(callingObject);

        Vector2 mouseDeltaValue = mouseDelta.GetValue() * lookSwayAmount;
        Vector2 moveDeltaValue = moveDelta.GetValue() * moveSwayAmount;

        targetRotation.x -= mouseDeltaValue.y - moveDeltaValue.y;
        targetRotation.y += mouseDeltaValue.x;
        targetRotation.z += mouseDeltaValue.x + moveDeltaValue.x;

        targetRotation.x = Mathf.Clamp(targetRotation.x, -swayClamp, swayClamp);
        targetRotation.y = Mathf.Clamp(targetRotation.y, -swayClamp, swayClamp);
        targetRotation.z = Mathf.Clamp(targetRotation.z, -swayClamp, swayClamp);

        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, speed);
        finalRotation = Vector3.Lerp(finalRotation, targetRotation, speed);

        lerpTarget.transform.localEulerAngles = finalRotation;
    }
}
