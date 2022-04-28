using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsGrounded : MonoBehaviour
{
    public EventObject notGroundedEvent;
    public EventObject groundedEvent;

    public GenericReference<float> groundCheckRadius;
    public GenericReference<LayerMask> groundLayer;

    public GameObject player;

    public Transform groundCheck;
    public Transform finiteStateMachine;

    FiniteStateMachine currentFiniteStateMachine;

    private void Awake()
    {
        currentFiniteStateMachine = finiteStateMachine.GetComponentInChildren<FiniteStateMachine>();
    }

    void FixedUpdate()
    {
        if (Physics.CheckSphere(groundCheck.position, groundCheckRadius.GetValue(), groundLayer.GetValue()))
        {
            currentFiniteStateMachine.UpdateState(groundedEvent);
        }
        else
        {
            currentFiniteStateMachine.UpdateState(notGroundedEvent);
        }
    }
}
