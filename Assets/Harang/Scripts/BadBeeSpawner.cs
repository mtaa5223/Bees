using Meta.WitAi.Utilities;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BadBeeSpawner : MonoBehaviour
{
    [Tooltip("������ ������ ��ġ�Դϴ�")]
    [SerializeField] private Transform[] spawnPoints;

    [Tooltip("������ �����Ǵ� �ּҽð��Դϴ�")]
    [SerializeField] private float minTime;
    [Tooltip("������ �����Ǵ� �ִ�ð��Դϴ�")]
    [SerializeField] private float maxTime;

    [Tooltip("������ �������� �ִ� �����Դϴ�")]
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
