using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Set Animator Float", menuName = "FSM/Actions/Set Animator Float")]
public class SetAnimatorFloat : SetAnimatorValue<float>
{
    public GenericReference<string> valueName;

    public override void Execute(CachedObjectWrapper callingObject)
    {
        base.Execute(callingObject);

        animator.SetFloat(valueName.GetValue(), value.GetValue());

    }
}
