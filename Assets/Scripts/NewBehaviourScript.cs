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


        Debug.Log("�̵� ����");
        if (PhotonNetwork.IsMasterClient)
        {
            // ��� �÷��̾�� ���� ������ �̵��� �˸�
            photonView.RPC("GameScene", RpcTarget.All);
        }

        // ���� �÷��̾ ������ Ŭ���̾�Ʈ���� Ȯ��


    }

    [PunRPC]
    public void GameScene()
    {


        PhotonNetwork.AutomaticallySyncScene = true;

        // ���� ������ �̵�
        PhotonNetwork.LoadLevel("GameScene");

        // ��� �÷��̾ ���� �ε��� �� �ֵ��� ��

    }

}