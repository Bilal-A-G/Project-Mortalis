using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGroundedInput : MonoBehaviour
{
    public CharacterController controller;
    public EventObject notContactingEvent;
    public EventObject contactingEvent;
    public FiniteStateMachine finiteStateMachine;

    public GameObject callingObject;

    void Update()
    {
        if (controller.isGrounded)
        {
            finiteStateMachine.UpdateState(contactingEvent, callingObject);
        }
        else
        {
            finiteStateMachine.UpdateState(notContactingEvent, callingObject);
        }
    }
}
