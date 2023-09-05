using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab; // �÷��̾� ������
    public GameObject beePrefab; // �� ������
    public GameObject clonePlayer;
    public GameObject panel;
  

    private void Awake()
    {
       
    }


    public void Bee()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), 3f, Random.Range(-5f, 5f)); // ������ ��ġ ����
        GameObject bee = PhotonNetwork.Instantiate(beePrefab.name, spawnPosition, Quaternion.identity);
        PhotonNetwork.LocalPlayer.TagObject = bee;
        Destroy(clonePlayer);
        Destroy(panel);

       

    }
    public void player()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), 2f, Random.Range(-5f, 5f)); // ������ ��ġ ����
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);
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