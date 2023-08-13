using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab; // 플레이어 프리팹
    public GameObject beePrefab; // 비 프리팹

    private void Awake()
    {
        CreateRandomObject();
    }

    private void CreateRandomObject()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), 3f, Random.Range(-5f, 5f)); // 랜덤한 위치 설정
        int randomValue = Random.Range(0, 2); // 0 또는 1 중 랜덤 선택

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
