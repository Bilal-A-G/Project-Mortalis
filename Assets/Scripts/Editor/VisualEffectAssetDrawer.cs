using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.VFX;

[CustomPropertyDrawer(typeof(GenericReference<VisualEffectAsset>))]
public class VisualEffectAssetDrawer : GenericReferenceDrawerWrapper<VisualEffectAsset>
{

}
