using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Set Animator Float", menuName = "FSM/Actions/Set Animator Float")]
public class SetAnimationFloat : SetAnimatorValue<float>
{
    public GenericReference<string> valueName;

    [System.NonSerialized]
    float finalFloat;

    public override void Execute(GameObject callingObject)
    {
        base.Execute(callingObject);
        finalFloat = 1;

        for(int i = 0; i < value.Count; i++)
        {
            finalFloat *= value[i].GetValue();
        }

        animator.SetFloat(valueName.GetValue(), finalFloat);

    }
}
