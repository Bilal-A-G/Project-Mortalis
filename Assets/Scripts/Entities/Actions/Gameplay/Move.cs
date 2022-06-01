using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Actions/Move")]

public class Move : ActionBase
{
    public GenericReference<float> moveSpeed;
    public GenericReference<float> minMoveSpeed;
    public GenericReference<float> smoothing;
    public GenericReference<Vector2> moveDirection;
    public GenericReference<string> agentKey;

    [System.NonSerialized]
    CharacterController characterController;

    [System.NonSerialized]
    GameObject agent;

    [System.NonSerialized]
    Vector2 refrenceVelocity;

    [System.NonSerialized]
    Vector2 currentMovement;

    public override void Execute(CachedObjectWrapper cachedObjects)
    {
        agent = cachedObjects.GetGameObjectFromCache(agentKey.GetValue(cachedObjects));
        characterController = agent.GetComponent<CharacterController>();

        if (moveSpeed.GetValue(cachedObjects) <= 0)
        {
            currentMovement = Vector2.SmoothDamp(currentMovement, moveDirection.GetValue(cachedObjects) * minMoveSpeed.GetValue(cachedObjects), ref refrenceVelocity, smoothing.GetValue(cachedObjects));

            characterController.Move(Time.deltaTime * ((agent.transform.forward * currentMovement.y) + (agent.transform.right * currentMovement.x)));
        }
        else
        {
            currentMovement = Vector2.SmoothDamp(currentMovement, moveDirection.GetValue(cachedObjects) * moveSpeed.GetValue(cachedObjects), ref refrenceVelocity, smoothing.GetValue(cachedObjects));

            characterController.Move(Time.deltaTime * ((agent.transform.forward * currentMovement.y) + (agent.transform.right * currentMovement.x)));
        }
    }
}
