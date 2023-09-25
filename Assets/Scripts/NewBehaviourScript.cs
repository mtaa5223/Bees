using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class joinroom : MonoBehaviourPunCallbacks
{
    private const int MaxPlayers = 2;

    private PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();

        if (photonView == null)
        {
            Debug.LogError("PhotonView component not found on the LobbyButton object.");
        }
    }


    public void realStartGame()
    {


        Debug.Log("이동 가능");
        if (PhotonNetwork.IsMasterClient)
        {
            // 모든 플레이어에게 게임 씬으로 이동을 알림
            photonView.RPC("GameScene", RpcTarget.All);
        }

        // 현재 플레이어가 마스터 클라이언트인지 확인


    }

    [PunRPC]
    public void GameScene()
    {


        PhotonNetwork.AutomaticallySyncScene = true;

        // 게임 씬으로 이동
        PhotonNetwork.LoadLevel("GameScene");

        // 모든 플레이어가 씬을 로드할 수 있도록 함

    }

}