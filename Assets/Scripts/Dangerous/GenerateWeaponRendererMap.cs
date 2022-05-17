using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWeaponRendererMap : MonoBehaviour
{
    public GenericReference<string> mapTag;
    public GenericReference<string> weaponRendererMapTag;
    public GenericReference<int> weaponRendererMapLayer;

    void Awake()
    {
        Debug.Log("Generating a weapon renderer map, this is likely very expensive, try to find a better solution");
        GameObject[] allMapObjects = GameObject.FindGameObjectsWithTag(mapTag.GetValue());

        for(int i = 0; i < allMapObjects.Length; i++)
        {
            GameObject instantiatedObject = Instantiate(allMapObjects[i]);

            instantiatedObject.layer = weaponRendererMapLayer.GetValue();
            instantiatedObject.tag = weaponRendererMapTag.GetValue();
            instantiatedObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            instantiatedObject.transform.position = allMapObjects[i].transform.position;

            if (instantiatedObject.GetComponent<Collider>()) Destroy(instantiatedObject.GetComponent<Collider>());
        }
    }

}
