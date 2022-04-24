using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsGrounded : MonoBehaviour
{
    public EventObject notGroundedEvent;
    public EventObject groundedEvent;

    public GenericReference<float> groundCheckRadius;
    public GenericReference<LayerMask> groundLayer;

    public GenericReference<float> gravity;
    public GameObject player;

    public Transform groundCheck;
    public Transform finiteStateMachine;

    FiniteStateMachine currentFiniteStateMachine;

    List<ResultArguments> argumentsToPass;
    ResultArguments argument;

    private void Start()
    {
        currentFiniteStateMachine = finiteStateMachine.GetComponentInChildren<FiniteStateMachine>();

        argumentsToPass = new List<ResultArguments>();
        argument = new ResultArguments();
        argumentsToPass.Add(argument);
    }

    void FixedUpdate()
    {
        if (Physics.CheckSphere(groundCheck.position, groundCheckRadius.GetValue(), groundLayer.GetValue()))
        {
            currentFiniteStateMachine.UpdateState(groundedEvent, argumentsToPass);
        }
        else
        {
            argument.floatValue = gravity.GetValue();
            argument.objectValue = player;

            argumentsToPass[0] = argument;

            currentFiniteStateMachine.UpdateState(notGroundedEvent, argumentsToPass);
        }
    }
}
