using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Actions/Move")]

public class Move : ActionBase
{
    public GenericReference<float> moveSpeed;
    public GenericReference<Vector2> moveDirection;
    public GenericReference<string> agentKey;

    [System.NonSerialized]
    CharacterController characterController;

    [System.NonSerialized]
    GameObject agent;

    public override void Execute(CachedObjectWrapper cachedObjects)
    {
        agent = cachedObjects.GetGameObjectFromCache(agentKey.GetValue(cachedObjects));
        characterController = agent.GetComponent<CharacterController>();

        characterController.Move(moveSpeed.GetValue(cachedObjects) * Time.deltaTime * ((agent.transform.forward * moveDirection.GetValue(cachedObjects).y) + agent.transform.right * moveDirection.GetValue(cachedObjects).x));
    }
}
