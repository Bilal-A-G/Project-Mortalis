using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunEventOnFixedUpdateInput : MonoBehaviour
{
    public List<EventObject> events;
    public GameObject callingObject;
    public FiniteStateMachine fsm;
    public CachedObjectWrapper cachedObjects;

    void FixedUpdate()
    {
        for(int i = 0; i < events.Count; i++)
        {
            fsm.UpdateState(events[i], callingObject, cachedObjects);
        }
    }
}
