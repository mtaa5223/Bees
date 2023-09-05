using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HoneyGun : MonoBehaviourPun
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
    [SerializeField] private GameObject honeyBulletPrefab;
    private GameObject firePoint;

    [SerializeField] private GameObject honeyGuns;
    [SerializeField] private GameObject honeyGun;

    [Space(10)]
    [SerializeField] private Renderer honeyRend;

    private void Start()
    {
        honeyGuns = GameObject.Find("HoneyGuns").gameObject;

        int honeyGunNumber = controllerDir == ControllerDir.leftController ? 0 : 1;
        honeyGun = honeyGuns.transform.GetChild(honeyGunNumber).gameObject;

        firePoint = honeyGun.transform.GetChild(0).gameObject;
        honeyRend = honeyGun.transform.GetChild(1).transform.GetChild(0).GetComponent<Renderer>();
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            honeyGun.transform.position = transform.position;
            honeyGun.transform.rotation = transform.rotation;

            bool isLeftIndexTriggerPressed = OVRInput.Get(OVRInput.RawButton.LIndexTrigger) && controllerDir == ControllerDir.leftController;
            bool isRightIndexTriggerPressed = OVRInput.Get(OVRInput.RawButton.RIndexTrigger) && controllerDir == ControllerDir.rightController;

            bulletCurrentTime += Time.deltaTime;

            if ((isLeftIndexTriggerPressed || isRightIndexTriggerPressed) && CurrentHoney - bulletAmount >= 0 && bulletCurrentTime >= bulletCoolTime)
            {
                CurrentHoney -= bulletAmount;
                honeyRend.material.SetFloat("_Fill", CurrentHoney / maxHoney);

                GameObject honeyBullet = PhotonNetwork.Instantiate("HoneyBullet", firePoint.transform.position, firePoint.transform.rotation);
                honeyBullet.GetComponent<Rigidbody>().AddForce(honeyBullet.transform.forward * bulletPower, ForceMode.Impulse);

                bulletCurrentTime = 0;
            }
            bool isLeftHandTriggerPressed = OVRInput.Get(OVRInput.RawButton.LHandTrigger) && controllerDir == ControllerDir.leftController;
            bool isRightHandTriggerPressed = OVRInput.Get(OVRInput.RawButton.RHandTrigger) && controllerDir == ControllerDir.rightController;

            if (honeyGun.GetComponent<HoneyGunTrigger>().isTrigger && (isLeftHandTriggerPressed || isRightHandTriggerPressed))

            {
                CurrentHoney += increaseAmount * Time.deltaTime;
                honeyRend.material.SetFloat("_Fill", CurrentHoney / maxHoney);
            }
        }
       

        //Debug.Log(OVRInput.Get(OVRInput.RawButton.RHandTrigger));
    }


}
