using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Actions/Apply Gravity")]
public class ApplyGravity : ActionBase
{
    public GenericReference<float> velocity;
    public GenericReference<float> gravity;
    public GenericReference<bool> applyGravity;
    public GenericReference<float> stickToGroundForce;

    [System.NonSerialized]
    CharacterController controller;

    public override void Execute(GameObject callingObject)
    {
        controller = callingObject.GetComponent<CharacterController>();

        if (applyGravity.GetValue())
        {
            velocity.SetValue(velocity.GetValue() + gravity.GetValue() * 2 * Time.deltaTime);
        }
        else
        {
            if ((int)velocity.GetValue() > 0)
            {
                velocity.SetValue(stickToGroundForce.GetValue());
            }
        }

        controller.Move(Time.deltaTime * velocity.GetValue() * -Vector3.up);
    }
}
