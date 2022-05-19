using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Set Animator Bool", menuName = "FSM/Actions/Set Animator Bool")]
public class SetAnimatorBool : SetAnimatorValue<bool>
{
    public GenericReference<string> valueName;

    public override void Execute(GameObject callingObject)
    {
        base.Execute(callingObject);
        animator.SetBool(valueName.GetValue(), value[0].GetValue());
    }
}
