using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class HoneyOut : MonoBehaviour
{
    
    [SerializeField] private GameObject CrankLever;
    [SerializeField] private GameObject rotationObject;

    [SerializeField] private float rotateSpeed;

    private float previousAngle = 0f;


    private void Update()
    {
        float currentAngle = CrankLever.transform.rotation.eulerAngles.z;

        float angleChange = currentAngle - previousAngle;

        if (angleChange > 180f)
        {
            angleChange -= 360f;
        }
        else if (angleChange < -180f)
        {
            angleChange += 360f;
        }

        float rotationAmount = angleChange * Time.deltaTime;

        // 원의 회전 방향에 따라 오브젝트 회전 방향 설정
        float circleRotationDirection = Mathf.Sign(angleChange);
        float objectRotationDirection = -circleRotationDirection; // 반대 방향으로 조정

        // 오브젝트 회전
        rotationObject.transform.Rotate(Vector3.forward, rotationAmount * objectRotationDirection * rotateSpeed, Space.Self);

        // 이전 각도 업데이트
        previousAngle = currentAngle;
    }
}
