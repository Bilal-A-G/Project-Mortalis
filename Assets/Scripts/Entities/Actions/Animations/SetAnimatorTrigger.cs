using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Set Animator Trigger", menuName = "FSM/Actions/Set Animator Trigger")]
public class SetAnimatorTrigger : ActionBase
{
    public GenericReference<string> value;
    public GenericReference<Path> pathToAnimator;

    [System.NonSerialized]
    Animator animator;

    public override void Execute(GameObject callingObject)
    {
        if (animator == null) animator = pathToAnimator.GetValue().GetObjectAtPath(callingObject).GetComponent<Animator>();
        animator.SetTrigger(value.GetValue());
    }
}
