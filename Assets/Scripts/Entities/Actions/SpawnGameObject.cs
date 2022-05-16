using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spawn GameObject", menuName = "FSM/Actions/Spawn GameObject")]
public class SpawnGameObject : ActionBase
{
    public GenericReference<Vector3> instantiatePosition;
    public GenericReference<Vector3> instantiateRotation;
    public GameObject objectToInstantiate;
    public GenericReference<float> force;

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
    }
}
