using Meta.WitAi.Utilities;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BadBeeSpawner : MonoBehaviour
{
    [Tooltip("말벌이 생성될 위치입니다")]
    [SerializeField] private Transform[] spawnPoints;

    [Tooltip("말벌이 생성되는 최소시간입니다")]
    [SerializeField] private float minTime;
    [Tooltip("말벌이 생성되는 최대시간입니다")]
    [SerializeField] private float maxTime;

    [Tooltip("말벌의 프리팹을 넣는 공간입니다")]
    [SerializeField] private GameObject badBeePrefab;

    private void Start()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            StartCoroutine(BadBeeSpawn(spawnPoint));
        }
    }

    IEnumerator BadBeeSpawn(Transform spawnPoint)
    {
        float creatTime = 0;
        if (GameObject.Find("Bee(Clone)") != null)
        {
            creatTime = Random.Range(minTime, maxTime);
            GameObject honeyBullet = PhotonNetwork.Instantiate("BadBee",transform.position, transform.rotation);
        }

        yield return new WaitForSeconds(creatTime);

        StartCoroutine(BadBeeSpawn(spawnPoint));
    }
}
