using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Set Animator Ammo", menuName = "FSM/Actions/Set Animator Ammo")]
public class SetAnimatorAmmo : ActionBase
{
    public GenericReference<string> animatorKey;
    public GenericReference<string> agentKey;

    [System.NonSerialized]
    protected Animator animator;

    public override void Execute(CachedObjectWrapper cachedObjects)
    {
        animator = cachedObjects.GetGameObjectFromCache(animatorKey.GetValue(cachedObjects)).GetComponent<Animator>();
        GunRuntimeVariables variables = cachedObjects.GetGameObjectFromCache(agentKey.GetValue(cachedObjects)).GetComponent<GunRuntimeVariables>();

        animator.SetFloat("Ammo", variables.currentAmmo);
    }
}
