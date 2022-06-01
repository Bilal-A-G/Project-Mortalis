using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableInput : MonoBehaviour
{
    public EventObject eventToFire;
    public CachedObjectWrapper cachedObjects;
    public GameObject callingObject;

    private void OnEnable()
    {
        eventToFire.Invoke(callingObject);
    }
}
