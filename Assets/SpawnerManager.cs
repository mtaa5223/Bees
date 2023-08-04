
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnerManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject playerPrefabs;

    public Vector3 spawnPosition;
    void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.Instantiate(playerPrefabs.name, spawnPosition, Quaternion.identity);
        }
    }
}
