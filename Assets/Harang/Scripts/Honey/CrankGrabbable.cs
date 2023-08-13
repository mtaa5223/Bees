using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrankGrabbable : OVRGrabbable
{
    public Transform handler;

    public override void GrabEnd(Vector3 linearVelocity, Vector3 agularVelocity)
    {
        base.GrabEnd(Vector3.zero, Vector3.zero);

        transform.position = handler.position;
        transform.rotation = handler.rotation;

        Rigidbody rbHandler = handler.GetComponent<Rigidbody>();
        rbHandler.velocity = Vector3.zero;
        rbHandler.angularVelocity = Vector3.zero;
    }

    private void Update()
    {
        if (Vector3.Distance(handler.position, transform.position) > 0.4f)
        {
            grabbedBy.ForceRelease(this);
        }
    }
}
