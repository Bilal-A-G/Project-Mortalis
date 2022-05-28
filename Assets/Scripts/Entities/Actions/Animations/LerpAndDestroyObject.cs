using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Lerp And Destroy", menuName = "FSM/Actions/Lerp And Destroy")]
public class LerpAndDestroyObject : ActionBase
{
    public ActionBase onLerpEnd;
    public GenericReference<string> callingObjectKey;
    public GenericReference<string> instantiatePositionKey;

    public GenericReference<Vector3> endVector;

    public GameObject lerpObject;

    public GenericReference<float> currentSpeed;

    public GenericReference<float> tolorence;
    public GenericReference<float> animationDuration;
    public GenericReference<AnimationCurve> easingFunction;

    [System.NonSerialized]
    protected bool debounce;
    [System.NonSerialized]
    protected GameObject lerpTarget;
    [System.NonSerialized]
    protected float timeSinceExecuted;

    [System.NonSerialized]
    Vector3 startVector;

    [System.NonSerialized]
    GameObject callingObject;

    public override void Execute(CachedObjectWrapper cachedObjects)
    {
        if (debounce) return;

        debounce = true;
        timeSinceExecuted = 0;

        callingObject = cachedObjects.GetGameObjectFromCache(callingObjectKey.GetValue(cachedObjects));
        startVector = cachedObjects.GetGameObjectFromCache(instantiatePositionKey.GetValue(cachedObjects)).transform.position;

        lerpTarget = Instantiate(lerpObject, callingObject.transform);
        lerpTarget.transform.position = startVector;
    }

    public override void FixedUpdateLoop(CachedObjectWrapper cachedObjects)
    {
        if (!debounce) return;

        timeSinceExecuted += Time.deltaTime * currentSpeed.GetValue(cachedObjects);

        if (LerpToEnd(cachedObjects))
        {
            if (onLerpEnd != null) onLerpEnd.Execute(cachedObjects);
 
            Destroy(lerpTarget);

            debounce = false;
        }
    }

    protected bool LerpToEnd(CachedObjectWrapper cachedObjects)
    {
        LerpProperty(startVector, endVector.GetValue(cachedObjects), cachedObjects);

        float animationDurationValue = animationDuration.GetValue(cachedObjects);
        float tolorenceValue = tolorence.GetValue(cachedObjects);

        bool underMaximum = timeSinceExecuted < animationDurationValue + tolorenceValue;
        bool overMinimum = timeSinceExecuted > animationDurationValue - tolorenceValue;

        bool overMaximum = timeSinceExecuted > animationDurationValue + tolorenceValue;

        if (underMaximum && overMinimum || overMaximum) return true;

        return false;
    }

    protected virtual void LerpProperty(Vector3 startPosition, Vector3 endPosition, CachedObjectWrapper cachedObjects)
    {
        lerpTarget.transform.position = Vector3.LerpUnclamped(startPosition, endPosition, easingFunction.GetValue(cachedObjects).Evaluate(timeSinceExecuted));
    }
}
