using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using Photon.Pun;

public class handsPlayer : MonoBehaviourPun
{
    private enum ControllerDir
    {
        leftController,
        rightController
    }
    GameObject playerHands;

    [SerializeField] ControllerDir controllerDir;

    // Start is called before the first frame update
    void Start()
    {
        playerHands = GameObject.Find("hands").gameObject;

        int honeyGunNumber = controllerDir == ControllerDir.leftController ? 0 : 1;
        playerHands = playerHands.transform.GetChild(honeyGunNumber).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            playerHands.transform.position = transform.position;
            playerHands.transform.rotation = transform.rotation;
        }
}
    }
