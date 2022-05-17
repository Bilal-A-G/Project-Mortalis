using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Lerp FOV", menuName = "FSM/Actions/Lerp FOV")]
public class LerpFOV : ActionBase
{
    public GenericReference<float> desiredFOV;
    public GenericReference<Path> pathToCamera;
    public GenericReference<float> zoomSpeed;

    [System.NonSerialized]
    Camera camera;

    [System.NonSerialized]
    float finalZoom;

    [System.NonSerialized]
    float zoomTime;

    public override void Execute(GameObject callingObject)
    {
        return;
    }

    public override void UpdateLoop(GameObject callingObject)
    {
        if (camera == null) 
        {
            camera = pathToCamera.GetValue().GetObjectAtPath(callingObject).GetComponent<Camera>();
            finalZoom = camera.fieldOfView;
        }

        if ((int)finalZoom <= (int)desiredFOV.GetValue() + 1 && (int)finalZoom >= (int)desiredFOV.GetValue() - 1)
        {
            zoomTime = 0;
            return;
        }

        zoomTime += Time.deltaTime * zoomSpeed.GetValue();

        finalZoom = Mathf.Lerp(finalZoom, desiredFOV.GetValue(), zoomTime);
        camera.fieldOfView = finalZoom;
    }
}
