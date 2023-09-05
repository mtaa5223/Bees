using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class net2 : MonoBehaviourPunCallbacks
{

    public GameObject avatar;
    public Transform playerGlobal;
    public Transform playerLocal;


    void Start()
    {

        Debug.Log("I am Networked Player");

        if (photonView.IsMine)
        {
            Debug.Log("photonview is mine");
            playerGlobal = GameObject.Find("OVRCameraRig").transform;
            playerLocal = playerGlobal.Find("CenterEyeAnchor");

            this.transform.SetParent(playerLocal);
            this.transform.localPosition = Vector3.zero;

            
        }
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            Debug.Log("send the others my data");

             stream.SendNext(playerGlobal.position);
            stream.SendNext(playerGlobal.rotation);
            stream.SendNext(playerLocal.localPosition);
             stream.SendNext(playerLocal.localRotation);
        }
        else
        {
            this.transform.position = (Vector3)stream.ReceiveNext();
            this.transform.rotation = (Quaternion)stream.ReceiveNext();
            avatar.transform.localPosition = (Vector3)stream.ReceiveNext();
            avatar.transform.localRotation = (Quaternion)stream.ReceiveNext();
        }
    }
}