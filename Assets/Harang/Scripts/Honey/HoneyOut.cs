using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class HoneyOut : MonoBehaviour
{
    
    [SerializeField] private GameObject CrankLever;
    [SerializeField] private GameObject rotationObject;
    [SerializeField] private Renderer bigHoneyRenderer;

    [SerializeField] private float maxBigHoney;
    [SerializeField] private float currentBigHoney;

    [SerializeField] private float rotateSpeed;
    [SerializeField] private float honeySpeed;

    [SerializeField] private Transform honeyPlateAreas;

    private float previousAngle = 0f;

    private void Start()
    {
        honeyPlateAreas = transform.GetChild(1).GetChild(0);
    }

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

        // ������Ʈ ȸ��
        rotationObject.transform.Rotate(Vector3.forward, rotationAmount * rotateSpeed, Space.Self);

        // ���� ���� ������Ʈ
        previousAngle = currentAngle;

        foreach (Transform honeyPlateArea in honeyPlateAreas)
        {
            if (honeyPlateArea.GetComponent<SetArea>().inputObject != null)
            {
                GameObject honeyPlate = honeyPlateArea.GetComponent<SetArea>().inputObject;
                if (honeyPlate.GetComponent<HoneyPlate>().CurrentHoney > 0) 
                {
                    honeyPlate.GetComponent<HoneyPlate>().CurrentHoney -= Mathf.Abs(rotationAmount) * honeySpeed;
                    if (currentBigHoney <= maxBigHoney)
                    {
                        currentBigHoney += Mathf.Abs(rotationAmount) * honeySpeed;
                    }
                    else
                    {
                        currentBigHoney = maxBigHoney;
                    }
                    bigHoneyRenderer.material.SetFloat("_Fill", currentBigHoney / maxBigHoney);
                }
            }
        }
    }
}