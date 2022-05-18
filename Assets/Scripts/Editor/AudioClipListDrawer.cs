using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(GenericReference<List<AudioClip>>))]
public class AudioClipListDrawer : GenericReferenceDrawerWrapper<List<AudioClip>>
{

}
