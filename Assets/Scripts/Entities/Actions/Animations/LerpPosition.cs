using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Lerp Position", menuName = "FSM/Actions/Lerp Position")]
public class LerpPosition : ActionBase
{
    public EventObject onLerpStart;
    public EventObject onLerpKickback;
    public EventObject onLerpEnd;

    public GenericReference<Vector3> endVector;

    public GenericReference<Path> lerpTargetPath;

    public GenericReference<float> speed;
    public GenericReference<float> kickbackSpeed;
    public GenericReference<float> tolorence;

    protected bool isDoingKickback;
    protected bool debounce;
    protected GameObject lerpTarget;
    protected GameObject callingObject;
    protected Vector3 startVector;

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

        if (onLerpStart != null) onLerpStart.Invoke(callingObject);
    }

    protected virtual void SetUpStartVector()
    {
        startVector = lerpTarget.transform.localPosition;
    }

    public override void Update()
    {
        if (!debounce) return;

        if (!isDoingKickback)
        {
            if (LerpToEnd(endVector.GetValue(), speed.GetValue()))
            {
                isDoingKickback = true;

                if(onLerpKickback != null) onLerpKickback.Invoke(callingObject);
            }
        }
        else
        {
            if (LerpToEnd(startVector, kickbackSpeed.GetValue()))
            {
                isDoingKickback = false;
                debounce = false;

                if (onLerpEnd != null) onLerpEnd.Invoke(callingObject);
            }
        }
    }

    protected virtual bool LerpToEnd(Vector3 endPosition, float speed)
    {
        lerpTarget.transform.localPosition = Vector3.Lerp(lerpTarget.transform.localPosition, endPosition, speed * Time.deltaTime);

        if ((endPosition - lerpTarget.transform.localPosition).magnitude <= tolorence.GetValue())
        {
            return true;
        }

        return false;
    }

    protected void OnDisable()
    {
        debounce = false;
        isDoingKickback = false;
        lerpTarget = null;
    }
}
