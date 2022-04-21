using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLogic : MonoBehaviour, IMovable
{
    CharacterController characterController;
    float moveSpeed;
    Vector2 moveDirection;
    GameObject agent;

    public void Move(ResultArguments[] arguments)
    {
        characterController = arguments[0].objectValue.GetComponent<CharacterController>();
        moveSpeed = arguments[0].floatValue;
        moveDirection = arguments[0].vectorValue;
        agent = arguments[0].objectValue;
    }

    void Update()
    {
        if(characterController == null) return;

        characterController.Move(((agent.gameObject.transform.forward * moveDirection.y) + agent.gameObject.transform.right * moveDirection.x) * moveSpeed * Time.deltaTime);
    }
}
