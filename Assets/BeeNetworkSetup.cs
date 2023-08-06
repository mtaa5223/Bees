using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class BeeNetworkSetup : MonoBehaviourPunCallbacks
{
    public GameObject LocalXRRigGameobject;

    public GameObject AvatarBodyGameobject;
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            LocalXRRigGameobject.SetActive(true);


            SetLayerRecursively(AvatarBodyGameobject, 9);
        }
        else
        {
            LocalXRRigGameobject.SetActive(false);
            SetLayerRecursively(AvatarBodyGameobject, 0);
        }
    }
    void SetLayerRecursively(GameObject go, int layerNumber)
    {
        if (go == null) return;
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}