using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyGun : MonoBehaviour
{
    [System.Serializable]
    private enum ControllerDir
    {
        leftController,
        rightController
    }

    [SerializeField] ControllerDir controllerDir;

    [SerializeField] private float maxHoney;
    [SerializeField] private float currentHoney;
    public float CurrentHoney
    {
        get
        { 
            return currentHoney; 
        }
        set 
        {
            if (currentHoney > 100)
            {
                currentHoney = 100;
            }
            else
            {
                currentHoney = value;
            }
        }
    }

    [SerializeField] private float increaseAmount;

    [Space(10)]
    [SerializeField] private float bulletAmount;
    [SerializeField] private float bulletCoolTime;
    [SerializeField] private float bulletCurrentTime;
    [SerializeField] private float bulletPower;
    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject honeyBulletPrefab;

    [Space(10)]
    [SerializeField] private Renderer honeyRend;

    void Update()
    {
        bool isLeftIndexTriggerPressed = OVRInput.Get(OVRInput.RawButton.LIndexTrigger) && controllerDir == ControllerDir.leftController;
        bool isRightIndexTriggerPressed = OVRInput.Get(OVRInput.RawButton.RIndexTrigger) && controllerDir == ControllerDir.rightController;

        bulletCurrentTime += Time.deltaTime;

        if ((isLeftIndexTriggerPressed || isRightIndexTriggerPressed) && CurrentHoney - bulletAmount >= 0 && bulletCurrentTime >= bulletCoolTime)
        {
            CurrentHoney -= bulletAmount;
            honeyRend.material.SetFloat("_Fill", CurrentHoney / maxHoney);
            
            GameObject honeyBullet = Instantiate(honeyBulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
            honeyBullet.GetComponent<Rigidbody>().AddForce(honeyBullet.transform.forward * bulletPower, ForceMode.Impulse);

            bulletCurrentTime = 0;
        }

        //Debug.Log(OVRInput.Get(OVRInput.RawButton.RHandTrigger));
    }

    void OnTriggerStay(Collider other)
    {
        bool isLeftHandTriggerPressed = OVRInput.Get(OVRInput.RawButton.LHandTrigger) && controllerDir == ControllerDir.leftController;
        bool isRightHandTriggerPressed = OVRInput.Get(OVRInput.RawButton.RHandTrigger) && controllerDir == ControllerDir.rightController;

        if (other.CompareTag("Flower") && (isLeftHandTriggerPressed || isRightHandTriggerPressed))
        {
            CurrentHoney += increaseAmount * Time.deltaTime;    
            honeyRend.material.SetFloat("_Fill", CurrentHoney / maxHoney);
        }
    }
}
