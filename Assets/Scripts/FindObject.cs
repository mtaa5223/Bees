using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject Head = transform.Find("Head").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
