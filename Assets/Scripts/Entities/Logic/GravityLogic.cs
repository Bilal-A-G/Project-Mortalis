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
        velocity.SetValue(velocity.GetValue() + gravity.GetValue() * 2 * Time.deltaTime);

        controller.Move(Time.deltaTime * velocity.GetValue() * -agent.transform.up);
    }

    public void StopApplyingGravity()
    {
        if (velocity.GetValue() > 0)
        {
            velocity.SetValue(0);
        }

        controller.Move(Time.deltaTime * velocity.GetValue() * -agent.transform.up);
    }
}
