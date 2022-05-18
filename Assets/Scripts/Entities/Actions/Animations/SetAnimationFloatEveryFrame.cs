using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Set Animator Float Every Frame", menuName = "FSM/Actions/Set Animator Float Every Frame")]
public class SetAnimationFloatEveryFrame : ActionBase
{
    public GenericReference<string> valueName;
    public GenericReference<Path> pathToAnimator;
    public List<GenericReference<float>> value;

    [System.NonSerialized]
    float finalFloat;

    [System.NonSerialized]
    Animator animator;

    public override void Execute(GameObject callingObject)
    {
        return;
    }

    public override void UpdateLoop(GameObject callingObject)
    {
        if (animator == null) animator = pathToAnimator.GetValue().GetObjectAtPath(callingObject).GetComponent<Animator>();
        
        finalFloat = 1;

        for (int i = 0; i < value.Count; i++)
        {
            finalFloat *= value[i].GetValue();
        }

        animator.SetFloat(valueName.GetValue(), finalFloat);
    }

}
