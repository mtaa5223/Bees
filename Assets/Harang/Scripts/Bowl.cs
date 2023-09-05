using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    [SerializeField] private float bowlAttackSpeed;
    private float currentSpeed; 

    public bool isBowlAttack;

    private Vector3 pastPosition;
    private Vector3 currentPostion;

    private void Start()
    {
        pastPosition = transform.position;
    }

    private void Update()
    {
        currentPostion = transform.position;

        currentSpeed = Vector3.Distance(pastPosition, currentPostion);

        if (currentSpeed > bowlAttackSpeed)
        {
            isBowlAttack = true;
            Debug.Log("±ø");
        }
        else
        {
            isBowlAttack = false;
        }

        pastPosition = transform.position;
        isBowlAttack = true;
    }
}
