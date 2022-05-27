using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Action Block")]
public class ActionBlock : ActionBase
{
    public List<ActionBase> actions;

    public override void Execute(CachedObjectWrapper callingObjects)
    {
        for(int i = 0; i < actions.Count; i++)
        {
            actions[i].Execute(callingObjects);
        }
    }

    public override void FixedUpdateLoop(CachedObjectWrapper callingObjects)
    {
        for (int i = 0; i < actions.Count; i++)
        {
            actions[i].FixedUpdateLoop(callingObjects);
        }
    }

    public override void UpdateLoop(CachedObjectWrapper callingObjects)
    {
        for (int i = 0; i < actions.Count; i++)
        {
            actions[i].UpdateLoop(callingObjects);
        }
    }
}
