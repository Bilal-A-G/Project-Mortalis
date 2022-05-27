using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Set Animator Trigger", menuName = "FSM/Actions/Set Animator Trigger")]
public class SetAnimatorTrigger : ActionBase
{
    public GenericReference<string> value;
    public GenericReference<string> animatorKey;

    [System.NonSerialized]
    Animator animator;

    public override void Execute(CachedObjectWrapper callingObjects)
    {
        animator = callingObjects.GetGameObjectFromCache(animatorKey).GetComponent<Animator>();
        
        animator.SetTrigger(value.GetValue());
    }
}
