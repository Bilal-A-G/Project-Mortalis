using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Actions/Shoot")]
public class Shoot : ActionBase
{
    public GenericReference<float> damage;
    public GenericReference<float> maxRange;
    public GenericReference<LayerMask> layerToHit;
    public GenericReference<string> firePointName;

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


    public override void Execute(GameObject callingObject)
    {
        didTracer = false;

        firePoint = callingObject.transform.Find(firePointName.GetValue());
        

        bulletDeviation.x = Random.Range(-bulletSpread.GetValue(), bulletSpread.GetValue());
        bulletDeviation.y = Random.Range(-bulletSpread.GetValue(), bulletSpread.GetValue());
        bulletDeviation.z = Random.Range(-bulletSpread.GetValue(), bulletSpread.GetValue());

        endPoint = (bulletDeviation + firePoint.forward).normalized;

        RaycastHit hit;

        if (Physics.Raycast(firePoint.position, endPoint, out hit, maxRange.GetValue(), layerToHit.GetValue()))
        {
            if ((hit.collider.gameObject.transform.position - firePoint.transform.position).magnitude <= maxRange.GetValue())
            {
                Debug.Log("Dealt " + damage.GetValue() + " damage to " + hit.transform.gameObject.name);
            }

            outputPosition.SetValue(hit.point);
            outputRotation.SetValue(Quaternion.LookRotation(hit.normal).eulerAngles);
            tracerHitSomething.SetValue(true);
            didTracer = true;
        }

        if (!didTracer) 
        {
            outputPosition.SetValue(endPoint * 1000);
            tracerHitSomething.SetValue(false);
        } 
    }
}
