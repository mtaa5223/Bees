using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLobbyManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
       PhotonNetwork.Instantiate("Bee",Vector3.zero,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
