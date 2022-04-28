using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpLogic : MonoBehaviour
{
    public GenericReference<float> velocity;
    public GenericReference<float> jumpHeight;
    public GenericReference<float> gravity;

    public void Jump()
    {
        velocity.SetValue(jumpHeight.GetValue() * -gravity.GetValue());
    }
}
