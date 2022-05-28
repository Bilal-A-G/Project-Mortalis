using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Modded Variables/Functions/Output Lissajous Curve")]
public class OutputLissajousCurveVector : GenericValue<Vector3>
{
    public GenericReference<float> curveScale;
    public GenericReference<float> speed;

    public GenericReference<float> offsetX;
    public GenericReference<float> offsetY;

    [System.NonSerialized]
    float time;
    [System.NonSerialized]
    Vector3 lissajousCurve;


    public override Vector3 GetValue(CachedObjectWrapper cachedObjects)
    {
        lissajousCurve = new Vector3(Mathf.Sin(time), offsetX.GetValue(cachedObjects) * Mathf.Sin(offsetY.GetValue(cachedObjects) * time + Mathf.PI));
        time += Time.deltaTime;

        if (time > 6) time = 0;

        return lissajousCurve / curveScale.GetValue(cachedObjects);
    }

    public override void SetValue(Vector3 value, CachedObjectWrapper cachedObjects)
    {
        return;
    }
}
