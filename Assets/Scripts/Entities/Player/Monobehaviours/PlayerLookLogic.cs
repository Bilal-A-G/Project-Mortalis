using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookLogic : MonoBehaviour, ILookable
{
    public GenericReference<Vector2> currentMouseDelta;
    public GenericReference<float> mouseSensitivity;
    public GameObject agentCamera;
    public GameObject agent;

    bool lockCursor = true;

    public void Look()
    {
        Cursor.lockState = CursorLockMode.Locked;

        agent.transform.localEulerAngles = new Vector3(0, agent.transform.localEulerAngles.y + currentMouseDelta.GetValue().x * mouseSensitivity.GetValue(), 0);
        agentCamera.transform.localEulerAngles = new Vector3(agentCamera.transform.localEulerAngles.x - currentMouseDelta.GetValue().y * mouseSensitivity.GetValue(), 0, 0);
    }

    public void StopLooking() => lockCursor = false;

    public void StartLooking() => lockCursor = true;
}
