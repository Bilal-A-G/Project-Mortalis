using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventListener : EventListenerBase
{
    public List<EventAnimationPairs> eventAnimationPairs;
    public GameObject parentObject;

    public override void OnInvoke(EventObject callingEvent, GameObject callingObject)
    {
        if(callingObject != parentObject && callingObject != null)  return;

        for (int i = 0; i < eventAnimationPairs.Count; i++)
        {
            for (int v = 0; v < eventAnimationPairs[i].events.Count; v++)
            {
                if(callingEvent == eventAnimationPairs[i].events[v])
                {
                    for(int z = 0; z < eventAnimationPairs[i].animations.Count; z++)
                    {
                        Debug.Log("Played animation " + eventAnimationPairs[i].animations[z]);
                    }
                }
            }
        }
    }

    protected override void SubscribeToEvents()
    {
        for(int i = 0; i < eventAnimationPairs.Count; i++)
        {
            for(int v = 0; v < eventAnimationPairs[i].events.Count; v++)
            {
                eventAnimationPairs[i].events[v].Subscribe(this);
            }
        }
    }

    protected override void UnSubscribeFromEvents()
    {
        for (int i = 0; i < eventAnimationPairs.Count; i++)
        {
            for (int v = 0; v < eventAnimationPairs[i].events.Count; v++)
            {
                eventAnimationPairs[i].events[v].UnSubscribe(this);
            }
        }
    }
}

[System.Serializable]
public struct EventAnimationPairs
{
    public List<EventObject> events;
    public List<string> animations;
}
