using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Jump Action", menuName = "FSM/Actions/Jump Action")]
public class JumpAction : ActionBase
{
    public GenericReference<float> velocity;
    public GenericReference<float> jumpHeight;
    public GenericReference<float> gravity;
    public GenericReference<float> stickToGroundForce;

    public override void Execute(GameObject _)
    {
        velocity.SetValue(jumpHeight.GetValue() * -gravity.GetValue() * stickToGroundForce.GetValue());
    }
}
