using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyBase : MonoBehaviour
{
    public Transform honeyPlateAreas;

    private void Start()
    {
        honeyPlateAreas = transform.GetChild(2);
    }

    private void Update()
    {
        //AddHoney(10 * Time.deltaTime);
    }

 

    public void AddHoney(float honey)
    {
        foreach (Transform honeyPlateArea in honeyPlateAreas)
        {
            if (honeyPlateArea.GetComponent<SetArea>().inputObject != null) 
            {
                GameObject honeyPlate = honeyPlateArea.GetComponent<SetArea>().inputObject;
                if (honey > 0 && honeyPlate.GetComponent<HoneyPlate>().CurrentHoney < 100)
                {
                    honeyPlate.GetComponent<HoneyPlate>().CurrentHoney += honey;
                    return;
                }
            }
        }
    }

    public void DeleteHoney(float honey)
    {
        foreach (Transform honeyPlateArea in honeyPlateAreas)
        {
            if (honeyPlateArea.GetComponent<SetArea>().inputObject != null)
            {
                GameObject honeyPlate = honeyPlateArea.GetComponent<SetArea>().inputObject;
                if (honeyPlate.GetComponent<HoneyPlate>().CurrentHoney > 0)
                {
                    honeyPlate.GetComponent<HoneyPlate>().CurrentHoney -= honey;
                    return;
                }
            }
        }
    }

    public bool NullHoney()
    {
        foreach (Transform honeyPlateArea in honeyPlateAreas)
        {
            if (honeyPlateArea.GetComponent<SetArea>().inputObject != null)
            {
                GameObject honeyPlate = honeyPlateArea.GetComponent<SetArea>().inputObject;
                if (honeyPlate.GetComponent<HoneyPlate>().CurrentHoney > 0)
                {
                    return false;
                }
            }
        }
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("沿馬櫛 極ししししししししししししししししししし");
            Destroy(other.gameObject);
        }
    }


}
