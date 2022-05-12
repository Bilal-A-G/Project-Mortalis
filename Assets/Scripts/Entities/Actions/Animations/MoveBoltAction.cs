using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Move Bolt Action", menuName = "FSM/Actions/Move Bolt Action")]
public class MoveBoltAction : ActionBase
{
    public EventObject onBoltStartMove;
    public EventObject onBoltStartKickback;
    public EventObject onBoltReachEnd;

    public GenericReference<Vector3> localBoltEndPosition;

    public GenericReference<Path> boltPath;

    public GenericReference<float> speed;
    public GenericReference<float> kickbackSpeed;
    public GenericReference<float> tolorence;

    bool debounce;
    bool isDoingKickback;
    GameObject bolt;
    GameObject callingObject;
    Vector3 boltStartPosition;

    public override void Execute(GameObject callingObject)
    {
        this.callingObject = callingObject;

        if(bolt == null)
        {
            bolt = boltPath.GetValue().GetObjectAtPath(callingObject);
            boltStartPosition = bolt.transform.localPosition;
        }

        if (debounce) return;

        debounce = true;

        if (onBoltStartMove != null) onBoltStartMove.Invoke(callingObject);
    }

    public override void Update()
    {
        if (!debounce) return;

        if (!isDoingKickback)
        {
            if (LerpBoltToPosition(localBoltEndPosition.GetValue(), speed.GetValue()))
            {
                isDoingKickback = true;

                if(onBoltStartKickback != null) onBoltStartKickback.Invoke(callingObject);
            }
        }
        else
        {
            if (LerpBoltToPosition(boltStartPosition, kickbackSpeed.GetValue()))
            {
                isDoingKickback = false;
                debounce = false;

                if (onBoltReachEnd != null) onBoltReachEnd.Invoke(callingObject);
            }
        }
    }

    bool LerpBoltToPosition(Vector3 endPosition, float speed)
    {
        bolt.transform.localPosition = Vector3.Lerp(bolt.transform.localPosition, endPosition, speed * Time.deltaTime);

        if ((endPosition - bolt.transform.localPosition).magnitude <= tolorence.GetValue())
        {
            return true;
        }

        return false;
    }

    private void OnDisable()
    {
        debounce = false;
        isDoingKickback = false;
        bolt = null;
    }
}