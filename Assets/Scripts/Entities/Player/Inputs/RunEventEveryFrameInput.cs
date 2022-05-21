using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunEventEveryFrameInput : MonoBehaviour
{
    public List<EventObject> events;
    public GameObject callingObject;
    public FiniteStateMachine fsm;

    void Update()
    {
        for(int i = 0; i < events.Count; i++)
        {
            fsm.UpdateState(events[i], callingObject);
        }
    }
}
