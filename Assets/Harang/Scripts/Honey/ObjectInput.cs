using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInput : MonoBehaviour
{
    [SerializeField] private string[] objectTags;
    public bool isIn;

    void OnTriggerEnter(Collider other)
    {
        foreach (string objectTag in objectTags)
        {
            if (other.CompareTag(objectTag))
            {
                isIn = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        foreach (string objectTag in objectTags)
        {
            if (other.CompareTag(objectTag))
            {
                isIn = false;
            }
        }
    }
}