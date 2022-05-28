using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Actions/Shake Screen")]
public class ShakeScreen : ActionBase
{
    public GenericReference<float> trauma;
    public GenericReference<float> traumaDecreaseRate;
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
        if (trauma.GetValue(cachedObjects) <= 0) return;

        camera = cachedObjects.GetGameObjectFromCache(stableCameraKey.GetValue(cachedObjects));
        mainCamera = cachedObjects.GetGameObjectFromCache(mainCameraKey.GetValue(cachedObjects));

        if (seed == 0) seed = Random.Range(1, 1000);

        trauma.SetValue(trauma.GetValue(cachedObjects) - traumaDecreaseRate.GetValue(cachedObjects) * Time.deltaTime, cachedObjects);
        trauma.SetValue(Mathf.Clamp01(trauma.GetValue(cachedObjects)), cachedObjects);

        Vector3 screenShake;

        float randomYawModifier = Mathf.PerlinNoise(seed + time, seed + time + 1);
        float randomPitchModifier = Mathf.PerlinNoise(seed + time + 2, seed + time + 3);
        float randomRollModifier = Mathf.PerlinNoise(seed + time + 4, seed + time + 5);

        float yaw = screenShakeYawPitchRoll.GetValue(cachedObjects).x * Mathf.Pow(trauma.GetValue(cachedObjects), 2) * (Random.value < 0.5 ? -1 : 1) * randomYawModifier;
        float pitch = screenShakeYawPitchRoll.GetValue(cachedObjects).y * Mathf.Pow(trauma.GetValue(cachedObjects), 2) * (Random.value < 0.5 ? -1 : 1) * randomPitchModifier;
        float roll = screenShakeYawPitchRoll.GetValue(cachedObjects).z * Mathf.Pow(trauma.GetValue(cachedObjects), 2) * (Random.value < 0.5 ? -1 : 1) * randomRollModifier;

        screenShake.x = yaw;
        screenShake.y = pitch;
        screenShake.z = roll;

        mainCamera.transform.eulerAngles = camera.transform.eulerAngles + screenShake;
        time += Time.deltaTime;
    }
}
