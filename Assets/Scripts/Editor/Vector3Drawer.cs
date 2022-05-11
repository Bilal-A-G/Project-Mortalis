using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(GenericReference<Vector3>))]
public class Vector3Drawer : GenericReferenceDrawerWrapper<Vector3>
{

}
