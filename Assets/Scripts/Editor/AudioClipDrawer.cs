using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(GenericReference<AudioClip>))]
public class AudioClipDrawer : GenericReferenceDrawer<AudioClip>
{

}
