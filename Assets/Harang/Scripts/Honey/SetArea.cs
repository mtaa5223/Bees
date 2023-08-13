using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetArea : MonoBehaviour
{
    private int inputObjectCount; 
    private bool autoInstallObject = false;

    public GameObject inputObject;

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
    }

    void OnTriggerStay(Collider other)
    {
        if (autoInstallObject && other.GetComponent<OVRGrabbable>() != null)
        {
            if (!other.GetComponent<OVRGrabbable>().isGrabbed)
            {
                other.transform.position = transform.position;
                other.transform.rotation = transform.rotation;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                inputObject = other.gameObject;
                GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                inputObject = null;
                GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}