using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Translate Delta", menuName = "FSM/Actions/Translate Delta To Rotation")]
public class TranslateDeltaToRotation : ActionBase
{
    public GenericReference<Vector2> delta;
    public GenericReference<Vector3> eulerRotation;

    public List<GenericReference<float>> rotationInfluences;

    public override void Execute(GameObject callingObject)
    {
        Vector2 valuesToUse = delta.GetValue();
        float rotationScale = 1;

        for(int i = 0; i < rotationInfluences.Count; i++)
        {
            rotationScale *= rotationInfluences[i].GetValue();
        }

        eulerRotation.SetValue(new Vector3(valuesToUse.y, 0, valuesToUse.x) * rotationScale);
    }
}
