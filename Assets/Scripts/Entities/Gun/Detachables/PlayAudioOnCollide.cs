using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnCollide : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource source;
    public float groundDrag;

    bool playedAlready;

    private void OnCollisionEnter(Collision collision)
    {
        if (!playedAlready)
        {
            source.PlayOneShot(audioClip);
            playedAlready = true;
            GetComponent<Rigidbody>().drag = groundDrag;
        }
    }
}
