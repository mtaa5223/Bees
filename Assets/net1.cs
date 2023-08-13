using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class net1 : MonoBehaviour
{

    string _room = "Tutorial";

    // Use this for initialization
    void Start()
    {

        Debug.Log("Network Controller Start");

        PhotonNetwork.ConnectUsingSettings();
    }

    void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");

        PhotonNetwork.JoinRandomRoom();

        //RoomOptions roomOptions = new RoomOptions() {};
        //PhotonNetwork.JoinOrCreateRoom(_room, roomOptions, TypedLobby.Default);
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Joined Lobby fail");

        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom()
    {
        Debug.Log("Joined Room");

        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity, 0);
    }
}