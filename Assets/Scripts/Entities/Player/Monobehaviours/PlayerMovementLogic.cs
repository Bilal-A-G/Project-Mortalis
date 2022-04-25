using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLogic : MonoBehaviour, IMovable
{
    public GenericReference<float> velocity;

    CharacterController characterController;
    float moveSpeed;
    Vector2 moveDirection;
    GameObject agent;

    public void ChangeMoveDirection(ResultArguments[] arguments)
    {
        moveDirection = arguments[0].vectorValue;
        characterController = arguments[0].objectValue.GetComponent<CharacterController>();
        moveSpeed = arguments[0].floatValue;
        agent = arguments[0].objectValue;
    }

    public void Move(ResultArguments[] arguments)
    {
        characterController.Move(((agent.gameObject.transform.forward * moveDirection.y) + agent.gameObject.transform.right * moveDirection.x) * moveSpeed * Time.deltaTime);
    }

    public void Jump(ResultArguments[] arguments)
    {
        velocity.SetValue(arguments[0].floatValue * -arguments[1].floatValue);
    }
}
