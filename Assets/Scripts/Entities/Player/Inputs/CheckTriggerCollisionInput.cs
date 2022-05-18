using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTriggerCollisionInput : MonoBehaviour
{
    public EventObject onEntered;
    public EventObject onExited;

    public FiniteStateMachine fsm;
    public GameObject parentObject;

    bool entered;

    private void OnTriggerEnter(Collider other)
    {
        if (entered) return;

        entered = true;
        if(onEntered != null) fsm.UpdateState(onEntered, parentObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!entered) return;

        entered = false;
        if (onExited != null) fsm.UpdateState(onExited, parentObject);
    }
}
