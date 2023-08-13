using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPhyisics : MonoBehaviour
{
    public Transform target;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.position = target.transform.position;
    }
}
