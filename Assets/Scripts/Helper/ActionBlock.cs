using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Action Block")]
public class ActionBlock : ActionBase
{
    public List<ActionBase> actions;

    public override void Execute(GameObject callingObject)
    {
        for(int i = 0; i < actions.Count; i++)
        {
            actions[i].Execute(callingObject);
        }
    }

    public override void FixedUpdateLoop(GameObject callingObject)
    {
        for (int i = 0; i < actions.Count; i++)
        {
            actions[i].FixedUpdateLoop(callingObject);
        }
    }

    public override void UpdateLoop(GameObject callingObject)
    {
        for (int i = 0; i < actions.Count; i++)
        {
            actions[i].UpdateLoop(callingObject);
        }
    }
}
