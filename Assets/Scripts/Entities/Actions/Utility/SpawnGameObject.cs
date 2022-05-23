using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spawn GameObject", menuName = "FSM/Actions/Spawn GameObject")]
public class SpawnGameObject : ActionBase
{
    public GameObject objectToInstantiate;

    public GenericReference<Vector3> instantiatePosition;
    public GenericReference<Vector3> instantiateRotation;
    public GenericReference<float> force;
    public GenericReference<float> destroyTime;

    public override void Execute(GameObject callingObject)
    {
        GameObject instantiatedObject = Instantiate(objectToInstantiate);

        Rigidbody instantiatedObjectPhysicsBody = instantiatedObject.GetComponent<Rigidbody>();

        instantiatedObject.transform.position = instantiatePosition.GetValue();
        instantiatedObject.transform.eulerAngles = instantiateRotation.GetValue();

        if (instantiatedObjectPhysicsBody)
        {
            instantiatedObjectPhysicsBody.AddForce(instantiatedObject.transform.right * force.GetValue());
        }

        instantiatedObject.SetActive(true);
        Destroy(instantiatedObject, destroyTime.GetValue());
    }
}
