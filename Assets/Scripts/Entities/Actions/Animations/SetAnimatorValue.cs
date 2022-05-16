using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorValue<T> : ActionBase
{
    public GenericReference<Path> pathToAnimator;
    public GenericReference<T> value;
    protected Animator animator;

    public override void Execute(GameObject callingObject)
    {
        animator = pathToAnimator.GetValue().GetObjectAtPath(callingObject).GetComponent<Animator>();
    }
}
