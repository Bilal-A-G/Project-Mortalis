using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Move Action", menuName = "FSM/Actions/Move Action")]

public class MoveAction : ActionBase
{
    public GenericReference<float> moveSpeed;
    public GenericReference<Vector2> moveDirection;

    CharacterController characterController;

    public override void Execute(GameObject callingObject)
    {
        if (characterController == null) characterController = callingObject.GetComponent<CharacterController>();

        characterController.Move(moveSpeed.GetValue() * Time.deltaTime * ((callingObject.gameObject.transform.forward * moveDirection.GetValue().y) + callingObject.gameObject.transform.right * moveDirection.GetValue().x));
    }
}