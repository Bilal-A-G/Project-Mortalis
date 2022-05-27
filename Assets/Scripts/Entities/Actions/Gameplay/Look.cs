using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Actions/Look")]
public class Look : ActionBase
{
    public GenericReference<Vector2> currentMouseDelta;
    public GenericReference<float> mouseSensitivity;
    public GenericReference<string> cameraKey;
    public GenericReference<string> agentKey;

    [System.NonSerialized]
    GameObject agentCamera;

    [System.NonSerialized]
    GameObject agent;

    public override void Execute(CachedObjectWrapper callingObject)
    {
        agentCamera = callingObject.GetGameObjectFromCache(cameraKey);
        agent = callingObject.GetGameObjectFromCache(agentKey);

        Cursor.lockState = CursorLockMode.Locked;

        agent.transform.localEulerAngles = new Vector3(0, agent.transform.localEulerAngles.y + currentMouseDelta.GetValue().x * mouseSensitivity.GetValue(), 0);
        agentCamera.transform.localEulerAngles = new Vector3(agentCamera.transform.localEulerAngles.x - currentMouseDelta.GetValue().y * mouseSensitivity.GetValue(), 0, 0);
    }
}
