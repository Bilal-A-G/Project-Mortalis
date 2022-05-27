using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Lissajous Curve", menuName = "FSM/Actions/Lissajous Curve")]
public class OutputLissajousCurveValues : ActionBase
{
    public GenericReference<Vector3> lissajousValuesOutput;
    public GenericReference<float> curveScale;
    public GenericReference<float> speed;

    public GenericReference<float> offsetX;
    public GenericReference<float> offsetY;

    [System.NonSerialized]
    float time;
    [System.NonSerialized]
    Vector3 lissajousCurve;

    public override void Execute(CachedObjectWrapper callingObjects)
    {
        lissajousCurve = new Vector3(Mathf.Sin(time), offsetX.GetValue() * Mathf.Sin(offsetY.GetValue() * time + Mathf.PI));

        lissajousValuesOutput.SetValue(lissajousCurve / curveScale.GetValue());
        time += Time.deltaTime;

        if (time > 6) time = 0;
    }
}
