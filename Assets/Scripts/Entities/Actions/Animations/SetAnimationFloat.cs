using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Set Animator Float", menuName = "FSM/Actions/Set Animator Float")]
public class SetAnimationFloat : SetAnimatorValue<float>
{
    public GenericReference<string> valueName;

    public override void Execute(GameObject callingObject)
    {
        base.Execute(callingObject);

        animator.SetFloat(valueName.GetValue(), value.GetValue());

    }
}
