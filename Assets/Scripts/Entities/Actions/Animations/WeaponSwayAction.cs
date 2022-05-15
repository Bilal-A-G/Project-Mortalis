using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Sway Action", menuName = "FSM/Actions/Weapon Sway Action")]
public class WeaponSwayAction : ActionBase
{
    Vector3 targetRotation;
    Vector3 finalRotation;

    public GenericReference<Vector2> mouseDelta;
    public GenericReference<Vector2> moveDelta;

    public List<GenericReference<float>> lookSwayAmount;
    public List<GenericReference<float>> moveSwayAmount;

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

        float lookSwayValue = 1;
        float moveSwayValue = 1;

        for (int i = 0; i < lookSwayAmount.Count; i++)
        {
            lookSwayValue *= lookSwayAmount[i].GetValue();
        }

        for (int i = 0; i < moveSwayAmount.Count; i++)
        {
            moveSwayValue *= moveSwayAmount[i].GetValue();
        }

        Vector2 mouseDeltaValue = mouseDelta.GetValue() * lookSwayValue;
        Vector2 moveDeltaValue = moveDelta.GetValue() * moveSwayValue;

        targetRotation.x -= mouseDeltaValue.y - moveDeltaValue.y;
        targetRotation.y += mouseDeltaValue.x;
        targetRotation.z += mouseDeltaValue.x + moveDeltaValue.x;

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
