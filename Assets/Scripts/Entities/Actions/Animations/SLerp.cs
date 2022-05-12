using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SLerp", menuName = "FSM/Actions/SLerp")]
public class SLerp : ActionBase
{
    public GenericReference<Path> lerpObjectPath;
    public EventObject onStartLerp;
    public EventObject onEndLerp;
    public GenericReference<float> lerpSpeed;
    public GenericReference<float> rotationSpeed;
    public GenericReference<float> tolorence;
    public GenericReference<Vector3> localEndPosition;

    bool debounce;
    GameObject lerpObject;
    GameObject callingObject;
    Vector3 lerpObjectStartPosition;
    Quaternion lerpObjectStartRotation;

    public override void Execute(GameObject callingObject)
    {
        this.callingObject = callingObject;

        if (lerpObject == null)
        {
            lerpObject = lerpObjectPath.GetValue().GetObjectAtPath(callingObject);
            lerpObjectStartPosition = lerpObject.transform.localPosition;
            lerpObjectStartRotation = lerpObject.transform.localRotation;
        }

        if (debounce) return;

        debounce = true;

        if(onStartLerp != null) onStartLerp.Invoke(callingObject);
    }

    public override void Update()
    {
        if (!debounce) return;

        lerpObject.transform.localPosition = Vector3.Slerp(lerpObject.transform.localPosition, localEndPosition.GetValue(), lerpSpeed.GetValue());
        lerpObject.transform.Rotate(lerpObject.transform.up, rotationSpeed.GetValue());

        if ((localEndPosition.GetValue() - lerpObject.transform.localPosition).magnitude <= tolorence.GetValue())
        {
            debounce = false;
            if(onEndLerp != null) onEndLerp.Invoke(callingObject);
            lerpObject.transform.localPosition = lerpObjectStartPosition;
            lerpObject.transform.localRotation = lerpObjectStartRotation;
        }
    }

    private void OnDisable()
    {
        debounce = false;
        lerpObject = null;
    }
}
