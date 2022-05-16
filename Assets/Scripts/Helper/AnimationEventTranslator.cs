using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventTranslator : MonoBehaviour
{
    public GameObject parentObject;

    public void InvokeEvent(EventObject eventToInvoke)
    {
        eventToInvoke.Invoke(parentObject);
    }
}
