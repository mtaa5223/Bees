using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab; // 플레이어 프리팹
    public GameObject beePrefab; // 비 프리팹

    bool mine = false;
    

    float daycount = 0;

    public Text text;
    int day = 0;
    private void Awake()
    {
        CreatePlayer();
    }

    private void Update()
    {
        daycount += Time.deltaTime;
        if (daycount >= 300f)
        {
            daycount -= 300f;
            day += 1;

            DayDay();
        }
    }

    private void CreatePlayer()
    {
        Vector3 spawnPosition = new Vector3(0f, 3f, 0f);

        if (PhotonNetwork.CurrentRoom.PlayerCount > 0)
        {
            GameObject bee = PhotonNetwork.Instantiate(beePrefab.name, spawnPosition, Quaternion.identity);
            PhotonNetwork.LocalPlayer.TagObject = bee; 
            mine = true;

        }
        else if(mine == true)
        {
            GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);
            PhotonNetwork.LocalPlayer.TagObject = player;
        }
    }

    private void DayDay()
    {
        text.text = "D : " + day;
    }
}
