using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLogic : MonoBehaviour
{
    public GenericReference<float> moveSpeed;
    public GenericReference<float> walkSpeed;
    public GenericReference<float> runSpeed;
    public GenericReference<float> crouchSpeed;
    public GenericReference<Vector2> moveDirection;
    public GameObject agent;

    CharacterController characterController;

    private void Awake()
    {
        characterController = agent.GetComponent<CharacterController>();
    }

    public void Move()
    {
        characterController.Move(moveSpeed.GetValue() * Time.deltaTime * ((agent.gameObject.transform.forward * moveDirection.GetValue().y) + agent.gameObject.transform.right * moveDirection.GetValue().x));
    }

    public void ChangeMoveSpeedToRun() => moveSpeed.SetValue(runSpeed.GetValue());

    public void ChangeMoveSpeedToWalk() => moveSpeed.SetValue(walkSpeed.GetValue());

    public void ChangeMoveSpeedToCrouch() => moveSpeed.SetValue(crouchSpeed.GetValue());
}
