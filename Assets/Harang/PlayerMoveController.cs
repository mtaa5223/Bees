using Oculus.Platform;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;

    private OVRCameraRig cameraRig;
    private bool doRotate = false;

    private void Start()
    {
        cameraRig = GetComponent<OVRCameraRig>();
    }

    void Update()
    {
        #region Player Move
        Vector2 leftThumbstickDir = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);

        Vector3 forward = cameraRig.centerEyeAnchor.forward;
        Vector3 right = cameraRig.centerEyeAnchor.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = leftThumbstickDir.y * forward + leftThumbstickDir.x * right;

        moveDirection.Normalize();
        transform.parent.position += moveDirection * moveSpeed * Time.deltaTime;
        #endregion

        #region Player Rotate
        Vector2 rightThumbstickInput = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);
        if (rightThumbstickInput.x == 0)
        {
            doRotate = false;
        }

        if (Mathf.Abs(rightThumbstickInput.x) >= 0.7f && !doRotate)
        {
            float yAngle = 0;
            yAngle = rightThumbstickInput.x > 0 ? 45 : -45;

            Quaternion cameraRigRotation = transform.rotation;
            Quaternion rotation = Quaternion.Euler(cameraRigRotation.eulerAngles.x, cameraRigRotation.eulerAngles.y + yAngle, cameraRigRotation.eulerAngles.z);

            transform.rotation = rotation;
            doRotate = true;
        }
        #endregion
    }
}