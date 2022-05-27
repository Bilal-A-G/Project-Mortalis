using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Reload", menuName = "FSM/Actions/Reload")]
public class Reload : ActionBase
{
    public GenericReference<string> agentKey;

    public override void Execute(CachedObjectWrapper cachedObjects)
    {
        GunRuntimeVariables variables = cachedObjects.GetGameObjectFromCache(agentKey).GetComponent<GunRuntimeVariables>();
        variables.currentAmmo = variables.maxAmmo;
    }
}
