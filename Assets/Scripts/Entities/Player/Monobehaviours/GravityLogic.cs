using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityLogic : MonoBehaviour
{
    public GenericReference<float> velocity;

    GameObject agent;
    CharacterController controller;
    float gravity;

    public void ApplyGravity(ResultArguments[] arguments)
    {
        agent = arguments[0].objectValue;
        gravity = arguments[0].floatValue;

        if(controller == null)
        {
            controller = agent.GetComponent<CharacterController>();
        }

        velocity.SetValue(velocity.GetValue() + gravity * 2 * Time.deltaTime);
    }

    public void StopApplyingGravity(ResultArguments[] arguments)
    {
        if (velocity.GetValue() > 0)
        {
            velocity.SetValue(0);
        }
    }

    private void FixedUpdate()
    {
        if (controller == null) return;

        controller.Move(Time.deltaTime * velocity.GetValue() * -agent.transform.up);
    }
}
