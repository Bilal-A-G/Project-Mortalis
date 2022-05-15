using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Lerp Position", menuName = "FSM/Actions/Lerp Position")]
public class LerpPosition : ActionBase
{
    public EventObject onLerpStart;
    public EventObject onKickback;
    public EventObject onLerpEnd;

    public GenericReference<Vector3> endVector;

    public GenericReference<Path> lerpTargetPath;

    public GenericReference<float> speed;
    public GenericReference<float> tolorence;
    public GenericReference<float> animationDuration;
    public GenericReference<AnimationCurve> easingFunction;

    protected bool debounce;
    protected GameObject lerpTarget;
    protected GameObject callingObject;
    protected Vector3 startVector;
    protected float timeSinceExecuted;

    protected float lastFrameEvaluation;
    protected float thisFrameEvaluation;
    protected bool didKickback;

    public override void Execute(GameObject callingObject)
    {
        this.callingObject = callingObject;

        if(lerpTarget == null)
        {
            lerpTarget = lerpTargetPath.GetValue().GetObjectAtPath(callingObject);
            SetUpStartVector();
        }

        if (debounce) return;
        debounce = true;
        didKickback = false;
        timeSinceExecuted = 0;

        if (onLerpStart != null) onLerpStart.Invoke(callingObject);
    }

    protected virtual void SetUpStartVector()
    {
        startVector = lerpTarget.transform.localPosition;
    }

    public override void FixedUpdate()
    {
        if (!debounce) return;

        timeSinceExecuted += Time.deltaTime * speed.GetValue();

        if (LerpToEnd(startVector, endVector.GetValue()))
        {
            if (onLerpEnd != null) onLerpEnd.Invoke(callingObject);
            debounce = false;
        }
    }

    protected bool LerpToEnd(Vector3 startPosition, Vector3 endPosition)
    {
        lastFrameEvaluation = thisFrameEvaluation;
        thisFrameEvaluation = easingFunction.GetValue().Evaluate(timeSinceExecuted);

        LerpProperty(startPosition, endPosition);

        bool underMaximum = timeSinceExecuted < animationDuration.GetValue() + tolorence.GetValue();
        bool overMinimum = timeSinceExecuted > animationDuration.GetValue() - tolorence.GetValue();

        bool overMaximum = timeSinceExecuted > animationDuration.GetValue() + tolorence.GetValue();

        if(!didKickback && thisFrameEvaluation - lastFrameEvaluation <= 0)
        {
            didKickback = true;
            if(onKickback != null) onKickback.Invoke(callingObject);
        }

        if (underMaximum && overMinimum || overMaximum) return true;

        return false;
    }

    protected virtual void LerpProperty(Vector3 startPosition, Vector3 endPosition)
    {
        lerpTarget.transform.localPosition = Vector3.LerpUnclamped(startPosition, endPosition, thisFrameEvaluation);
    }

    protected void OnDisable()
    {
        debounce = false;
        lerpTarget = null;
        didKickback = false;
    }
}
