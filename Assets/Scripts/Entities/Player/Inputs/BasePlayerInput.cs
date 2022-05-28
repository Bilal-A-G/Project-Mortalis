using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlayerInput : MonoBehaviour
{
    protected InputActions inputActions;
    public GameObject callingObject;
    public CachedObjectWrapper cachedObjects;

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}
