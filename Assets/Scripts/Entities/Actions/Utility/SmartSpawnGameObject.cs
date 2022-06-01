using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Actions/Smart Spawn Game Object")]
public class SmartSpawnGameObject : ActionBase
{
    public GenericReference<string> instantiatedObjectsKey;
    public GenericReference<string> spawnParentKey;
    public GenericReference<bool> spawnOneInCollection;

    public GameObject objectToSpawn;

    [System.NonSerialized]
    List<GameObject> instantiatedObjects;

    [System.NonSerialized]
    GameObject spawnParent;

    public override void Execute(CachedObjectWrapper cachedObjects)
    {
        instantiatedObjects = cachedObjects.GetGameObjectFromCache(instantiatedObjectsKey.GetValue(cachedObjects)).GetComponent<PlayerVariables>().instantiatedObjects;
        spawnParent = cachedObjects.GetGameObjectFromCache(spawnParentKey.GetValue(cachedObjects));

        for(int i = 0; i < instantiatedObjects.Count; i++)
        {
            if(instantiatedObjects[i].name == objectToSpawn.name)
            {
                instantiatedObjects[i].SetActive(true);

                TryHideOtherObjectsInCollection(cachedObjects);

                return;
            }
        }

        GameObject instantiatedObject = Instantiate(objectToSpawn, spawnParent.transform);
        instantiatedObject.name = objectToSpawn.name;
        instantiatedObjects.Add(instantiatedObject);

        TryHideOtherObjectsInCollection(cachedObjects);

    }

    void TryHideOtherObjectsInCollection(CachedObjectWrapper cachedObjects)
    {
        if (spawnOneInCollection.GetValue(cachedObjects))
        {
            for (int v = 0; v < instantiatedObjects.Count; v++)
            {
                if (instantiatedObjects[v].name != objectToSpawn.name) instantiatedObjects[v].SetActive(false);
            }
        }
    }
}
