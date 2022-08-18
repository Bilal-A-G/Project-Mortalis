using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(GenericReference<AnimationCurve>))]
public class AnimationCurveDrawer : GenericReferenceDrawer<AnimationCurve>
{

}
