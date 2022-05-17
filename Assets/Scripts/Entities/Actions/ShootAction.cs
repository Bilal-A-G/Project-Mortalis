using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shoot Action", menuName = "FSM/Actions/Shoot Action")]
public class ShootAction : ActionBase
{
    public GenericReference<float> damage;
    public GenericReference<float> maxRange;
    public GenericReference<LayerMask> layerToHit;
    public GenericReference<string> firePointName;

    [System.NonSerialized]
    Transform firePoint;

    public override void Execute(GameObject callingObject)
    {
        if (firePoint == null) firePoint = callingObject.transform.Find(firePointName.GetValue());

        RaycastHit hit;

        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, maxRange.GetValue(), layerToHit.GetValue()))
        {
            if ((hit.collider.gameObject.transform.position - firePoint.transform.position).magnitude <= maxRange.GetValue())
            {
                Debug.Log("Dealt " + damage.GetValue() + " damage to " + hit.transform.gameObject.name);
            }
        }
    }
}
