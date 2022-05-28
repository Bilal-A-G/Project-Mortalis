using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Actions/Jump")]
public class Jump : ActionBase
{
    public GenericReference<float> velocity;
    public GenericReference<float> jumpHeight;
    public GenericReference<float> gravity;

    public override void Execute(CachedObjectWrapper cachedObjects)
    {
        velocity.SetValue(jumpHeight.GetValue(cachedObjects) * -gravity.GetValue(cachedObjects), cachedObjects);
    }
}
