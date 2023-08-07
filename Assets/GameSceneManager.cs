using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab; // 플레이어 프리팹
    public GameObject beePrefab; // 비 프리팹
    public GameObject Manager;


    Vector3 spawnPosition2 = new Vector3(0f, 0f, 0f);

    float daycount = 0;

    public int random = 0;

    public Text text;
    int day = 0;
    private void Awake()
    {
        CreatePlayer();
        GameObject Man = PhotonNetwork.Instantiate(Manager.name, spawnPosition2, Quaternion.identity);
    }

    private void Update()
    {
        daycount += Time.deltaTime;
        if (daycount >= 300f)
        {
            daycount -= 300f;
            day += 1;

            
        }
    }

    private void CreatePlayer()
    {
        Vector3 spawnPosition = new Vector3(0f, 3f, 0f);


            if (Random.Range(0, 2) == 0) // 0 또는 1을 랜덤하게 선택
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




