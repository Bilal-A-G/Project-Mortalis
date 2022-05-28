using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Set Animator Float", menuName = "FSM/Actions/Set Animator Float")]
public class SetAnimatorFloat : SetAnimatorValue<float>
{
    public GenericReference<string> valueName;

    public override void Execute(CachedObjectWrapper cachedObjects)
    {
        base.Execute(cachedObjects);

        animator.SetFloat(valueName.GetValue(cachedObjects), value.GetValue(cachedObjects));

    }
}
