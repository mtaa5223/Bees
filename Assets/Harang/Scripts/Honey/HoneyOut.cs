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

        // ���� ȸ�� ���⿡ ���� ������Ʈ ȸ�� ���� ����
        float circleRotationDirection = Mathf.Sign(angleChange);
        float objectRotationDirection = -circleRotationDirection; // �ݴ� �������� ����

        // ������Ʈ ȸ��
        rotationObject.transform.Rotate(Vector3.forward, rotationAmount * objectRotationDirection * rotateSpeed, Space.Self);

        // ���� ���� ������Ʈ
        previousAngle = currentAngle;
    }
}
