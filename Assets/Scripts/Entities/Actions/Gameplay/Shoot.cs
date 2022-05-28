using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Actions/Shoot")]
public class Shoot : ActionBase
{
    public GenericReference<float> maxRange;
    public GenericReference<LayerMask> layerToHit;

    public GenericReference<string> firePointKey;
    public GenericReference<string> agentKey;

    public GenericReference<Vector3> outputPosition;
    public GenericReference<Vector3> outputRotation;
    public GenericReference<float> bulletSpread;

    public GenericReference<bool> tracerHitSomething;

    [System.NonSerialized]
    Transform firePoint;
    [System.NonSerialized]
    bool didTracer;

    [System.NonSerialized]
    Vector3 bulletDeviation;
    [System.NonSerialized]
    Vector3 endPoint;


    public override void Execute(CachedObjectWrapper cachedObjects)
    {
        didTracer = false;

        firePoint = cachedObjects.GetGameObjectFromCache(firePointKey.GetValue(cachedObjects)).transform;
        GunRuntimeVariables variables = cachedObjects.GetGameObjectFromCache(agentKey.GetValue(cachedObjects)).GetComponent<GunRuntimeVariables>();

        float bulletSpreadValue = bulletSpread.GetValue(cachedObjects);

        bulletDeviation.x = Random.Range(-bulletSpreadValue, bulletSpreadValue);
        bulletDeviation.y = Random.Range(-bulletSpreadValue, bulletSpreadValue);
        bulletDeviation.z = Random.Range(-bulletSpreadValue, bulletSpreadValue);

        endPoint = (bulletDeviation + firePoint.forward).normalized;

        RaycastHit hit;

        if (Physics.Raycast(firePoint.position, endPoint, out hit, maxRange.GetValue(cachedObjects), layerToHit.GetValue(cachedObjects)))
        {
            if ((hit.collider.gameObject.transform.position - firePoint.transform.position).magnitude <= maxRange.GetValue(cachedObjects))
            {
                Debug.Log("Dealt " + variables.damage + " damage to " + hit.transform.gameObject.name);
            }

            outputPosition.SetValue(hit.point, cachedObjects);
            outputRotation.SetValue(Quaternion.LookRotation(hit.normal).eulerAngles, cachedObjects);
            tracerHitSomething.SetValue(true, cachedObjects);
            didTracer = true;
        }

        if (!didTracer) 
        {
            outputPosition.SetValue(endPoint * 1000, cachedObjects);
            tracerHitSomething.SetValue(false, cachedObjects);
        } 
    }
}
