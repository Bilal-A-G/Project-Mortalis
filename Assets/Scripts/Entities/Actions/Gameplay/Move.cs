using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Actions/Move")]

public class Move : ActionBase
{
    public GenericReference<float> moveSpeed;
    public GenericReference<Vector2> moveDirection;

    [System.NonSerialized]
    CharacterController characterController;

    public override void Execute(GameObject callingObject)
    {
        characterController = callingObject.GetComponent<CharacterController>();

        characterController.Move(moveSpeed.GetValue() * Time.deltaTime * ((callingObject.gameObject.transform.forward * moveDirection.GetValue().y) + callingObject.gameObject.transform.right * moveDirection.GetValue().x));
    }
}
