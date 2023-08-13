using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyBase : MonoBehaviour
{
    private Transform honeyPlateAreas;

    private void Start()
    {
        honeyPlateAreas = transform.GetChild(1);
    }

    private void Update()
    {
        AddHoney(10 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            AddHoney(20);
        }
    }

    public void AddHoney(float honey)
    {
        foreach (Transform honeyPlateArea in honeyPlateAreas)
        {
            if (honeyPlateArea.GetComponent<SetArea>().inputObject != null)
            {
                GameObject honeyPlate = honeyPlateArea.GetComponent<SetArea>().inputObject;
                if (honeyPlate.GetComponent<HoneyPlate>().CurrentHoney < 100)
                {
                    honeyPlate.GetComponent<HoneyPlate>().CurrentHoney += honey;
                    return;
                }
            }
        }
    }
}
