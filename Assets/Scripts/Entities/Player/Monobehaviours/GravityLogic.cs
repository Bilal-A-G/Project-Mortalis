using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityLogic : MonoBehaviour
{
    public GenericReference<float> velocity;
    public GenericReference<float> gravity;
    public GameObject agent;

    CharacterController controller;

    private void Awake()
    {
        controller = agent.GetComponent<CharacterController>();
    }

    public void ApplyGravity()
    {
        if(controller == null)
        {
            controller = agent.GetComponent<CharacterController>();
        }

        velocity.SetValue(velocity.GetValue() + gravity.GetValue() * 2 * Time.deltaTime);
    }

    public void StopApplyingGravity()
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
