using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recoil", menuName = "FSM/Actions/Recoil")]
public class Recoil : ActionBase
{
    public GenericReference<string> mainCameraKey;

    public GenericReference<float> recoilAmount;
    public GenericReference<float> decreaseRate;
    public GenericReference<float> maxRecoil;
    public GenericReference<float> recoilSpeed;

    [System.NonSerialized]
    GameObject mainCamera;

    [System.NonSerialized]
    Vector3 recoilAngle;


    public override void Execute(CachedObjectWrapper cachedObjects)
    {
        mainCamera = cachedObjects.GetGameObjectFromCache(mainCameraKey.GetValue(cachedObjects));

        recoilAmount.SetValue(recoilAmount.GetValue(cachedObjects) - decreaseRate.GetValue(cachedObjects), cachedObjects);
        recoilAmount.SetValue(Mathf.Clamp(recoilAmount.GetValue(cachedObjects), 0, maxRecoil.GetValue(cachedObjects)), cachedObjects);

        recoilAngle = Vector3.Slerp(recoilAngle, -Vector3.right * recoilAmount.GetValue(cachedObjects), Time.deltaTime * recoilSpeed.GetValue(cachedObjects));

        mainCamera.transform.localEulerAngles = new Vector3(recoilAngle.x, mainCamera.transform.localEulerAngles.y, mainCamera.transform.localEulerAngles.z);
    }
}
