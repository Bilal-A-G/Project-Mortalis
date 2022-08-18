using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(GenericReference<LayerMask>))]
public class LayerMaskRefrenceDrawer : GenericReferenceDrawer<LayerMask>
{

}
