using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookLogic : MonoBehaviour, ILookable
{
    Vector2 currentMouseDelta;
    float mouseSensitivity;
    GameObject agentCamera;
    GameObject agent;

    float angle;

    bool lockCursor = true;

    public void Look(ResultArguments[] arguments)
    {
        currentMouseDelta = arguments[0].vectorValue;
        mouseSensitivity = arguments[0].floatValue;
        agentCamera = arguments[0].objectValue;
        agent = arguments[1].objectValue;
    }

    public void StopLooking(ResultArguments[] arguments) => lockCursor = false;

    public void StartLooking(ResultArguments[] arguments) => lockCursor = true;

    private void Update()
    {
        if (agent == null) return;
        Cursor.lockState = CursorLockMode.Locked;

        agent.transform.localEulerAngles = new Vector3(0, agent.transform.localEulerAngles.y + currentMouseDelta.x * mouseSensitivity, 0);
        agentCamera.transform.localEulerAngles = new Vector3(agentCamera.transform.localEulerAngles.x - currentMouseDelta.y * mouseSensitivity, 0, 0);
    }
}
