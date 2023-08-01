using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class LoginManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    #region UI Callback Methods
    public  void ConnectAnonymously()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    #endregion

    public override void OnConnected()
    {
        Debug.Log("connect");
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connect to Master");
    }
}
