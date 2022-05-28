using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRuntimeVariables : MonoBehaviour, IRuntimeVariable
{
    [Header("Ammo")]
    public float currentAmmo;
    public float minAmmo;
    public float maxAmmo;
    public float ammoPerShot;

    [Header("Damage")]
    public float damage;

    public object GetValueFromName(string name)
    {
        return typeof(GunRuntimeVariables).GetField(name).GetValue(this);
    }

    public void SetValueFromName(string name, object value)
    {
        typeof(GunRuntimeVariables).GetField(name).SetValue(this, value);
    }
}
