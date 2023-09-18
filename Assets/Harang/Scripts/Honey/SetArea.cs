using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetArea : MonoBehaviourPun
{
    private int inputObjectCount;
    private bool autoInstallObject = false;

    public GameObject inputObject;
    PhotonView pv;

    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<ObjectInput>() != null)
            {
                inputObjectCount++;
            }
        }
    }
    void Update()
    {
        int count = 0;

        foreach (Transform child in transform)
        {
            if (child.GetComponent<ObjectInput>() != null)
            {
                if (child.GetComponent<ObjectInput>().isIn)
                {
                    count++;
                }
            }
        }

        autoInstallObject = inputObjectCount == count ? true : false;

        if (inputObject != null)
        {
            inputObject.transform.position = transform.position;
            inputObject.transform.rotation = transform.rotation;
        }

        if (inputObject != null && inputObject.GetComponent<OVRGrabbable>().isGrabbed && !inputObject.GetComponent<OVRGrabbable>().isNotGrabObject)
        {
            inputObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<MeshRenderer>().enabled = true;
            inputObject = null;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (autoInstallObject && other.GetComponent<OVRGrabbable>() != null)
        {
            if (!other.GetComponent<OVRGrabbable>().isGrabbed && inputObject == null)
            {
                other.transform.position = transform.position;
                other.transform.rotation = transform.rotation;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                inputObject = other.gameObject;
                GetComponent<MeshRenderer>().enabled = false;

                if (other.CompareTag("Seed"))
                {
                    other.GetComponent<OVRGrabbable>().isNotGrabObject = true;
                    other.GetComponent<MeshRenderer>().enabled = false;
                    other.GetComponent<FlowerDataScript>().SetFlower(0);
                    other.GetComponent<FlowerDataScript>().waterrayt = true;
                }
            }
        }
    }
}