using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyGunTrigger : MonoBehaviour
{
    
    public bool isTrigger = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flower"))
        {
            isTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Flower"))
        {
            isTrigger = false;
        }
       
    }
}
