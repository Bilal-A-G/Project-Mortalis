using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSphereInput : MonoBehaviour
{
    public EventObject notContactingEvent;
    public EventObject contactingEvent;
    public CachedObjectWrapper cachedObjects;

    public GenericReference<float> checkRadius;
    public GenericReference<LayerMask> checkLayer;

    public Transform checkEmpty;
    public FiniteStateMachine finiteStateMachine;

    public GameObject callingObject;

    void FixedUpdate()
    {
        if (Physics.CheckSphere(checkEmpty.position, checkRadius.GetValue(cachedObjects), checkLayer.GetValue(cachedObjects)))
        {
            finiteStateMachine.UpdateState(contactingEvent, callingObject, cachedObjects);
        }
        else
        {
            finiteStateMachine.UpdateState(notContactingEvent, callingObject, cachedObjects);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(checkEmpty.position, checkRadius.GetValue(cachedObjects));
    }
}
