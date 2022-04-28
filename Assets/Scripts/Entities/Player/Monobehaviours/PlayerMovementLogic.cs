using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLogic : MonoBehaviour, IMovable
{
    [Header("Jumping")]
    public GenericReference<float> velocity;
    public GenericReference<float> jumpHeight;
    public GenericReference<float> gravity;

    [Header("GroundMovement")]
    public GenericReference<float> moveSpeed;
    public GenericReference<float> walkSpeed;
    public GenericReference<float> runSpeed;
    public GenericReference<Vector2> moveDirection;
    public GameObject agent;

    CharacterController characterController;

    private void Awake()
    {
        characterController = agent.GetComponent<CharacterController>();
    }

    public void Move()
    {
        characterController.Move(((agent.gameObject.transform.forward * moveDirection.GetValue().y) + agent.gameObject.transform.right * moveDirection.GetValue().x) * moveSpeed.GetValue() * Time.deltaTime);
    }

    public void Jump()
    {
        velocity.SetValue(jumpHeight.GetValue() * -gravity.GetValue());
    }

    public void ChangeMoveSpeedToRun() => moveSpeed.SetValue(runSpeed.GetValue());

    public void ChangeMoveSpeedToWalk() => moveSpeed.SetValue(walkSpeed.GetValue());
}
