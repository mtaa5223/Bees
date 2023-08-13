using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float moveSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 thumbstickInput = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);

        Vector3 movementDirection = new Vector3(thumbstickInput.x, 0f, thumbstickInput.y).normalized;

        // Rigidbody를 사용하여 이동
        Vector3 movement = movementDirection * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }
}
