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

    void FixedUpdate()
    {
        if (Physics.CheckSphere(checkEmpty.position, checkRadius.GetValue(), checkLayer.GetValue()))
        {
            finiteStateMachine.UpdateState(contactingEvent);
        }
        else
        {
            finiteStateMachine.UpdateState(notContactingEvent);
        }
    }
}
