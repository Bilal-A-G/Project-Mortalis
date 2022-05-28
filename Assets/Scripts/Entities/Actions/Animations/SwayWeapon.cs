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
    public GenericReference<string> targetKey;

    [System.NonSerialized]
    GameObject lerpTarget;

    public override void Execute(CachedObjectWrapper cachedObjects)
    {
        lerpTarget = cachedObjects.GetGameObjectFromCache(targetKey.GetValue(cachedObjects));

        Vector2 mouseDeltaValue = mouseDelta.GetValue(cachedObjects) * lookSwayAmount.GetValue(cachedObjects);
        Vector2 moveDeltaValue = moveDelta.GetValue(cachedObjects) * moveSwayAmount.GetValue(cachedObjects);

        targetRotation.x -= mouseDeltaValue.y - moveDeltaValue.y;
        targetRotation.y += mouseDeltaValue.x;
        targetRotation.z += mouseDeltaValue.x + moveDeltaValue.x;

        float swayClampValue = swayClamp.GetValue(cachedObjects);

        targetRotation.x = Mathf.Clamp(targetRotation.x, -swayClampValue, swayClampValue);
        targetRotation.y = Mathf.Clamp(targetRotation.y, -swayClampValue, swayClampValue);
        targetRotation.z = Mathf.Clamp(targetRotation.z, -swayClampValue, swayClampValue);

        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, speed.GetValue(cachedObjects));
        finalRotation = Vector3.Lerp(finalRotation, targetRotation, speed.GetValue(cachedObjects));

        lerpTarget.transform.localEulerAngles = finalRotation;
    }
}
