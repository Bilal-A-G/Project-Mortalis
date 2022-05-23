using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Actions/Look")]
public class Look : ActionBase
{
    public GenericReference<Vector2> currentMouseDelta;
    public GenericReference<float> mouseSensitivity;
    public GenericReference<Path> pathToCamera;

    [System.NonSerialized]
    GameObject agentCamera;

    public override void Execute(GameObject callingObject)
    {
        agentCamera = pathToCamera.GetValue().GetObjectAtPath(callingObject);

        Cursor.lockState = CursorLockMode.Locked;

        callingObject.transform.localEulerAngles = new Vector3(0, callingObject.transform.localEulerAngles.y + currentMouseDelta.GetValue().x * mouseSensitivity.GetValue(), 0);
        agentCamera.transform.localEulerAngles = new Vector3(agentCamera.transform.localEulerAngles.x - currentMouseDelta.GetValue().y * mouseSensitivity.GetValue(), 0, 0);
    }
}
