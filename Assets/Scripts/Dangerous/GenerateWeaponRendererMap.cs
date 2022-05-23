using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWeaponRendererMap : MonoBehaviour
{
    public Transform map;
    public int weaponRendererMapLayer;

    void Awake()
    {
        for(int i = 0; i < map.childCount; i++)
        {
            GameObject currentChild = map.GetChild(i).gameObject;

            if(currentChild.GetComponent<MeshRenderer>() != null)
            {
                GameObject instantiatedObject = Instantiate(currentChild);

                instantiatedObject.transform.position = currentChild.transform.position;
                instantiatedObject.transform.rotation = currentChild.transform.rotation;

                instantiatedObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                instantiatedObject.layer = weaponRendererMapLayer;
            }
        }
    }
}
