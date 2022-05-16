using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Set Animator Trigger", menuName = "FSM/Actions/Set Animator Trigger")]
public class SetAnimatorTrigger : SetAnimatorValue<string>
{
    public override void Execute(GameObject callingObject)
    {
        base.Execute(callingObject);
        animator.SetTrigger(value.GetValue());
    }
}
