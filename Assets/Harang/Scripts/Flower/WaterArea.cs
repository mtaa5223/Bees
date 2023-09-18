using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterArea : MonoBehaviour
{
    [SerializeField] private float waterPower;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            transform.parent.GetComponent<FlowerDataScript>().CurrentWater += waterPower;
            Destroy(other.gameObject);
        }
    }
}
