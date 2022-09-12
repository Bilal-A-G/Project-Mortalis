using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Actions/Shake Screen")]
public class ShakeScreen : ActionBase
{
    public GenericReference<float> trauma;
    public GenericReference<float> traumaDecreaseRate;
    public GenericReference<float> shakeSpeed;
    public GenericReference<Vector3> screenShakeYawPitchRoll;

    public GenericReference<string> mainCameraKey;
    public GenericReference<string> stableCameraKey;

    [System.NonSerialized]
    GameObject camera;
    [System.NonSerialized]
    GameObject mainCamera;

    [System.NonSerialized]
    float seed;

    [System.NonSerialized]
    float time;

    public override void Execute(CachedObjectWrapper cachedObjects)
    {
        camera = cachedObjects.GetGameObjectFromCache(stableCameraKey.GetValue(cachedObjects));
        mainCamera = cachedObjects.GetGameObjectFromCache(mainCameraKey.GetValue(cachedObjects));

        if (seed == 0) seed = Random.Range(1, 1000);

        trauma.SetValue(trauma.GetValue(cachedObjects) - traumaDecreaseRate.GetValue(cachedObjects) * Time.deltaTime, cachedObjects);
        trauma.SetValue(Mathf.Clamp01(trauma.GetValue(cachedObjects)), cachedObjects);

        Vector3 screenShake;

        float randomYawModifier = Mathf.PerlinNoise(seed + time, seed + time + 1);
        float randomPitchModifier = Mathf.PerlinNoise(seed + time + 2, seed + time + 3);

        float yaw = screenShakeYawPitchRoll.GetValue(cachedObjects).x * Mathf.Pow(trauma.GetValue(cachedObjects), 2) * (Random.value < 0.5 ? -1 : 1) * randomYawModifier;
        float pitch = screenShakeYawPitchRoll.GetValue(cachedObjects).y * Mathf.Pow(trauma.GetValue(cachedObjects), 2) * (Random.value < 0.5 ? -1 : 1) * randomPitchModifier;

        screenShake.x = yaw;
        screenShake.y = pitch;
        screenShake.z = 0;

        Vector3 lerpedShake = Vector3.Lerp(mainCamera.transform.eulerAngles, camera.transform.eulerAngles + screenShake, Time.deltaTime * shakeSpeed.GetValue(cachedObjects));
        mainCamera.transform.eulerAngles = new Vector3(lerpedShake.x, lerpedShake.y, mainCamera.transform.eulerAngles.z);
        time += Time.deltaTime;
    }
}
