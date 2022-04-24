using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityLogic : MonoBehaviour
{
    GameObject agent;
    CharacterController controller;
    float gravity;

    float velocity;

    bool applyGravity;

    public void ApplyGravity(ResultArguments[] arguments)
    {
        agent = arguments[0].objectValue;
        gravity = arguments[0].floatValue;

        if(controller == null)
        {
            controller = agent.GetComponent<CharacterController>();
        }
        applyGravity = true;
    }

    public void StopApplyingGravity(ResultArguments[] arguments) => applyGravity = false;

    public void Jump(ResultArguments[] arguments)
    {
        velocity = arguments[0].floatValue * -gravity;
    }

    private void FixedUpdate()
    {
        if (agent == null || controller == null) return;

        if (applyGravity)
        {
            velocity += gravity * 2 * Time.deltaTime;
        }
        else if(!applyGravity && velocity > 0)
        {
            velocity = 0;
        }

        controller.Move(-agent.transform.up * velocity * Time.deltaTime);
    }
}
