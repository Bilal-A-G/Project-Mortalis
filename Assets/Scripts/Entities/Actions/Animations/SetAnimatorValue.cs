using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorValue<T> : ActionBase
{
    public GenericReference<Path> pathToAnimator;
    public List<GenericReference<T>> value;

    [System.NonSerialized]
    protected Animator animator;

    public override void Execute(GameObject callingObject)
    {
       if(animator == null) animator = pathToAnimator.GetValue().GetObjectAtPath(callingObject).GetComponent<Animator>();
    }
}
