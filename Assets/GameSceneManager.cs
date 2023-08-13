using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab; // �÷��̾� ������
    public GameObject beePrefab; // �� ������

    private void Awake()
    {
        CreateRandomObject();
    }

    private void CreateRandomObject()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), 3f, Random.Range(-5f, 5f)); // ������ ��ġ ����
        int randomValue = Random.Range(0, 2); // 0 �Ǵ� 1 �� ���� ����

        if (randomValue == 0)
        {
            GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);
            PhotonNetwork.LocalPlayer.TagObject = player;
        }
        else
        {
            GameObject bee = PhotonNetwork.Instantiate(beePrefab.name, spawnPosition, Quaternion.identity);
            PhotonNetwork.LocalPlayer.TagObject = bee;
        }
    }
}
