using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootLogic : MonoBehaviour
{
    public GenericReference<float> damage;
    public GenericReference<float> maxRange;
    public GenericReference<LayerMask> layerToHit;
    public Transform firePoint;

    public void Fire()
    {
        RaycastHit hit;

        if(Physics.Raycast(firePoint.position, firePoint.forward, out hit, maxRange.GetValue(), layerToHit.GetValue()))
        {
            if((hit.collider.gameObject.transform.position - firePoint.transform.position).magnitude <= maxRange.GetValue())
            {
                Debug.Log("Dealt " + damage.GetValue() + " damage to " + hit.transform.gameObject.name);
            }
        }
    }
}
