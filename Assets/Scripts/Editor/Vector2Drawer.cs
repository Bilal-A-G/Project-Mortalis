using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(GenericReference<Vector2>))]
public class Vector2Drawer : GenericReferenceDrawerWrapper<Vector2>
{

}
