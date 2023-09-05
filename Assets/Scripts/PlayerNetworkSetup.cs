 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerNetworkSetup : MonoBehaviourPunCallbacks
{
    public GameObject LocalXRRigGameobject;

    public GameObject AvatarHeadGameobject;
    public GameObject AvatarBodyGameobject;
    // Start is called before the first frame update
    void Start()
    {
       
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
