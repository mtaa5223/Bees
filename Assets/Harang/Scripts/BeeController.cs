using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{
    private GameObject cameraRigObject;
    private OVRCameraRig cameraRig;

    [System.Serializable]
    private struct UpDownData
    {
        [Space(7)]
        [Tooltip("올라가거나 내려가기 시작하는 각도입니다")]
        [Range(5.0f, 50f)]
        public float startAngle;
        [Tooltip("최대 속도가 되기위한 최대 각도입니다")]
        [Range(1.0f, 20.0f)]
        public float maxAngle;
        
        [Tooltip("최소 속도입니다")]
        public float minSpeed;
        [Tooltip("최대 속도입니다")]
        public float maxSpeed;
    }

    [Header("UpDownMove")]
    [Tooltip("기준이 되는 각도입니다")]
    [SerializeField] private float standardAngle;

    [SerializeField] private UpDownData upData;
    [SerializeField] private UpDownData downData;

    [Space(10)]
    public float xRotation;

    [SerializeField] private GameObject beeModel;
    [SerializeField] private float moveSpeed;
    GameObject beeObject;

    private bool doRotate = false;

    void Start()
    {
       
        beeObject = GameObject.Find("Bee(Clone)").gameObject;
        beeModel = beeObject.transform.GetChild(0).gameObject;
       cameraRigObject = transform.gameObject;
        cameraRig = cameraRigObject.GetComponent<OVRCameraRig>();
    }

    void Update()
    {
        Debug.Log(cameraRigObject);
        #region 상하 이동
        Vector3 controllerRotation = cameraRig.rightHandAnchor.rotation.eulerAngles;

        xRotation = controllerRotation.x - 180 + standardAngle;

        if (xRotation > 180)
        {
            xRotation = xRotation - 360;
        }

        float speed = 0;
        //Up
        if (xRotation <= 180 - upData.startAngle && xRotation > 0)
        {
            xRotation -= 180 - upData.startAngle;
         
            xRotation = Mathf.Clamp(Mathf.Abs(xRotation), 0.0f, upData.maxAngle);
            
            float tempSpeed = upData.maxSpeed - upData.minSpeed;
            speed = (tempSpeed * (xRotation / upData.maxAngle) + upData.minSpeed);
        } 
        //Down
        if (xRotation >= -180 + downData.startAngle && xRotation < 0)
        {
            xRotation += 180 - downData.startAngle;
           

            xRotation = Mathf.Clamp(Mathf.Abs(xRotation), 0.0f, downData.maxAngle);

            float tempSpeed = downData.maxSpeed - downData.minSpeed;
            speed = -(tempSpeed * (xRotation / downData.maxAngle) + downData.minSpeed);
        }
        beeObject.transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        #endregion

        #region 앞뒤양옆 이동
        Transform centerEyeAnchor = cameraRig.centerEyeAnchor;
        Vector3 childDirection = centerEyeAnchor.forward;

        beeModel.transform.position = centerEyeAnchor.transform.position;
        beeModel.transform.rotation = centerEyeAnchor.transform.rotation;

        Vector2 thumbstickInput = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);

        Vector3 moveDirection = (centerEyeAnchor.forward * thumbstickInput.y) + (centerEyeAnchor.right * thumbstickInput.x);

        beeObject.transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        #endregion
        
        Vector2 rightThumbstickDir = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);
        if (rightThumbstickDir.x == 0)
        {
            doRotate = false;
        }

        if (Mathf.Abs(rightThumbstickDir.x) >= 0.7f && !doRotate)
        {
            float yAngle = 0;
            yAngle = rightThumbstickDir.x > 0 ? 45 : -45;

            Quaternion cameraRigRotation = cameraRigObject.transform.rotation;
            Quaternion rotation = Quaternion.Euler(cameraRigRotation.eulerAngles.x, cameraRigRotation.eulerAngles.y + yAngle, cameraRigRotation.eulerAngles.z);

            cameraRigObject.transform.rotation = rotation;
            doRotate = true;
        }

        if (beeObject.transform.position.y <= 0.8f)
        {
            beeObject.transform.position = new Vector3(beeObject.transform.position.x, 0.8f, beeObject.transform.position.z);
        }
    }
}
