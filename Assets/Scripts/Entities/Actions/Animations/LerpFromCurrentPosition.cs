using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Lerp From Current Position", menuName = "FSM/Actions/Lerp From Current Position")]
public class LerpFromCurrentPosition : ActionBase
{
    public GenericReference<Vector3> lerpAlongVector;
    public GenericReference<float> speed;
    public GenericReference<float> speedModifier;
    public GenericReference<Path> pathToTarget;

    public GenericReference<Vector3> startPosition;

    [System.NonSerialized]
    Vector3 lerpPosition;
    [System.NonSerialized]
    GameObject lerpTarget;

    public override void Execute(GameObject callingObject)
    {
        return;
    }

    public override void FixedUpdateLoop(GameObject callingObject)
    {
        if(lerpTarget == null) lerpTarget = pathToTarget.GetValue().GetObjectAtPath(callingObject);

        lerpPosition = Vector3.Lerp(lerpPosition, lerpAlongVector.GetValue(), Time.smoothDeltaTime * speed.GetValue() * speedModifier.GetValue());
        lerpTarget.transform.localPosition = lerpPosition + startPosition.GetValue();
    }
}
