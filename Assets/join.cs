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
            Debug.Log("�̵� ����");
            // ��� �÷��̾�� ���� ������ �̵��� �˸�
            PhotonView.Get(this).RPC("GameScene", RpcTarget.All);
        }
    }

    [PunRPC]
    public void GameScene()
    {
        PhotonNetwork.AutomaticallySyncScene = false; // �� ����ȭ�� ��Ȱ��ȭ�մϴ�.

        // ���� ������ �̵�
        SceneManager.LoadScene("GameScene");
    }
}
