using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using Photon.Pun;

public class handsPlayer : MonoBehaviourPun
{
    [SerializeField] private GameObject player;
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
        playerHands = GameObject.Find("Hands").gameObject;

        int PlayerHand = controllerDir == ControllerDir.leftController ? 0 : 1;
        player = playerHands.transform.GetChild(PlayerHand).GetChild(0).GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            player.transform.position = transform.position;
            player.transform.rotation = transform.rotation;
        }
}
    }
