using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class join : MonoBehaviourPunCallbacks
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

    public void RealStartGame()
    {
        
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("이동 가능");
            // 모든 플레이어에게 게임 씬으로 이동을 알림
            PhotonView.Get(this).RPC("GameScene", RpcTarget.All);
        }
    }

    [PunRPC]
    public void GameScene()
    {
        PhotonNetwork.AutomaticallySyncScene = false; // 씬 동기화를 비활성화합니다.

        // 게임 씬으로 이동
        SceneManager.LoadScene("GameScene");
    }
}
