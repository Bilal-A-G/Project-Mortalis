using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Move Bolt Action", menuName = "FSM/Actions/Move Bolt Action")]
public class MoveBoltAction : ActionBase
{
    public EventObject onBoltReachEnd;
    public EventObject onBoltStartMove;

    public GenericReference<Vector3> localBoltEndPosition;

    public GenericReference<string> boltPath1;
    public GenericReference<string> boltPath2;
    public GenericReference<string> boltPath3;
    public GenericReference<string> boltPath4;

    public GenericReference<float> speed;
    public GenericReference<float> tolorence;
    public GenericReference<AnimationCurve> easingFunction;

    bool debounce;
    bool isDoingKickback;
    GameObject bolt;
    Vector3 boltStartPosition;

    public override void Execute(GameObject callingObject)
    {
        if(bolt == null)
        {
            bolt = callingObject.transform.Find(boltPath1.GetValue()).Find(boltPath2.GetValue()).Find(boltPath3.GetValue()).Find(boltPath4.GetValue()).gameObject;
            boltStartPosition = bolt.transform.localPosition;
        }

        if (debounce) return;

        debounce = true;
        if(onBoltStartMove != null)
        {
            onBoltStartMove.Invoke(callingObject);
        }
    }

    public override void Update()
    {
        if (!debounce) return;

        if (!isDoingKickback)
        {
            bolt.transform.localPosition = Vector3.Lerp(bolt.transform.localPosition, localBoltEndPosition.GetValue(), speed.GetValue());

            if ((localBoltEndPosition.GetValue() - bolt.transform.localPosition).magnitude <= tolorence.GetValue())
            {
                isDoingKickback = true;
            }
        }
        else
        {
            bolt.transform.localPosition = Vector3.Lerp(bolt.transform.localPosition, boltStartPosition, speed.GetValue());

            if ((boltStartPosition - bolt.transform.localPosition).magnitude <= tolorence.GetValue())
            {
                isDoingKickback = false;
                debounce = false;
            }
        }
    }

    private void OnDisable()
    {
        debounce = false;
        isDoingKickback = false;
    }
}
