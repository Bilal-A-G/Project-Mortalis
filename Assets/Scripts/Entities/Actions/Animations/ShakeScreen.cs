using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Actions/Shake Screen")]
public class ShakeScreen : ActionBase
{
    public GenericReference<float> trauma;
    public GenericReference<float> traumaDecreaseRate;
    public GenericReference<Vector3> screenShakeYawPitchRoll;
    public GenericReference<Path> pathToMainCamera;
    public GenericReference<Path> pathToStableCamera;

    [System.NonSerialized]
    GameObject camera;
    [System.NonSerialized]
    GameObject mainCamera;

    [System.NonSerialized]
    float seed;

    [System.NonSerialized]
    float time;

    public override void Execute(GameObject callingObject)
    {
        if (trauma.GetValue() <= 0) return;

        camera = pathToStableCamera.GetValue().GetObjectAtPath(callingObject);
        mainCamera = pathToMainCamera.GetValue().GetObjectAtPath(callingObject);

        if (seed == 0) seed = Random.Range(1, 1000);

        trauma.SetValue(trauma.GetValue() - traumaDecreaseRate.GetValue() * Time.deltaTime);
        trauma.SetValue(Mathf.Clamp01(trauma.GetValue()));

        Vector3 screenShake;

        float randomYawModifier = Mathf.PerlinNoise(seed + time, seed + time + 1);
        float randomPitchModifier = Mathf.PerlinNoise(seed + time + 2, seed + time + 3);
        float randomRollModifier = Mathf.PerlinNoise(seed + time + 4, seed + time + 5);

        float yaw = screenShakeYawPitchRoll.GetValue().x * Mathf.Pow(trauma.GetValue(), 2) * (Random.value < 0.5 ? -1 : 1) * randomYawModifier;
        float pitch = screenShakeYawPitchRoll.GetValue().y * Mathf.Pow(trauma.GetValue(), 2) * (Random.value < 0.5 ? -1 : 1) * randomPitchModifier;
        float roll = screenShakeYawPitchRoll.GetValue().z * Mathf.Pow(trauma.GetValue(), 2) * (Random.value < 0.5 ? -1 : 1) * randomRollModifier;

        screenShake.x = yaw;
        screenShake.y = pitch;
        screenShake.z = roll;

        mainCamera.transform.eulerAngles = camera.transform.eulerAngles + screenShake;
        time += Time.deltaTime;
    }
}
