using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRuntimeVariables : MonoBehaviour
{
    [Header("Ammo")]
    public float currentAmmo;
    public float minAmmo;
    public float maxAmmo;
    public float ammoPerShot;

    [Header("Damage")]
    public float damage;
}
