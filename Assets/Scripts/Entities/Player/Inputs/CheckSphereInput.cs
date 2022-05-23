using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSphereInput : MonoBehaviour
{
    public EventObject notContactingEvent;
    public EventObject contactingEvent;

    public GenericReference<float> checkRadius;
    public GenericReference<LayerMask> checkLayer;

    public Transform checkEmpty;
    public FiniteStateMachine finiteStateMachine;

    public GameObject callingObject;

    void FixedUpdate()
    {
        if (Physics.CheckSphere(checkEmpty.position, checkRadius, checkLayer.GetValue()))
        {
            finiteStateMachine.UpdateState(contactingEvent, callingObject);
        }
        else
        {
            finiteStateMachine.UpdateState(notContactingEvent, callingObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(checkEmpty.position, checkRadius);
    }
}
