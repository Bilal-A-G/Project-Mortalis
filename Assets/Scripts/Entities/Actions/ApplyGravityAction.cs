using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gravity Action", menuName = "FSM/Actions/Apply Gravity Action")]
public class ApplyGravityAction : ActionBase
{
    public GenericReference<float> velocity;
    public GenericReference<float> gravity;
    public GenericReference<bool> applyGravity;

    CharacterController controller;

    public override void Execute(GameObject callingObject)
    {
        if (controller == null) controller = callingObject.GetComponent<CharacterController>();

        if (applyGravity.GetValue())
        {
            velocity.SetValue(velocity.GetValue() + gravity.GetValue() * 2 * Time.deltaTime);
        }
        else
        {
            if (velocity.GetValue() > 0)
            {
                velocity.SetValue(0);
            }
        }

        controller.Move(Time.deltaTime * velocity.GetValue() * -callingObject.transform.up);
    }
}
