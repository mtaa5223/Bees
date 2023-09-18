using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPot : MonoBehaviour
{
    public Transform seedArea;

    private void Start()
    {
        seedArea = transform.GetChild(0);
    }

    
}
