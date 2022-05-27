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

    public override void Execute(CachedObjectWrapper callingObjects)
    {
        if (debounce) return;

        debounce = true;
        timeSinceExecuted = 0;

        callingObject = callingObjects.GetGameObjectFromCache(callingObjectKey);
        startVector = callingObjects.GetGameObjectFromCache(instantiatePositionKey).transform.position;

        lerpTarget = Instantiate(lerpObject, callingObject.transform);
        lerpTarget.transform.position = startVector;
    }

    public override void FixedUpdateLoop(CachedObjectWrapper callingObject)
    {
        if (!debounce) return;

        timeSinceExecuted += Time.deltaTime * currentSpeed.GetValue();

        if (LerpToEnd())
        {
            if (onLerpEnd != null) onLerpEnd.Execute(callingObject);
 
            Destroy(lerpTarget);

            debounce = false;
        }
    }

    protected bool LerpToEnd()
    {
        LerpProperty(startVector, endVector.GetValue());

        bool underMaximum = timeSinceExecuted < animationDuration.GetValue() + tolorence.GetValue();
        bool overMinimum = timeSinceExecuted > animationDuration.GetValue() - tolorence.GetValue();

        bool overMaximum = timeSinceExecuted > animationDuration.GetValue() + tolorence.GetValue();

        if (underMaximum && overMinimum || overMaximum) return true;

        return false;
    }

    protected virtual void LerpProperty(Vector3 startPosition, Vector3 endPosition)
    {
        lerpTarget.transform.position = Vector3.LerpUnclamped(startPosition, endPosition, easingFunction.GetValue().Evaluate(timeSinceExecuted));
    }
}
