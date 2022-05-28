using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Lerp Position", menuName = "FSM/Actions/Lerp Position")]
public class LerpPosition : ActionBase
{
    public ActionBase onLerpStart;
    public ActionBase onKickback;
    public ActionBase onLerpEnd;

    public GenericReference<Vector3> endVector;

    public GenericReference<string> targetKey;

    public GenericReference<float> currentSpeed;
    public GenericReference<bool> resetVector;

    public GenericReference<float> tolorence;
    public GenericReference<float> animationDuration;
    public GenericReference<AnimationCurve> easingFunction;

    [System.NonSerialized]
    protected bool debounce;
    [System.NonSerialized]
    protected GameObject lerpTarget;
    [System.NonSerialized]
    protected CachedObjectWrapper callingObject;
    [System.NonSerialized]
    protected Vector3 startVector;
    [System.NonSerialized]
    protected float timeSinceExecuted;

    [System.NonSerialized]
    protected bool didKickback;

    public override void Execute(CachedObjectWrapper cachedObjects)
    {
        this.callingObject = cachedObjects;

        lerpTarget = cachedObjects.GetGameObjectFromCache(targetKey.GetValue(cachedObjects));

        if (debounce) return;

        debounce = true;
        didKickback = false;
        timeSinceExecuted = 0;

        SetUpStartVector();

        if (onLerpStart != null) onLerpStart.Execute(cachedObjects);
    }

    protected virtual void SetUpStartVector()
    {
        startVector = lerpTarget.transform.localPosition;
    }

    public override void FixedUpdateLoop(CachedObjectWrapper cachedObjects)
    {
        if (!debounce) return;

        timeSinceExecuted += Time.deltaTime * currentSpeed.GetValue(cachedObjects);

        if (LerpToEnd(cachedObjects))
        {
            if (onLerpEnd != null) onLerpEnd.Execute(cachedObjects);

            if(resetVector.GetValue(cachedObjects)) ResetLerpedProperty();

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

        if(!didKickback && timeSinceExecuted >= animationDurationValue / 2)
        {
            didKickback = true;
            if(onKickback != null) onKickback.Execute(callingObject);
        }

        if (underMaximum && overMinimum || overMaximum) return true;

        return false;
    }

    protected virtual void LerpProperty(Vector3 startPosition, Vector3 endPosition, CachedObjectWrapper cachedObjects)
    {
        lerpTarget.transform.localPosition = Vector3.LerpUnclamped(startPosition, endPosition, easingFunction.GetValue(cachedObjects).Evaluate(timeSinceExecuted));
    }

    protected virtual void ResetLerpedProperty()
    {
        lerpTarget.transform.localPosition = startVector;
    }

}
