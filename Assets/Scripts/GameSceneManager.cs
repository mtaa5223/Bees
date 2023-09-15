using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab; // 플레이어 프리팹
    public GameObject beePrefab; // 비 프리팹
    public GameObject clonePlayer;
    public GameObject panel;
    public Vector3 spawnPoint;


    private void Awake()
    {
       
    }


    public void Bee()
    {
    
        GameObject bee = PhotonNetwork.Instantiate(beePrefab.name, spawnPoint, Quaternion.identity);
        PhotonNetwork.LocalPlayer.TagObject = bee;
        Destroy(clonePlayer);
        Destroy(panel);

       

    }
    public void player()
    {
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint, Quaternion.identity);
        PhotonNetwork.LocalPlayer.TagObject = player;
        Destroy(clonePlayer);
        Destroy(panel);
      
    }

    public void Update()
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
          
        }
    }
}