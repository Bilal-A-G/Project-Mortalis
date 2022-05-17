using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Screen Shake", menuName = "FSM/Actions/Screen Shake Action")]
public class ScreenShakeAction : ActionBase
{
    public GenericReference<float> trauma;
    public GenericReference<float> traumaDecreaseRate;
    public GenericReference<Vector3> screenShakeYawPitchRoll;
    public GenericReference<Path> pathToMainCamera;
    public GenericReference<Path> pathToStableCamera;

    [System.NonSerialized]
    Camera camera;
    [System.NonSerialized]
    Camera mainCamera;

    public override void Execute(GameObject callingObject)
    {
        return; 
    }

    public override void UpdateLoop(GameObject callingObject)
    {
        if (trauma.GetValue() <= 0) return;

        if(camera == null)
        {
            camera = pathToStableCamera.GetValue().GetObjectAtPath(callingObject).GetComponent<Camera>();
            mainCamera = pathToMainCamera.GetValue().GetObjectAtPath(callingObject).GetComponent<Camera>();
        }

        trauma.SetValue(trauma.GetValue() - traumaDecreaseRate.GetValue() * Time.deltaTime);
        trauma.SetValue(Mathf.Clamp01(trauma.GetValue()));

        Vector3 screenShake;

        float randomYawModifier = Random.Range(0.1f, 1f);
        float randomPitchModifier = Random.Range(0.1f, 1f);
        float randomRollModifier = Random.Range(0.1f, 1f);

        float yaw = screenShakeYawPitchRoll.GetValue().x * Mathf.Pow(trauma.GetValue(), 2) * (Random.value < 0.5 ? -1 : 1) * randomYawModifier;
        float pitch = screenShakeYawPitchRoll.GetValue().y * Mathf.Pow(trauma.GetValue(), 2) * (Random.value < 0.5 ? -1 : 1) * randomPitchModifier;
        float roll = screenShakeYawPitchRoll.GetValue().z * Mathf.Pow(trauma.GetValue(), 2) * (Random.value < 0.5 ? -1 : 1) * randomRollModifier;
        
        screenShake.x = yaw;
        screenShake.y = pitch;
        screenShake.z = roll;

        mainCamera.transform.eulerAngles = camera.transform.eulerAngles + screenShake;
    }
}
