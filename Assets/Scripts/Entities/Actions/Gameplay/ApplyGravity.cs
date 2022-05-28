using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Actions/Apply Gravity")]
public class ApplyGravity : ActionBase
{
    public GenericReference<float> velocity;
    public GenericReference<float> gravity;
    public GenericReference<bool> applyGravity;
    public GenericReference<float> stickToGroundForce;

    public GenericReference<string> agentKey;

    [System.NonSerialized]
    CharacterController controller;

    public override void Execute(CachedObjectWrapper cachedObjects)
    {
        controller = cachedObjects.GetGameObjectFromCache(agentKey.GetValue(cachedObjects)).GetComponent<CharacterController>();

        if (applyGravity.GetValue(cachedObjects))
        {
            velocity.SetValue(velocity.GetValue(cachedObjects) + gravity.GetValue(cachedObjects) * 2 * Time.deltaTime, cachedObjects);
        }
        else
        {
            if ((int)velocity.GetValue(cachedObjects) > 0)
            {
                velocity.SetValue(stickToGroundForce.GetValue(cachedObjects), cachedObjects);
            }
        }

        controller.Move(Time.deltaTime * velocity.GetValue(cachedObjects) * -Vector3.up);
    }
}
