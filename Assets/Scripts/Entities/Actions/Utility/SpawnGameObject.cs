using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spawn GameObject", menuName = "FSM/Actions/Spawn GameObject")]
public class SpawnGameObject : ActionBase
{
    public GameObject objectToInstantiate;

    public GenericReference<float> force;
    public GenericReference<float> destroyTime;

    public GenericReference<bool> useInstantiateKey;

    [Header("If use instantiate key is true, it uses this value")]
    public GenericReference<string> instantiateKey;

    [Header("If use instantiate key is false, it uses these values")]
    public GenericReference<Vector3> spawnPosition;
    public GenericReference<Vector3> spawnRotation;

    public override void Execute(CachedObjectWrapper cachedObjects)
    {
        GameObject instantiatedObject = Instantiate(objectToInstantiate);

        Rigidbody instantiatedObjectPhysicsBody = instantiatedObject.GetComponent<Rigidbody>();

        if(useInstantiateKey.GetValue(cachedObjects))
        {
            instantiatedObject.transform.position = cachedObjects.GetGameObjectFromCache(instantiateKey.GetValue(cachedObjects)).transform.position;
            instantiatedObject.transform.eulerAngles = cachedObjects.GetGameObjectFromCache(instantiateKey.GetValue(cachedObjects)).transform.eulerAngles;
        }
        else
        {
            instantiatedObject.transform.position = spawnPosition.GetValue(cachedObjects);
            instantiatedObject.transform.eulerAngles = spawnRotation.GetValue(cachedObjects);
        }

        if (instantiatedObjectPhysicsBody)
        {
            instantiatedObjectPhysicsBody.AddForce(instantiatedObject.transform.right * force.GetValue(cachedObjects));
        }

        instantiatedObject.SetActive(true);
        Destroy(instantiatedObject, destroyTime.GetValue(cachedObjects));
    }
}
